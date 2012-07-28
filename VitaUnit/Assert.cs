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
		
		private static void OnTestFailure() {
			throw new Exception();
		}
	}
}

