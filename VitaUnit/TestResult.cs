using System;

namespace VitaUnit
{
	internal class TestResult
	{
		public TestResult(string className, string methodName, bool wasSuccessful, string message) :
			this(className, methodName, wasSuccessful, message, null) {
		}
		
		public TestResult(string className, string methodName, bool wasSuccessful, string message, Exception exception) {
			ClassName = className;
			MethodName = methodName;
			WasSuccessful = wasSuccessful;
			Message = message;
				
			string exceptionMessage = "";
			if(exception != null) {
				if(exception.InnerException != null) { 
					exceptionMessage += exception.InnerException.Message;
				} else {
					exceptionMessage += exception.Message;
				}
				
				exceptionMessage += Environment.NewLine;
				exceptionMessage += Environment.NewLine;
				exceptionMessage += exception.StackTrace;
			}
			
			Message += exceptionMessage;
		}
		
		public string ClassName { get; private set; }
		public string MethodName { get; private set; }
		public bool WasSuccessful { get; private set; }
		public string Message { get; private set; }
	}
}

