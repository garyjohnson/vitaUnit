using System;

namespace VitaUnit
{
	public static class Assert
	{
		public static void Fail() {
			OnTestFailure();
		}
		
		public static void IsTrue(bool condition) {
			if(!condition)
				OnTestFailure();
		}
		
		public static void IsFalse(bool condition) {
			if(condition)
				OnTestFailure();
		}
		
		public static void AreEqual(object firstValue, object secondValue) {
			AreEqual(firstValue, secondValue, null);
		}
		
		public static void AreEqual(object firstValue, object secondValue, string failureMessage) {
			if(firstValue == null && secondValue == null)
				return;
				
			if(firstValue == null || secondValue == null)
				OnTestFailure(failureMessage);
			
			if(!firstValue.Equals(secondValue))
				OnTestFailure(failureMessage);
		}
		
		private static void OnTestFailure() {
			OnTestFailure(null);
		}
		
		private static void OnTestFailure(string message) {
			throw new VitaUnitException(message);
		}
	}
}

