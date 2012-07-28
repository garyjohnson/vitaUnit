using System;

namespace VitaUnit.Test
{
	[TestClass]
	public class AssertTest
	{
		[TestMethod]
		public void ShouldThrowExceptionWhenAssertIsTrueFails() {
			bool threwException = false;
			
			try {
				Assert.IsTrue(false);
			} catch (Exception) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsTrueSucceeds() {
			Assert.IsTrue(true);
		}
		
		[TestMethod]
		public void ShouldThrowExceptionWhenAssertIsFalseFails() {
			bool threwException = false;
			
			try {
				Assert.IsFalse(true);
			} catch (Exception) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsFalseSucceeds() {
			Assert.IsFalse(false);
		}
	}
}

