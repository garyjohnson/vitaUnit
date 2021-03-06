using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Linq;

namespace VitaUnit
{
	internal class TestRunner : ITestRunner
	{
		private TestResults _uiResults = new TestResults();
		private ITestMethodProvider _testMethodProvider;
		private ITaskRunner _taskRunner;
		
		public event EventHandler<EventArgs<TestResult>> SingleTestCompleted;
		public event EventHandler<EventArgs<TestResults>> AllTestsCompleted;
		
		public TestRunner() {
			_testMethodProvider = VitaUnitRunner.GetService<ITestMethodProvider>();
			_taskRunner = VitaUnitRunner.GetService<ITaskRunner>();
		}
		
		public void Run() {
			Run(Assembly.GetEntryAssembly());
		}
		
		public void Run(params Assembly[] testAssemblies) {
			_uiResults = RunTests(testAssemblies, true);
			_taskRunner.RunTask(testAssemblies, OnRunTask, OnRunTaskCompleted);
		}

		private void FireSingleTestCompleted(TestResult testResult) {
			if(SingleTestCompleted != null)
				SingleTestCompleted(this, new EventArgs<TestResult>(testResult));
		}

		private void FireAllTestsCompleted(TestResults testResults) {
			if(AllTestsCompleted != null)
				AllTestsCompleted(this, new EventArgs<TestResults>(testResults));
		}

		private object OnRunTask(object state) {
			Assembly[] testAssemblies = (Assembly[])state;
			return RunTests(testAssemblies, false);
		}

		private void OnRunTaskCompleted(object result) {
			TestResults results = (TestResults)result;
			foreach(var key in results.Keys) {
				foreach(var item in results[key]) {
					_uiResults[key].Add(item);
				}
			}
			
			FireAllTestsCompleted(_uiResults);
		}

		private TestResult RunTearDownMethod(object testClassInstance, IMethod tearDownMethod, ITestMethod testMethod) {
			if(tearDownMethod == null)
				return null;
			
			TestResult testResult = null;
			try {
				tearDownMethod.Invoke(testClassInstance);
			} catch (Exception ex) {
				string className = testClassInstance.GetType().Name;
				testResult = new TestResult(className, testMethod.Name, false, "TearDown failed: ", ex);
			}
			
			return testResult;
		}

		private TestResults RunTests(Assembly[] testAssemblies, bool shouldRunUIThreadTests) {
			var testResults = new TestResults();
			foreach(Type testClass in _testMethodProvider.GetTestClasses(testAssemblies)) {
				object testClassInstance = TryCreateInstanceOf(testClass);
				if(testClassInstance == null) 
					continue;
					
				IMethod setUpMethod = _testMethodProvider.GetSetUpMethod(testClass);
				IMethod tearDownMethod = _testMethodProvider.GetTearDownMethod(testClass);
				foreach(ITestMethod testMethod in _testMethodProvider.GetTestMethods(testClassInstance.GetType())) {
					if(testMethod.IsUIThreadTest != shouldRunUIThreadTests) 
						continue;
						
					if(testMethod.Ignore)
						continue;
						
					TestResult testResult = RunSetUp(testClassInstance, setUpMethod, testMethod);
					if(testResult == null) {
						testResult = RunTestMethod(testClassInstance, testMethod);
						
						TestResult tearDownResult = RunTearDownMethod(testClassInstance, tearDownMethod, testMethod);
						if(tearDownResult != null)
							testResult = tearDownResult;
					}
						
					string className = testClassInstance.GetType().Name;
					testResults[className].Add(testResult);
					FireSingleTestCompleted(testResult);
				}
			}
			return testResults;
		}
		
		private object TryCreateInstanceOf(Type type) {
			object testClassInstance = null;
			try {
				testClassInstance = Activator.CreateInstance(type);
			} catch (Exception) {
			}
			
			return testClassInstance;
		}
		
		private TestResult RunSetUp(object testClassInstance, IMethod setUpMethod, ITestMethod testMethod) {
			if(setUpMethod == null)
				return null;
			
			TestResult testResult = null;
			try {
				setUpMethod.Invoke(testClassInstance);
			} catch (Exception ex) {
				string className = testClassInstance.GetType().Name;
				testResult = new TestResult(className, testMethod.Name, false, "SetUp failed: ", ex);
			}
			
			return testResult;
		}

		private TestResult RunTestMethod(object testClassInstance, ITestMethod testMethod) {
			TestResult testResult = null;
			string className = testClassInstance.GetType().Name;
			string methodName = testMethod.Name;
			
			try {
				testMethod.Invoke(testClassInstance);
				testResult = new TestResult(className, methodName, true, "The test ran successfully.");
			} catch (Exception ex) {
				testResult = new TestResult(className, methodName, false, "The test failed: ", ex);
			}
			return testResult;
		}
	}
}

