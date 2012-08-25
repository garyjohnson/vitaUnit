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
				return _methodInfo.GetCustomAttributes(typeof(IgnoreAttribute), false).Any();
			}
		}
		
		public bool IsUIThreadTest {
			get {
				return _methodInfo.GetCustomAttributes(typeof(RunOnUIThreadAttribute), false).Any();
			}
		}
		
		public string Name {
			get {
				return _methodInfo.Name;
			}
		}
	}
}

