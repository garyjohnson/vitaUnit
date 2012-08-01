using System;

namespace VitaUnit
{
	public class VitaUnitException : Exception
	{
		public VitaUnitException() {
		}
		
		public VitaUnitException(string message) : base(message) {
		}
	}
}

