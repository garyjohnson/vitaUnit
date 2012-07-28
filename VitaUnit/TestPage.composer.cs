// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    partial class TestPage
    {
        ListPanel testResultPanel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            testResultPanel = new ListPanel();
            testResultPanel.Name = "testResultPanel";

            // testResultPanel
            testResultPanel.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
            testResultPanel.SetListItemCreator(TestResultItem.Creator);

            // TestPage
            this.RootWidget.AddChildLast(testResultPanel);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    testResultPanel.SetPosition(-286, 73);
                    testResultPanel.SetSize(854, 400);
                    testResultPanel.Anchors = Anchors.None;
                    testResultPanel.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    testResultPanel.SetPosition(0, 0);
                    testResultPanel.SetSize(960, 544);
                    testResultPanel.Anchors = Anchors.None;
                    testResultPanel.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
