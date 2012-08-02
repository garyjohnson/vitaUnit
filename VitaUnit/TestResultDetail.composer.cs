// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace VitaUnit
{
    partial class TestResultDetail
    {
        ImageBox _failureImage;
        ImageBox _successImage;
        Label _titleLabel;
        Label _messageLabel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            _failureImage = new ImageBox();
            _failureImage.Name = "_failureImage";
            _successImage = new ImageBox();
            _successImage.Name = "_successImage";
            _titleLabel = new Label();
            _titleLabel.Name = "_titleLabel";
            _messageLabel = new Label();
            _messageLabel.Name = "_messageLabel";

            // _failureImage
            _failureImage.Image = null;
            _failureImage.ImageScaleType = ImageScaleType.AspectInside;

            // _successImage
            _successImage.Image = null;
            _successImage.ImageScaleType = ImageScaleType.AspectInside;

            // _titleLabel
            _titleLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            _titleLabel.Font = new UIFont(FontAlias.System, 22, FontStyle.Regular);
            _titleLabel.LineBreak = LineBreak.Character;
            _titleLabel.VerticalAlignment = VerticalAlignment.Top;

            // _messageLabel
            _messageLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            _messageLabel.Font = new UIFont(FontAlias.System, 18, FontStyle.Regular);
            _messageLabel.LineBreak = LineBreak.Word;
            _messageLabel.VerticalAlignment = VerticalAlignment.Top;

            // TestResultDetail
            this.BackgroundColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 0f / 255f);
            this.Clip = true;
            this.AddChildLast(_failureImage);
            this.AddChildLast(_successImage);
            this.AddChildLast(_titleLabel);
            this.AddChildLast(_messageLabel);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(544, 960);
                    this.Anchors = Anchors.None;

                    _failureImage.SetPosition(-20, 0);
                    _failureImage.SetSize(200, 200);
                    _failureImage.Anchors = Anchors.None;
                    _failureImage.Visible = true;

                    _successImage.SetPosition(18, -13);
                    _successImage.SetSize(200, 200);
                    _successImage.Anchors = Anchors.None;
                    _successImage.Visible = true;

                    _titleLabel.SetPosition(66, 18);
                    _titleLabel.SetSize(214, 36);
                    _titleLabel.Anchors = Anchors.None;
                    _titleLabel.Visible = true;

                    _messageLabel.SetPosition(18, 66);
                    _messageLabel.SetSize(214, 36);
                    _messageLabel.Anchors = Anchors.None;
                    _messageLabel.Visible = true;

                    break;

                default:
                    this.SetSize(415, 544);
                    this.Anchors = Anchors.None;

                    _failureImage.SetPosition(18, 18);
                    _failureImage.SetSize(48, 48);
                    _failureImage.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                    _failureImage.Visible = false;

                    _successImage.SetPosition(18, 18);
                    _successImage.SetSize(48, 48);
                    _successImage.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                    _successImage.Visible = false;

                    _titleLabel.SetPosition(83, 18);
                    _titleLabel.SetSize(313, 59);
                    _titleLabel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Right;
                    _titleLabel.Visible = true;

                    _messageLabel.SetPosition(18, 93);
                    _messageLabel.SetSize(379, 434);
                    _messageLabel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    _messageLabel.Visible = true;

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
