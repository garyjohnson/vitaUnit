using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.UI;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;

namespace VitaUnit
{
	public static class VitaUnitRunner
	{
		private	static GraphicsContext _graphics;
		
		public static void RunTests() {
			_graphics = new GraphicsContext();
			RunTests(_graphics);
		}
		
		public static void RunTests(GraphicsContext graphicsContext) {
			Initialize(graphicsContext);
			
			while(true) {
				Update();
				Render();
			}
		}

		private static void Initialize(GraphicsContext graphicsContext) {
			_graphics = graphicsContext;
			UISystem.Initialize(_graphics);	
			UISystem.SetScene(new TestPage());
		}
		
		private static void Update() {
			SystemEvents.CheckEvents();
			UISystem.Update(Touch.GetData(0));
		}
		
		private static void Render() {
			_graphics.SetClearColor(1.0f, 1.0f, 1.0f, 1.0f);
			_graphics.Clear();
			UISystem.Render();
			_graphics.SwapBuffers();
		}
	}
}

