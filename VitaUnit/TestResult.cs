using System;

namespace VitaUnit
{
	internal class TestResult
	{
		public TestResult(string methodName, bool wasSuccessful, string message) {
			MethodName = methodName;
			WasSuccessful = wasSuccessful;
			Message = message;
		}
		
		public string MethodName { get; private set; }
		public bool WasSuccessful { get; private set; }
		public string Message { get; private set; }
	}
}

