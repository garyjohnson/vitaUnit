using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    internal partial class TestResultDetail : Panel
    {
		private static ImageAsset _failureImageAsset;
		private static ImageAsset _successImageAsset;
    	
		static TestResultDetail() {
			_failureImageAsset = Resources.GetImageAsset("VitaUnit.assets.vitaunit_failure.png");
			_successImageAsset = Resources.GetImageAsset("VitaUnit.assets.vitaunit_success.png");
		}
		
        public TestResultDetail()
        {
            InitializeWidget();
			_failureImage.Image = _failureImageAsset;
			_successImage.Image = _successImageAsset;
        }
        
		public virtual void SetTestResult(TestResult result) {
			_titleLabel.Text = result.MethodName;
			_messageLabel.Text = result.Message;
			ShowResult(result.WasSuccessful);
		}
		
		private void ShowResult(bool isSuccess) { 
			_successImage.Visible = isSuccess;
			_failureImage.Visible = !isSuccess;
		}
    }
}
