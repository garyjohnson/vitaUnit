using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Core;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;

namespace MonoDevelop.AddIn.VitaUnit
{
	public class RunTestsHandler : CommandHandler
	{
		protected override void Run ()
		{
			base.Run ();
			Console.WriteLine ("Testing!");
			string currentConfig = IdeApp.Workspace.ActiveConfigurationId;
			foreach (string config in IdeApp.Workspace.GetConfigurations()) {
				if (config.Equals ("Test", StringComparison.InvariantCultureIgnoreCase))
					IdeApp.Workspace.ActiveConfigurationId = config;
			}
			IAsyncOperation async = IdeApp.ProjectOperations.Execute (IdeApp.ProjectOperations.CurrentSelectedBuildTarget);
			async.Completed += (op) => {
				IdeApp.Workspace.ActiveConfigurationId = currentConfig;
			};
			
			Uri baseAddress = new Uri ("http://localhost:1234");
			ServiceHost serviceHost = new ServiceHost (typeof(TestStatusService), baseAddress);
			
			WebHttpBinding binding = new WebHttpBinding ();
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior ();
			smb.HttpGetEnabled = true;
			serviceHost.Description.Behaviors.Add (smb);
			
			ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint (typeof(ITestStatusService), binding, baseAddress);
			endpoint.Behaviors.Add (new WebHttpBehavior());
			serviceHost.BeginOpen (null, null);
			
			
		}
		
		protected override void Update (CommandInfo info)
		{
			base.Update (info);
		}
	}	
}

