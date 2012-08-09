using System;
using System.Reflection;

namespace VitaUnit
{
	internal interface ITestRunner
	{
		void Run(params Assembly[] testAssemblies);
		event EventHandler<EventArgs<TestResult>> SingleTestCompleted;
		event EventHandler<EventArgs<TestResults>> AllTestsCompleted;
	}
}

