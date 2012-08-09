using System;

namespace VitaUnit
{
	internal class TestResult
	{
		public TestResult(string className, string methodName, bool wasSuccessful, string message) {
			ClassName = className;
			MethodName = methodName;
			WasSuccessful = wasSuccessful;
			Message = message;
		}
		
		public string ClassName { get; private set; }
		public string MethodName { get; private set; }
		public bool WasSuccessful { get; private set; }
		public string Message { get; private set; }
	}
}

