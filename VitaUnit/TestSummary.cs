using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    internal partial class TestSummary : Panel
    {
        public TestSummary()
        {
            InitializeWidget();
        }
        
		public void SetTestResults(TestResults results) {
			int passedTests = 0;
			int failedTests = 0;
			
			foreach(var resultList in results.Values) {
				foreach(var result in resultList) {
					if(result.WasSuccessful) {
						passedTests++;
					} else {
						failedTests++;
					}
				}
			}
			
			int totalTests = passedTests + failedTests;
			
			_passingTestLabel.Text = string.Format("{0}/{1} passed", passedTests, totalTests);
			_failedTestLabel.Text = string.Format("{0}/{1} failed", failedTests, totalTests);
		}
    }
}
