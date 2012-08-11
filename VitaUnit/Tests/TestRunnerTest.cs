using System;
using System.Collections.Generic;

namespace VitaUnit
{
	[TestClass]
	public class TestRunnerTest
	{
		[TestMethod]
		public void ShouldRunUITestsBeforeOtherTests(){
			var testMethodProvider = new MockTestMethodProvider();
			var uiTestMethod = new MockTestMethod() { IsUIThreadTest = true };
			var testMethod = new MockTestMethod();
			testMethodProvider.TestClasses = new List<Type> { typeof(MockTestClass) };
			testMethodProvider.TestMethods = new List<ITestMethod> { testMethod, uiTestMethod };
			
			VitaUnitRunner.RegisterService<ITestMethodProvider>(testMethodProvider);
			
			var testRunner = new TestRunner();
			
			bool wasUITestRunFirst = false;
			uiTestMethod.OnInvoke += (sender, e) => {
			 	wasUITestRunFirst = !testMethod.WasInvokeCalled;
			};
			
			testRunner.Run();
			
			VitaUnitRunner.RegisterService<ITestMethodProvider, ReflectionTestMethodProvider>();
			
			Assert.IsTrue(wasUITestRunFirst, "Expected UI thread test to be run first");
		}
	}
}

