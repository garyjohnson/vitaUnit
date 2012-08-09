using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	internal interface ITestMethodProvider
	{
		IEnumerable<ITestMethod> GetTestMethods(Type testClass);
		IEnumerable<Type> GetTestClasses(params Assembly[] assemblies);
	}
}

