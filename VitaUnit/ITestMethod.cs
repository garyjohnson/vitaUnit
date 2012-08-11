using System;

namespace VitaUnit
{
	internal interface ITestMethod : IMethod
	{
		bool IsUIThreadTest{ get; }

		string Name{ get; }
	}
}

