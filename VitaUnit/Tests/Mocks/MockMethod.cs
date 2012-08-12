using System;

namespace VitaUnit
{
	public class MockMethod : IMethod
	{
		public event EventHandler OnInvoke;
		
		private void FireOnInvoke() {
			if(OnInvoke != null)
				OnInvoke(this, EventArgs.Empty);
		}

		public void Invoke(object instance) {
			FireOnInvoke();
		}
	}
}

