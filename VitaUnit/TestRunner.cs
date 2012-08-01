using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	internal class TestRunner : ITestRunner
	{
		public TestResults Run() {
			return Run(Assembly.GetEntryAssembly());
		}
		
		public TestResults Run(params Assembly[] testAssemblies) {
			var testResults = new TestResults();
			foreach(Type testClass in GetTestClasses(testAssemblies)) {
				object testClassInstance = TryCreateInstanceOf(testClass);
				if(testClassInstance != null)
					testResults.AddRange(RunAllTestMethodsInTestClass(testClassInstance));
			}
			
			return testResults;
		}

		private TestResults RunAllTestMethodsInTestClass(object testClassInstance) {
			var testResults = new TestResults();
			foreach(MethodInfo testMethod in GetTestMethods(testClassInstance.GetType())) {
				string className = testClassInstance.GetType().Name;
				TestResult testResult = RunTestMethod(testClassInstance, testMethod);
				testResults[className].Add(testResult);
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

		private TestResult RunTestMethod(object testClassInstance, MethodInfo testMethod) {
			TestResult testResult = null;
			string className = testClassInstance.GetType().Name;
			string methodName = testMethod.Name;
			
			try {
				testMethod.Invoke(testClassInstance, null);
				testResult = new TestResult(methodName, true, "Success");
			} catch (Exception ex) {
				testResult = new TestResult(methodName, false, "Failed: " + ex.Message);
			}
			return testResult;
		}
		
		private IEnumerable<Type> GetTestClasses(params Assembly[] assemblies) {
			var testClasses = new List<Type>();
			
			foreach(Assembly assembly in assemblies) {
				foreach(Type type in assembly.GetTypes()) {
					foreach(Attribute attribute in type.GetCustomAttributes(true)) {
						if(attribute is TestClassAttribute) {
							testClasses.Add(type);
						}
					}
				}
			}
			return testClasses;
		}
		
		private IEnumerable<MethodInfo> GetTestMethods(Type testClass) {
			var testMethods = new List<MethodInfo>();
			
			foreach(MethodInfo method in testClass.GetMethods(BindingFlags.NonPublic|BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public|BindingFlags.InvokeMethod)) {
				foreach(Attribute innerAttribute in method.GetCustomAttributes(true)) {
					if(innerAttribute is TestMethodAttribute) {
						testMethods.Add(method);
					}
				}
			}
	
			return testMethods;
		}
	}
}

