using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	public static class TestRunner
	{
		public static List<string> Run() {
			List<string> testResults = new List<string>();
			foreach(Type testClass in GetTestClasses()) {
				object testClassInstance = Activator.CreateInstance(testClass);
				foreach(MethodInfo testMethod in GetTestMethods(testClass)) {
					String testResult = RunTestMethod(testClassInstance, testMethod);
					testResults.Add(testResult);
				}
			}
			
			return testResults;
		}

		private static string RunTestMethod(object testClassInstance, MethodInfo testMethod) {
			String testResult;
			try {
				testMethod.Invoke(testClassInstance, null);
				testResult = testClassInstance.GetType().Name + "." + testMethod.Name + " ran successfully";
			} catch (Exception) {
				testResult = testClassInstance.GetType().Name + "." + testMethod.Name + " failed";
			}
			return testResult;
		}
		
		private static IEnumerable<Type> GetTestClasses() {
			List<Type> testClasses = new List<Type>();
			
			foreach(Type type in Assembly.GetEntryAssembly().GetTypes()) {
				foreach(Attribute attribute in type.GetCustomAttributes(true)) {
					if(attribute is TestClassAttribute) {
						testClasses.Add(type);
					}
				}
			}
			return testClasses;
		}
		
		private static IEnumerable<MethodInfo> GetTestMethods(Type testClass) {
			List<MethodInfo> testMethods = new List<MethodInfo>();
			
			foreach(MethodInfo method in testClass.GetMethods(BindingFlags.NonPublic|BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public|BindingFlags.InvokeMethod)) {
				foreach(Attribute innerAttribute in method.GetCustomAttributes(true)) {
					if(innerAttribute is TestMethodAttribute) {
						testMethods.Add(method);
					}
				}
			}
	
			return testMethods;
		}
	}
}

