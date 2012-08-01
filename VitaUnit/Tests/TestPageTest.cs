using System;

namespace VitaUnit.Test
{
	[TestClass]
	public class TestPageTest
	{
		[TestMethod]
		public void ShouldUpdateDetailLabelOnTestResultItemPress() {
			string expectedText = "This is my test message";
			
			TestPage testPage = new TestPage();
			TestResultItem resultItem = new TestResultItem();
			resultItem.SetTestResult(new TestResult("Test", true, expectedText));
			testPage.OnTestResultItemPressed(resultItem);
			
			string actualText = testPage.TestResultDetailLabel.Text;
			
			Assert.AreEqual(expectedText, actualText, "Expected the result label to be updated based on the pressed item.");
		}
	}
}

