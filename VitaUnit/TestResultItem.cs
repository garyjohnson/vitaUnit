using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;
using System.Reflection;
using System.IO;
using Sce.PlayStation.Core.Graphics;

namespace VitaUnit
{
	internal partial class TestResultItem : ListPanelItem
	{
		private TestResult _testResult;
		private static ImageAsset _failureImageAsset;
		private static ImageAsset _successImageAsset;
    	
		static TestResultItem() {
			_failureImageAsset = Resources.GetImageAsset("VitaUnit.assets.vitaunit_failure.png");
			_successImageAsset = Resources.GetImageAsset("VitaUnit.assets.vitaunit_success.png");
		}
		
		public TestResultItem() {
			InitializeWidget();
            
			_failureImage.Image = _failureImageAsset;
			_successImage.Image = _successImageAsset;
		}
        
		private void SetText(string text) {
			_resultLabel.Text = text;
		}
		
		public void SetTestResult(TestResult testResult) {
			_testResult = testResult;
			SetText(_testResult.MethodName);
			ShowResult(_testResult.WasSuccessful);	
		}
		
		private void ShowResult(bool isSuccess) { 
			_successImage.Visible = isSuccess;
			_failureImage.Visible = !isSuccess;
		}
		
		public void Select() {
			_resultLabel.BackgroundColor = new UIColor(0.0f, 0.0f, 1.0f, 1.0f);
		}
	}
}
