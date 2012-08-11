using System;
using System.Collections.Generic;

namespace VitaUnit
{
	[TestClass]
	public class TestRunnerTest
	{
		[TestMethod]
		public void ShouldRunUITestsBeforeOtherTests() {
			var testMethodProvider = new MockTestMethodProvider();
			var uiTestMethod = new MockTestMethod() { IsUIThreadTest = true };
			var testMethod = new MockTestMethod();
			testMethodProvider.TestClasses = new List<Type> { typeof(MockTestClass) };
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, uiTestMethod };
			
			VitaUnitRunner.RegisterService<ITestMethodProvider>(testMethodProvider);
			VitaUnitRunner.RegisterService<ITaskRunner, MockTaskRunner>();
			
			var testRunner = new TestRunner();
			
			bool wasUITestRunFirst = false;
			uiTestMethod.OnInvoke += (sender, e) => {
				wasUITestRunFirst = !testMethod.WasInvokeCalled;
			};
			
			testRunner.Run();
			
			VitaUnitRunner.RegisterService<ITestMethodProvider, ReflectionTestMethodProvider>();
			
			Assert.IsTrue(wasUITestRunFirst, "Expected UI thread test to be run first");
		}
		
		[TestMethod]
		public void ShouldRunSetUpBeforeEveryTest() {
			var testMethodProvider = new MockTestMethodProvider();
			var testMethod = new MockTestMethod();
			var testMethod2 = new MockTestMethod();
			var setUpMethod = new MockSetUpMethod();
			testMethodProvider.TestClasses = new List<Type> { typeof(MockTestClass) };
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, testMethod2 };
			testMethodProvider.SetUpMethod = setUpMethod;
			
			VitaUnitRunner.RegisterService<ITestMethodProvider>(testMethodProvider);
			VitaUnitRunner.RegisterService<ITaskRunner, MockTaskRunner>();
			
			var testRunner = new TestRunner();
			
			int timesSetUpCalled = 0;	
			setUpMethod.OnInvoke += (sender, e) => {
				timesSetUpCalled++;
			};
			
			testRunner.Run();
			
			Assert.AreEqual(2, timesSetUpCalled, "Expected SetUp method to be called for each test method.");
		}
	}
}

