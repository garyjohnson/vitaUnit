using System;

namespace VitaUnit
{
	internal class MockTestResultDetail : TestResultDetail
	{
		public TestResult TestResult { get; private set; }
	
		public override void SetTestResult(TestResult result) {
			base.SetTestResult(result);
		}
		
		public void Reset() {
			TestResult = null;
		}
	}
}

