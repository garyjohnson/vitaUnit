using System;
using System.Threading;

namespace VitaUnit.Test {

	[TestClass]
	public class AssertTest {
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsTrueFails() {
			bool threwException = DidThrowVitaUnitException(() => {
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
			bool threwException = DidThrowVitaUnitException(() => {
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
			bool threwException = DidThrowVitaUnitException(() => {
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
			bool threwException = DidThrowVitaUnitException(() => {
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
			bool threwException = DidThrowVitaUnitException(() => {
				object testObject = new object();
				Assert.AreEqual(null, testObject);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertAreEqualGetsSecondParamAsNull() {
			bool threwException = DidThrowVitaUnitException(() => {
				object testObject = new object();
				Assert.AreEqual(testObject, null);
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionOnAssertFail() {
			bool threwException = DidThrowVitaUnitException(() => {
				Assert.Fail();
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldShowMessageInVitaUnitException() {
			string expectedMessage = "This is my test";
			string actualMessage = GetFailureMessage(() => {
				object testObject = new object();
				Assert.AreEqual(testObject, null, expectedMessage);
			});
		
			Assert.AreEqual(expectedMessage, actualMessage);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsNullFails() {
			bool threwException = DidThrowVitaUnitException(() => {
				Assert.IsNull(new object());
			});
			
			Assert.IsTrue(threwException);
		}
		
		[TestMethod]
		public void ShouldPassFailureMessageOnIsNullFailure() {
			string expectedMessage = "This is my failure message.";
			string actualMessage = GetFailureMessage(() => {
				Assert.IsNull(new object(), expectedMessage);
			});
			
			Assert.AreEqual(expectedMessage, actualMessage);
		}
		
		[TestMethod]
		public void ShouldPassFailureMessageOnIsNotNullFailure() {
			string expectedMessage = "This is my failure message.";
			string actualMessage = GetFailureMessage(() => {
				Assert.IsNotNull(null, expectedMessage);
			});
			
			Assert.AreEqual(expectedMessage, actualMessage);
		}
		
		[TestMethod]
		public void ShouldThrowVitaUnitExceptionWhenAssertIsNotNullFails() {
			bool threwException = DidThrowVitaUnitException(() => {
				object targetValue = null;
				Assert.IsNotNull(targetValue);
			});
			
			Assert.IsTrue(threwException);
		}
		
		public bool DidThrowVitaUnitException(Action action) {
			bool threwException = false;
			
			try {
				action();
			} catch(VitaUnitException) {
				threwException = true;
			}
			
			return threwException;
		}
		
		public string GetFailureMessage(Action action) {
			string failureMessage = null;
			
			try {
				action();
			} catch(VitaUnitException ex) {
				failureMessage = ex.Message;
			}
			
			return failureMessage;
		}
	}
}

