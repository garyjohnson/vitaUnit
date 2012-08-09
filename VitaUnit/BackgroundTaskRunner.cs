using System;
using System.ComponentModel;

namespace VitaUnit
{
	internal class BackgroundTaskRunner : ITaskRunner
	{
		private BackgroundWorker _testRunner;
		private RunTaskDelegate _task;
		private TaskCompletedDelegate _onTaskCompleted;
		
		public BackgroundTaskRunner() {
			_testRunner = new BackgroundWorker();
			_testRunner.DoWork += OnTestRunnerDoWork;
			_testRunner.RunWorkerCompleted += OnTestRunnerCompleted;
			_testRunner.WorkerSupportsCancellation = false;
			_testRunner.WorkerReportsProgress = false;
		}
		
		public void RunTask(object state, RunTaskDelegate task, TaskCompletedDelegate onTaskCompleted) {
			_task = task;
			_onTaskCompleted = onTaskCompleted;
			_testRunner.RunWorkerAsync(state);
		}

		private void OnTestRunnerDoWork(object sender, DoWorkEventArgs e) {
			e.Result = _task(e.Argument);
		}
		
		private void OnTestRunnerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			_onTaskCompleted(e.Result);
		}
	}
}

