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
		MockMethod setUpMethod;
		MockMethod tearDownMethod;
		TestRunner testRunner;
		
		[SetUp]
		public void SetUp() {
			testMethodProvider = new MockTestMethodProvider();
			uiTestMethod = new MockTestMethod() { IsUIThreadTest = true };
			testMethod = new MockTestMethod();
			testMethod2 = new MockTestMethod() ;
			setUpMethod = new MockMethod();
			tearDownMethod = new MockMethod();
			testMethodProvider.TestClasses = new List<Type> { typeof(MockTestClass) };
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, uiTestMethod, testMethod2 };
			testMethodProvider.SetUpMethod = setUpMethod;
			testMethodProvider.TearDownMethod = tearDownMethod;
			
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
		
		[TestMethod]
		public void ShouldContinueRunningTestsAfterSetUpFailure() {
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, testMethod2 };
			bool shouldThrowException = true;
			setUpMethod.OnInvoke += (sender, e) => {
				if(shouldThrowException) {
					shouldThrowException = false;
					throw new Exception("Throwing exception on first try");				
				}	
			};
			
			testRunner.Run();
			
			Assert.IsTrue(testMethod2.WasInvokeCalled, "Expected other tests to run after exception during SetUp.");
		}
		
		[TestMethod]
		public void ShouldNotRunTestThatSetUpFailedFor() {
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, testMethod2 };
			
			setUpMethod.OnInvoke += (sender, e) => {
				throw new Exception("Failure!");
			};
			
			testRunner.Run();
			
			Assert.IsFalse(testMethod.WasInvokeCalled, "Expected test to not be run when SetUp fails.");
			Assert.IsFalse(testMethod2.WasInvokeCalled, "Expected test to not be run when SetUp fails.");
		}
		
		[TestMethod]
		public void ShouldRunTearDownAfterEveryTest() {
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, testMethod2 };
			int timesTearDownCalled = 0;	
			tearDownMethod.OnInvoke += (sender, e) => {
				timesTearDownCalled++;
			};
			
			testRunner.Run();
			
			Assert.AreEqual(2, timesTearDownCalled, "Expected TearDown method to be called for each test method.");
		}
	}
}

