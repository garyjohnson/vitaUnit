using System;

namespace VitaUnit
{
	internal interface ITestMethod
	{
		void Invoke(object instance);

		bool IsUIThreadTest{ get; }

		string Name{ get; }
	}
}

