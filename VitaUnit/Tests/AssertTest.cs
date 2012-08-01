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
				Assert.AreEqual(1, 2);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertAreEqualSucceedsForValueType() {
			Assert.AreEqual(100, 100);
		}
				
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualFailsForReferenceType() {
			
			bool threwException = false;
			
			try {
				object testObject1 = new object();
				object testObject2 = new object();
				Assert.AreEqual(testObject1, testObject2);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertAreEqualSucceedsForReferenceType() {
			object testObject = new object();
			Assert.AreEqual(testObject, testObject);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertAreEqualGetsNulls() {
			Assert.AreEqual(null, null);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualGetsFirstParamAsNull() {
			
			bool threwException = false;
			
			try {
				object testObject = new object();
				Assert.AreEqual(null, testObject);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualGetsSecondParamAsNull() {
			
			bool threwException = false;
			
			try {
				object testObject = new object();
				Assert.AreEqual(testObject, null);
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			Assert.IsTrue(threwException);
		}
	}
}

