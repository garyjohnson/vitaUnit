using System;

namespace VitaUnit
{
	public static class Assert
	{
		public static void Fail() {
			OnTestFailure("The test has failed due to an Assert.Fail().");
		}
		
		public static void IsTrue(bool condition) {
			if(!condition)
				OnTestFailure("Expected the value to be true, but was false.");
		}
		
		public static void IsFalse(bool condition) {
			if(condition)
				OnTestFailure("Expected the value to be false, but was true.");
		}
		
		public static void AreEqual(object firstValue, object secondValue) {
			AreEqual(firstValue, secondValue, string.Format("Expected the value to equal <{0}>, but was <{1}> instead.", firstValue, secondValue));
		}
		
		public static void AreEqual(object firstValue, object secondValue, string failureMessage) {
			if(firstValue == null && secondValue == null)
				return;
				
			if(firstValue == null || secondValue == null)
				OnTestFailure(failureMessage);
			
			if(!firstValue.Equals(secondValue))
				OnTestFailure(failureMessage);
		}
		
		private static void OnTestFailure(string message) {
			throw new VitaUnitException(message);
		}
	}
}

