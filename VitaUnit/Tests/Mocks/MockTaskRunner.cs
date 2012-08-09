using System;

namespace VitaUnit
{
	internal class MockTaskRunner : ITaskRunner
	{
		public void RunTask(object state, RunTaskDelegate task, TaskCompletedDelegate onTaskCompleted) {
			object result = task(state);
			onTaskCompleted(result);
		}
	}
}

