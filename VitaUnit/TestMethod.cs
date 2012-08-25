using System;
using System.Reflection;
using System.Linq;

namespace VitaUnit {

	internal class TestMethod : ITestMethod {
		MethodInfo _methodInfo;
		
		public TestMethod(MethodInfo methodInfo) {
			_methodInfo = methodInfo;
		}
		
		public void Invoke(object instance) {
			_methodInfo.Invoke(instance, null);
		}
		
		public bool Ignore {
			get {
				return HasAttribute<IgnoreAttribute>();
			}
		}
		
		public bool IsUIThreadTest {
			get {
				return HasAttribute<RunOnUIThreadAttribute>();
			}
		}
		
		public string Name {
			get {
				return _methodInfo.Name;
			}
		}
		
		private bool HasAttribute<T>() where T : Attribute {
			return _methodInfo.GetCustomAttributes(typeof(T), false).Any();
		}
	}
}

