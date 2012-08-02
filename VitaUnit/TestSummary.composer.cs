// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    partial class TestSummary
    {
        Label _passingTestLabel;
        Label _failedTestLabel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            _passingTestLabel = new Label();
            _passingTestLabel.Name = "_passingTestLabel";
            _failedTestLabel = new Label();
            _failedTestLabel.Name = "_failedTestLabel";

            // _passingTestLabel
            _passingTestLabel.TextColor = new UIColor(0f / 255f, 119f / 255f, 0f / 255f, 255f / 255f);
            _passingTestLabel.Font = new UIFont(FontAlias.System, 44, FontStyle.Bold);
            _passingTestLabel.LineBreak = LineBreak.Character;

            // _failedTestLabel
            _failedTestLabel.TextColor = new UIColor(147f / 255f, 0f / 255f, 3f / 255f, 255f / 255f);
            _failedTestLabel.Font = new UIFont(FontAlias.System, 44, FontStyle.Bold);
            _failedTestLabel.LineBreak = LineBreak.Character;
            _failedTestLabel.HorizontalAlignment = HorizontalAlignment.Right;

            // TestSummary
            this.BackgroundColor = new UIColor(243f / 255f, 243f / 255f, 243f / 255f, 255f / 255f);
            this.Clip = true;
            this.AddChildLast(_passingTestLabel);
            this.AddChildLast(_failedTestLabel);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(575, 960);
                    this.Anchors = Anchors.None;

                    _passingTestLabel.SetPosition(7, 21);
                    _passingTestLabel.SetSize(214, 36);
                    _passingTestLabel.Anchors = Anchors.None;
                    _passingTestLabel.Visible = true;

                    _failedTestLabel.SetPosition(7, 21);
                    _failedTestLabel.SetSize(214, 36);
                    _failedTestLabel.Anchors = Anchors.None;
                    _failedTestLabel.Visible = true;

                    break;

                default:
                    this.SetSize(960, 75);
                    this.Anchors = Anchors.None;

                    _passingTestLabel.SetPosition(20, 0);
                    _passingTestLabel.SetSize(460, 75);
                    _passingTestLabel.Anchors = Anchors.Top | Anchors.Left;
                    _passingTestLabel.Visible = true;

                    _failedTestLabel.SetPosition(480, 0);
                    _failedTestLabel.SetSize(460, 75);
                    _failedTestLabel.Anchors = Anchors.Top | Anchors.Right;
                    _failedTestLabel.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
        }

        public void InitializeDefaultEffect()
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        public void StartDefaultEffect()
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
