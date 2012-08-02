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
		
		internal TestResultDetail ResultDetail {
			get{ return _resultDetail; }
			set { _resultDetail = value;}
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
			
			_testSummary.SetTestResults(_testResults);
		}
		
		private ListPanelItem OnListItemCreate() {
			var testResultItem = new TestResultItem();
			testResultItem.TouchEventReceived += HandleTestResultItemTouchEventReceived;
			return testResultItem;
		}

		void HandleTestResultItemTouchEventReceived(object sender, TouchEventArgs e) {
			TestResultItem item = sender as TestResultItem;
			if(item != null) {
				if(e.TouchEvents.PrimaryTouchEvent.Type == TouchEventType.Up) {
					OnTestResultItemPressed(item);
				}
			}
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
			if(resultItem != null)
				_resultDetail.SetTestResult(resultItem.TestResult);
		}
	}
}
