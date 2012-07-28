// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    partial class TestResult
    {
        Label testResultLabel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            testResultLabel = new Label();
            testResultLabel.Name = "testResultLabel";

            // testResultLabel
            testResultLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            testResultLabel.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            testResultLabel.LineBreak = LineBreak.Character;

            // TestResult
            this.BackgroundColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 0f / 255f);
            this.AddChildLast(testResultLabel);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(50, 960);
                    this.Anchors = Anchors.None;

                    testResultLabel.SetPosition(79, 36);
                    testResultLabel.SetSize(214, 36);
                    testResultLabel.Anchors = Anchors.None;
                    testResultLabel.Visible = true;

                    break;

                default:
                    this.SetSize(400, 50);
                    this.Anchors = Anchors.None;

                    testResultLabel.SetPosition(0, 0);
                    testResultLabel.SetSize(400, 50);
                    testResultLabel.Anchors = Anchors.Top | Anchors.Left;
                    testResultLabel.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            testResultLabel.Text = "The test is done and stuff!";
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

        public static ListPanelItem Creator()
        {
            return new TestResult();
        }

    }
}
