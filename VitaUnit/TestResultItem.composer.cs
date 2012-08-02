// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    partial class TestResultItem
    {
        Label _resultLabel;
        ImageBox _failureImage;
        ImageBox _successImage;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            _resultLabel = new Label();
            _resultLabel.Name = "_resultLabel";
            _failureImage = new ImageBox();
            _failureImage.Name = "_failureImage";
            _successImage = new ImageBox();
            _successImage.Name = "_successImage";

            // _resultLabel
            _resultLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            _resultLabel.Font = new UIFont(FontAlias.System, 24, FontStyle.Regular);
            _resultLabel.LineBreak = LineBreak.Word;

            // _failureImage
            _failureImage.Image = null;
            _failureImage.ImageScaleType = ImageScaleType.AspectInside;

            // _successImage
            _successImage.Image = null;
            _successImage.ImageScaleType = ImageScaleType.AspectInside;

            // TestResultItem
            this.BackgroundColor = new UIColor(1f / 255f, 1f / 255f, 1f / 255f, 2f / 255f);
            this.AddChildLast(_resultLabel);
            this.AddChildLast(_failureImage);
            this.AddChildLast(_successImage);

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

                    _resultLabel.SetPosition(79, 36);
                    _resultLabel.SetSize(214, 36);
                    _resultLabel.Anchors = Anchors.None;
                    _resultLabel.Visible = true;

                    _failureImage.SetPosition(-46, -66);
                    _failureImage.SetSize(200, 200);
                    _failureImage.Anchors = Anchors.None;
                    _failureImage.Visible = true;

                    _successImage.SetPosition(-72, -71);
                    _successImage.SetSize(200, 200);
                    _successImage.Anchors = Anchors.None;
                    _successImage.Visible = true;

                    break;

                default:
                    this.SetSize(400, 70);
                    this.Anchors = Anchors.None;

                    _resultLabel.SetPosition(76, 11);
                    _resultLabel.SetSize(323, 48);
                    _resultLabel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    _resultLabel.Visible = true;

                    _failureImage.SetPosition(19, 19);
                    _failureImage.SetSize(32, 32);
                    _failureImage.Anchors = Anchors.None;
                    _failureImage.Visible = false;

                    _successImage.SetPosition(19, 19);
                    _successImage.SetSize(32, 32);
                    _successImage.Anchors = Anchors.None;
                    _successImage.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            _resultLabel.Text = "TestMethodName";
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
            return new TestResultItem();
        }

    }
}
