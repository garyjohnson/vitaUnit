using System;

namespace VitaUnit
{
	public static class Assert
	{
		public static void IsTrue(bool condition) {
			if(!condition)
				OnTestFailure();
		}
		
		public static void IsFalse(bool condition) {
			if(condition)
				OnTestFailure();
		}
		
		public static void AreEqual(object firstValue, object secondValue) {
			IsTrue(firstValue.Equals(secondValue));
		}
		
		private static void OnTestFailure() {
			throw new VitaUnitException();
		}
	}
}

