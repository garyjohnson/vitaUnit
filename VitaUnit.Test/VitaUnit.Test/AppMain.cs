using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace VitaUnit.Test
{
	public class AppMain
	{
		private static GraphicsContext _graphics;
		
		public static void Main(string[] args) {
#if TEST
			VitaUnitRunner.RunTests();
#else
			RunGame();
#endif
		}

		private static void RunGame() {
			Initialize();
			
			while(true) {
				SystemEvents.CheckEvents();
				Update();
				Render();
			}
		}

		public static void Initialize() {
			_graphics = new GraphicsContext();
		}

		public static void Update() {
			var gamePadData = GamePad.GetData(0);
		}

		public static void Render() {
			_graphics.SetClearColor(0.0f, 0.0f, 0.0f, 0.0f);
			_graphics.Clear();

			_graphics.SwapBuffers();
		}
	}
}
