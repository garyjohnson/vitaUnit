using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    public partial class TestResultItem : ListPanelItem
    {
        public TestResultItem()
        {
            InitializeWidget();
        }
        
        public void SetText(string text) {
        	testResultLabel.Text = text;
		}
    }
}
