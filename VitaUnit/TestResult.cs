using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    public partial class TestResult : ListPanelItem
    {
        public TestResult()
        {
            InitializeWidget();
        }
        
		public Label ResultLabel {
			get { return testResultLabel; }
		}
    }
}
