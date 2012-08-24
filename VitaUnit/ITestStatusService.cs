using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MonoDevelop.AddIn.VitaUnit
{
	[ServiceContract]
	public interface ITestStatusService
	{
		[OperationContract]
		[WebGet]
		string TestRunCompleted();
	}
}

