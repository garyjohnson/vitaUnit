using System;

namespace VitaUnit
{
	internal class MockTestRunner : ITestRunner
	{
		public MockTestRunner() {
		}

		public event EventHandler<EventArgs<TestResult>> SingleTestCompleted;

		public event EventHandler<EventArgs<TestResults>> AllTestsCompleted;

		public void Run(params System.Reflection.Assembly[] testAssemblies) {
		}
		
		public void FireSingleTestCompleted() {
			SingleTestCompleted(this, new EventArgs<TestResult>(null));
		}
		
		public void FireAllTestsCompleted() {
			AllTestsCompleted(this, new EventArgs<TestResults>(null));
		}
	}
}

