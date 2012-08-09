using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.UI;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using System.Reflection;

namespace VitaUnit
{
	public static class VitaUnitRunner
	{
		private	static GraphicsContext _graphics;
		private static readonly IocContainer _container = new IocContainer();
		private static Assembly[] _testAssemblies;
		
		public static void RunTests(params Assembly[] testAssemblies) {
			_graphics = new GraphicsContext();
			RunTests(_graphics, testAssemblies);
		}
		
		public static void RunTests(GraphicsContext graphicsContext, params Assembly[] testAssemblies) {
			_testAssemblies = testAssemblies;
			Initialize(graphicsContext);
			
			while(true) {
				Update();
				Render();
			}
		}
		
		public static Assembly[] TestAssemblies {
			get{ return _testAssemblies;}
		}

		private static void Initialize(GraphicsContext graphicsContext) {
			_graphics = graphicsContext;
			InitializeServices();
			UISystem.Initialize(_graphics);	
			UISystem.SetScene(new TestPage());
		}
		  
		private static void InitializeServices() {
			RegisterService<ITaskRunner, BackgroundTaskRunner>();
			RegisterService<ITestMethodProvider, ReflectionTestMethodProvider>();
			RegisterService<ITestRunner, TestRunner>();
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
		 
		internal static void RegisterService<T>(T service) where T : class {
			_container.RegisterDependency<T>(service);
		}

		internal static void RegisterService<T, U>()
            where T : class
            where U : class {
			_container.RegisterDependency<T, U>();
		}

		internal static T GetService<T>() where T : class {
			return _container.GetDependency<T>();
		}
	}
}

