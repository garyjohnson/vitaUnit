using System;

namespace VitaUnit
{
	internal interface ITestMethod : IMethod
	{
		bool IsUIThreadTest{ get; }
		bool Ignore { get; }
		string Name{ get; }
	}
}

