using System;

namespace VitaUnit.Test
{
	[TestClass]
	public class AssertTest
	{
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsTrueFails() {
			bool threwException = false;
			
			try {
				Assert.IsTrue(false);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsTrueSucceeds() {
			Assert.IsTrue(true);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsFalseFails() {
			bool threwException = false;
			
			try {
				Assert.IsFalse(true);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsFalseSucceeds() {
			Assert.IsFalse(false);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualFailsForValueType() {
			
			bool threwException = false;
			
			try {
				Assert.AreEqual(1,2);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertAreEqualSucceedsForValueType() {
			Assert.AreEqual(100, 100);
		}
	}
}

