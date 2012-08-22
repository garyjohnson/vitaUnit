using System;
using System.Threading;

namespace VitaUnit.Test
{
	[TestClass]
	public class AssertTest
	{
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsTrueFails() {
			bool threwException = DidThrowVitaUnitException(()=>{
				Assert.IsTrue(false);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsTrueSucceeds() {
			Assert.IsTrue(true);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsFalseFails() {
			bool threwException = DidThrowVitaUnitException(()=>{
				Assert.IsFalse(true);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertIsFalseSucceeds() {
			Assert.IsFalse(false);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualFailsForValueType() {
			bool threwException = DidThrowVitaUnitException(()=>{
				Assert.AreEqual(1, 2);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldNotThrowExceptionWhenAssertAreEqualSucceedsForValueType() {
			Assert.AreEqual(100, 100);
		}
				
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualFailsForReferenceType() {
			bool threwException = DidThrowVitaUnitException(()=>{
				object testObject1 = new object();
				object testObject2 = new object();
				Assert.AreEqual(testObject1, testObject2);
			});
			
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
			bool threwException = DidThrowVitaUnitException(()=>{
				object testObject = new object();
				Assert.AreEqual(null, testObject);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualGetsSecondParamAsNull() {
			bool threwException = DidThrowVitaUnitException(()=>{
				object testObject = new object();
				Assert.AreEqual(testObject, null);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionOnAssertFail() {
			bool threwException = DidThrowVitaUnitException(()=>{
				Assert.Fail();
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldShowMessageInVitaUnitException() {
			bool threwException = false;
			string failureMessage = "This is my test";
			
			try {
				object testObject = new object();
				Assert.AreEqual(testObject, null, failureMessage);
			} catch (VitaUnitException ex) {
				threwException = true;
				Assert.AreEqual(failureMessage, ex.Message);
			}
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsNullFails() {
			bool threwException = DidThrowVitaUnitException(()=>{
				Assert.IsNull(new object());
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsNotNullFails() {
			bool threwException = DidThrowVitaUnitException(()=>{
				object targetValue = null;
				Assert.IsNotNull(targetValue);
			});
			
			Assert.IsTrue(threwException);
		}
		
		public bool DidThrowVitaUnitException(Action action) {
			bool threwException = false;
			
			try {
				action();
			} catch (VitaUnitException) {
				threwException = true;
			}
			
			return threwException;
		}
	}
}

