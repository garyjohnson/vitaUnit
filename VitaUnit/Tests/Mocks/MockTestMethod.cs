using System;

namespace VitaUnit
{
	public class MockTestMethod : ITestMethod
	{
		public bool WasInvokeCalled { get; private set; }

		public void Invoke(object instance) {
			WasInvokeCalled = true;
			
			if(OnInvoke != null)
				OnInvoke(this, EventArgs.Empty);
		}

		public bool IsUIThreadTest {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}
		
		public event EventHandler OnInvoke;
		
		public void Reset() {
			WasInvokeCalled = false;
		}
	}
}

