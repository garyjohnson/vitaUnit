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
        Label _resultLabel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            _resultPanel = new ListPanel();
            _resultPanel.Name = "_resultPanel";
            _resultLabel = new Label();
            _resultLabel.Name = "_resultLabel";

            // _resultPanel
            _resultPanel.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
            _resultPanel.ShowEmptySection = false;
            _resultPanel.SetListItemCreator(TestResultItem.Creator);

            // _resultLabel
            _resultLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            _resultLabel.Font = new UIFont(FontAlias.System, 24, FontStyle.Regular);
            _resultLabel.LineBreak = LineBreak.Word;
            _resultLabel.VerticalAlignment = VerticalAlignment.Top;

            // TestPage
            this.RootWidget.AddChildLast(_resultPanel);
            this.RootWidget.AddChildLast(_resultLabel);

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

                    _resultLabel.SetPosition(598, 299);
                    _resultLabel.SetSize(214, 36);
                    _resultLabel.Anchors = Anchors.None;
                    _resultLabel.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    _resultPanel.SetPosition(0, 0);
                    _resultPanel.SetSize(545, 544);
                    _resultPanel.Anchors = Anchors.None;
                    _resultPanel.Visible = true;

                    _resultLabel.SetPosition(545, 0);
                    _resultLabel.SetSize(415, 544);
                    _resultLabel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    _resultLabel.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            _resultLabel.Text = "Label";
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
