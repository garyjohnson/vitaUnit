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
        ListPanel _resultPanel;
        VitaUnit.TestResultDetail _resultDetail;
        VitaUnit.TestSummary _testSummary;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            _resultPanel = new ListPanel();
            _resultPanel.Name = "_resultPanel";
            _resultDetail = new VitaUnit.TestResultDetail();
            _resultDetail.Name = "_resultDetail";
            _testSummary = new VitaUnit.TestSummary();
            _testSummary.Name = "_testSummary";

            // _resultPanel
            _resultPanel.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
            _resultPanel.ShowEmptySection = false;
            _resultPanel.SetListItemCreator(TestResultItem.Creator);

            // TestPage
            this.RootWidget.AddChildLast(_resultPanel);
            this.RootWidget.AddChildLast(_resultDetail);
            this.RootWidget.AddChildLast(_testSummary);

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

                    _resultPanel.SetPosition(-286, 73);
                    _resultPanel.SetSize(854, 400);
                    _resultPanel.Anchors = Anchors.None;
                    _resultPanel.Visible = true;

                    _resultDetail.SetPosition(545, 0);
                    _resultDetail.SetSize(400, 200);
                    _resultDetail.Anchors = Anchors.None;
                    _resultDetail.Visible = true;

                    _testSummary.SetPosition(346, -75);
                    _testSummary.SetSize(400, 200);
                    _testSummary.Anchors = Anchors.None;
                    _testSummary.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    _resultPanel.SetPosition(0, 75);
                    _resultPanel.SetSize(545, 469);
                    _resultPanel.Anchors = Anchors.None;
                    _resultPanel.Visible = true;

                    _resultDetail.SetPosition(545, 75);
                    _resultDetail.SetSize(415, 469);
                    _resultDetail.Anchors = Anchors.None;
                    _resultDetail.Visible = true;

                    _testSummary.SetPosition(0, 0);
                    _testSummary.SetSize(960, 75);
                    _testSummary.Anchors = Anchors.None;
                    _testSummary.Visible = true;

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
