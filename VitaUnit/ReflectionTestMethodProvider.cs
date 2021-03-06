using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	internal class ReflectionTestMethodProvider : ITestMethodProvider
	{
		public IEnumerable<ITestMethod> GetTestMethods(Type testClass) {
			var testMethods = new List<ITestMethod>();
			
			foreach(MethodInfo method in testClass.GetMethods(BindingFlags.NonPublic|BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public|BindingFlags.InvokeMethod)) {
				foreach(Attribute innerAttribute in method.GetCustomAttributes(true)) {
					if(innerAttribute is TestMethodAttribute) {
						testMethods.Add(new TestMethod(method));
					}
				}
			}
	
			return testMethods;
		}
		
		public IEnumerable<Type> GetTestClasses(params Assembly[] assemblies) {
			var testClasses = new List<Type>();
			
			foreach(Assembly assembly in assemblies) {
				foreach(Type type in assembly.GetTypes()) {
					foreach(Attribute attribute in type.GetCustomAttributes(true)) {
						if(attribute is TestClassAttribute) {
							testClasses.Add(type);
						}
					}
				}
			}
			return testClasses;
		}

		public IMethod GetSetUpMethod(Type testClass) {
			IMethod setUpMethod = null;
			
			foreach(MethodInfo method in testClass.GetMethods(BindingFlags.NonPublic|BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public|BindingFlags.InvokeMethod)) {
				foreach(Attribute innerAttribute in method.GetCustomAttributes(true)) {
					if(innerAttribute is SetUpAttribute)
						setUpMethod = new TestMethod(method);
				}
			}
			
			return setUpMethod;
		}

		public IMethod GetTearDownMethod(Type testClass) {
			IMethod tearDownMethod = null;
			
			foreach(MethodInfo method in testClass.GetMethods(BindingFlags.NonPublic|BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public|BindingFlags.InvokeMethod)) {
				foreach(Attribute innerAttribute in method.GetCustomAttributes(true)) {
					if(innerAttribute is TearDownAttribute)
						tearDownMethod = new TestMethod(method);
				}
			}
			
			return tearDownMethod;
		}
	}
}

