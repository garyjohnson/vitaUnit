using System;

namespace VitaUnit
{
	internal interface ITaskRunner
	{
		void RunTask(object state, RunTaskDelegate task, TaskCompletedDelegate onTaskCompleted);
	}
}

