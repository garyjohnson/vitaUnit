using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
	public partial class TestPage : Scene
	{
		private TestResults _testResults;
		private readonly ListSectionCollection _sections = new ListSectionCollection();
        
		public TestPage() {
			InitializeWidget();
			InitializeTestResultPanel();
		}

		private void InitializeTestResultPanel() {
			testResultPanel.SetListItemCreator(OnListItemCreate);
			testResultPanel.SetListItemUpdater(OnListItemUpdate);
			testResultPanel.Sections = _sections;
		}

		protected override void OnShown() {
			base.OnShown();
			_testResults = TestRunner.Run();
			
			foreach(string key in _testResults.Keys) {
				testResultPanel.Sections.Add(new ListSection(key, _testResults[key].Count));
			}	
		}
		
		private ListPanelItem OnListItemCreate() {
			return new TestResultItem();
		}
		
		private void OnListItemUpdate(ListPanelItem listItem) {
			TestResultItem testResult = (TestResultItem)listItem;
			string className = _sections[listItem.SectionIndex].Title;
			TestResult result = _testResults[className][testResult.Index];
			testResult.SetText(result.MethodName + " " + result.Message);
		}
	}
}
