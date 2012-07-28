using System;
using System.Reflection;
using System.Collections.Generic;

namespace VitaUnit
{
	public static class TestRunner
	{
		public static TestResults Run() {
			var testResults = new TestResults();
			foreach(Type testClass in GetTestClasses()) {
				object testClassInstance = TryCreateInstanceOf(testClass);
				if(testClassInstance != null)
					testResults = RunAllTestMethodsInTestClass(testClassInstance);
			}
			
			return testResults;
		}

		private static TestResults RunAllTestMethodsInTestClass(object testClassInstance) {
			var testResults = new TestResults();
			foreach(MethodInfo testMethod in GetTestMethods(testClassInstance.GetType())) {
				string className = testClassInstance.GetType().Name;
				TestResult testResult = RunTestMethod(testClassInstance, testMethod);
				testResults[className].Add(testResult);
			}
			
			return testResults;
		}

		private static object TryCreateInstanceOf(Type type) {
			object testClassInstance = null;
			try {
				testClassInstance = Activator.CreateInstance(type);
			} catch (Exception) {
			}
			
			return testClassInstance;
		}

		private static TestResult RunTestMethod(object testClassInstance, MethodInfo testMethod) {
			TestResult testResult = null;
			string className = testClassInstance.GetType().Name;
			string methodName = testMethod.Name;
			
			try {
				testMethod.Invoke(testClassInstance, null);
				testResult = new TestResult(methodName, true, "Success");
			} catch (Exception ex) {
				testResult = new TestResult(methodName, false, "Failed: " + ex.Message);
			}
			return testResult;
		}
		
		private static IEnumerable<Type> GetTestClasses() {
			var testClasses = new List<Type>();
			
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
			var testMethods = new List<MethodInfo>();
			
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

