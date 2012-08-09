using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	internal class MockTestMethodProvider : ITestMethodProvider
	{
		public IEnumerable<Type> TestClasses { get; set; }
		public IEnumerable<ITestMethod> TestMethods { get; set; }
		
		public IEnumerable<ITestMethod> GetTestMethods(Type testClass) {
			return TestMethods;
		}

		public IEnumerable<Type> GetTestClasses(params Assembly[] assemblies) {
			return TestClasses;
		}
	}
}

