using System;
using System.Collections.Generic;

namespace VitaUnit
{
	[TestClass]
	public class TestRunnerTest
	{
		MockTestMethodProvider testMethodProvider;
		MockTestMethod uiTestMethod;
		MockTestMethod testMethod;
		MockTestMethod testMethod2;
		MockSetUpMethod setUpMethod;
		TestRunner testRunner;
		
		[SetUp]
		public void SetUp() {
			testMethodProvider = new MockTestMethodProvider();
			uiTestMethod = new MockTestMethod() { IsUIThreadTest = true };
			testMethod = new MockTestMethod();
			testMethod2 = new MockTestMethod();
			setUpMethod = new MockSetUpMethod();
			testMethodProvider.TestClasses = new List<Type> { typeof(MockTestClass) };
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, uiTestMethod, testMethod2 };
			testMethodProvider.SetUpMethod = setUpMethod;
			
			VitaUnitRunner.RegisterService<ITestMethodProvider>(testMethodProvider);
			VitaUnitRunner.RegisterService<ITaskRunner, MockTaskRunner>();
			
			testRunner = new TestRunner();
		}
		
		[TestMethod]
		public void ShouldRunUITestsBeforeOtherTests() {
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, uiTestMethod };
			bool wasUITestRunFirst = false;
			uiTestMethod.OnInvoke += (sender, e) => {
				wasUITestRunFirst = !testMethod.WasInvokeCalled;
			};
			
			testRunner.Run();
			
			Assert.IsTrue(wasUITestRunFirst, "Expected UI thread test to be run first");
		}
		
		[TestMethod]
		public void ShouldRunSetUpBeforeEveryTest() {
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, testMethod2 };
			int timesSetUpCalled = 0;	
			setUpMethod.OnInvoke += (sender, e) => {
				timesSetUpCalled++;
			};
			
			testRunner.Run();
			
			Assert.AreEqual(2, timesSetUpCalled, "Expected SetUp method to be called for each test method.");
		}
	}
}

