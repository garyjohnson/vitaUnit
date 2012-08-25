using System;
using System.Reflection;

namespace VitaUnit {

	[TestClass]
	public class TestMethodTest {
	
		[TestMethod]
		public void ShouldNotIgnoreMethodNotMarkedIgnore() {
			MethodInfo methodInfo = typeof(TestMethodTest).GetMethod("MethodNotMarkedIgnore");
			var testMethod = new TestMethod(methodInfo);
			
			Assert.IsFalse(testMethod.Ignore);
		}
		
		public void MethodNotMarkedIgnore(){}
	}
}

