using System;

namespace VitaUnit.Test
{
	[TestClass]
	public class TestPageTest
	{
		[TestMethod]
		public void ShouldUpdateDetailsOnTestResultItemPress() {
			TestPage testPage = new TestPage();
			var testResultDetail = new MockTestResultDetail();
			testPage.ResultDetail = testResultDetail;
			
			TestResultItem resultItem = new TestResultItem();
			var expectedResult = new TestResult("", true, "");
			resultItem.SetTestResult(expectedResult);
			testPage.OnTestResultItemPressed(resultItem);
			
			Assert.AreEqual(expectedResult, testResultDetail.TestResult);
		}
	}
}

