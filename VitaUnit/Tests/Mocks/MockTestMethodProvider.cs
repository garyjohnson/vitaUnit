using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	internal class MockTestMethodProvider : ITestMethodProvider
	{
		public IEnumerable<Type> TestClasses { get; set; }

		public IEnumerable<ITestMethod> TestMethods { get; set; }
		
		public IMethod SetUpMethod { get; set; }
		public IMethod TearDownMethod { get; set; }
		
		public IEnumerable<ITestMethod> GetTestMethods(Type testClass) {
			return TestMethods;
		}

		public IEnumerable<Type> GetTestClasses(params Assembly[] assemblies) {
			return TestClasses;
		}

		public IMethod GetSetUpMethod(Type testClass) {
			return SetUpMethod;
		}

		public IMethod GetTearDownMethod(Type testClass) {
			return TearDownMethod;
		}
	}
}

