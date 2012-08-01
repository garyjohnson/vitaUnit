using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
	internal partial class TestPage : Scene
	{
		private TestResults _testResults;
		private readonly ListSectionCollection _sections = new ListSectionCollection();
		private ITestRunner _testRunner;
        
		public TestPage() {
			_testRunner = VitaUnitRunner.GetService<ITestRunner>();
			InitializeWidget();
			InitializeTestResultPanel();
		}
		
		internal Label TestResultDetailLabel {
			get{ return this._resultLabel;}
		}

		private void InitializeTestResultPanel() {
			_resultPanel.SetListItemCreator(OnListItemCreate);
			_resultPanel.SetListItemUpdater(OnListItemUpdate);
			_resultPanel.Sections = _sections;
		}

		protected override void OnShown() {
			base.OnShown();
			_testResults = _testRunner.Run(VitaUnitRunner.TestAssemblies);
			
			foreach(string key in _testResults.Keys) {
				_resultPanel.Sections.Add(new ListSection(key, _testResults[key].Count));
			}	
		}
		
		private ListPanelItem OnListItemCreate() {
			var testResultItem = new TestResultItem();
			return testResultItem;
		}
		
		private void OnListItemUpdate(ListPanelItem listItem) {
			TestResultItem testResultItem = (TestResultItem)listItem;
			TestResult result = GetTestResultAtIndex(listItem.SectionIndex, listItem.IndexInSection);
			testResultItem.SetTestResult(result);
		}

		private TestResult GetTestResultAtIndex(int sectionIndex, int indexInSection) {
			string className = _sections[sectionIndex].Title;
			return _testResults[className][indexInSection];
		}
		
		internal void OnTestResultItemPressed(TestResultItem resultItem) {
			_resultLabel.Text = resultItem.TestResult.Message;
		}
	}
}
