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
		private List<string> _testResults;
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
			testResultPanel.Sections.Add(new ListSection("Test", _testResults.Count));
		}
		
		private ListPanelItem OnListItemCreate() {
			return new TestResultItem();
		}
		
		private void OnListItemUpdate(ListPanelItem listItem) {
			TestResultItem testResult = (TestResultItem)listItem;
			testResult.SetText(_testResults[testResult.Index]);
		}
	}
}
