using System;
using System.ServiceModel;
using System.Diagnostics;

namespace MonoDevelop.AddIn.VitaUnit
{
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
	public class TestStatusService : ITestStatusService
	{
		public string TestRunCompleted() {
			foreach(Process process in Process.GetProcessesByName("psm")){
				process.CloseMainWindow();
				process.Close();
			}
			
			return "Hello world!";
		}
	}
}

