using System;
using System.Reflection;

namespace VitaUnit
{
	internal interface ITestRunner
	{
		TestResults Run(params Assembly[] testAssemblies);
	}
}

