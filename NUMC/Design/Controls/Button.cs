﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    [DefaultEvent("Click")]
    public class Button : System.Windows.Forms.Button
    {
        #region Field Region

        private BrightButtonStyle _style = BrightButtonStyle.Normal;
        private bool _isDefault;
        private bool _spacePressed;

        private readonly int _padding = Consts.Padding / 2;
        private int _imagePadding = 5; // Consts.Padding / 2

        #endregion Field Region

        #region Designer Property Region

        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines the style of the button.")]
        [DefaultValue(BrightButtonStyle.Normal)]
        public BrightButtonStyle ButtonStyle
        {
            get { return _style; }
            set
            {
                _style = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines the amount of padding between the image and text.")]
        [DefaultValue(5)]
        public int ImagePadding
        {
            get { return _imagePadding; }
            set
            {
                _imagePadding = value;
                Invalidate();
            }
        }

        #endregion Designer Property Region

        #region Code Property Region

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoEllipsis
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlState ButtonState { get; private set; } = ControlState.Normal;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool FlatAppearance
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment TextAlign
        {
            get { return base.TextAlign; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseCompatibleTextRendering
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseVisualStyleBackColor
        {
            get { return false; }
        }

        #endregion Code Property Region

        #region Constructor Region

        public Button()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            base.UseVisualStyleBackColor = false;
            base.UseCompatibleTextRendering = false;

            SetButtonState(ControlState.Normal);
            Padding = new Padding(_padding);
        }

        #endregion Constructor Region

        #region Method Region

        private void SetButtonState(ControlState buttonState)
        {
            if (ButtonState != buttonState)
            {
                ButtonState = buttonState;
                Invalidate();
            }
        }

        #endregion Method Region

        #region Event Handler Region

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            var form = FindForm();
            if (form != null)
            {
                if (form.AcceptButton == this)
                    _isDefault = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_spacePressed)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                    SetButtonState(ControlState.Pressed);
                else
                    SetButtonState(ControlState.Hover);
            }
            else
            {
                SetButtonState(ControlState.Hover);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ClientRectangle.Contains(e.Location))
                return;

            SetButtonState(ControlState.Pressed);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_spacePressed)
                return;

            SetButtonState(ControlState.Normal);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (_spacePressed)
                return;

            SetButtonState(ControlState.Normal);
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);

            if (_spacePressed)
                return;

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(ControlState.Normal);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            _spacePressed = false;

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(ControlState.Normal);
            else
                SetButtonState(ControlState.Hover);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space)
            {
                _spacePressed = true;
                SetButtonState(ControlState.Pressed);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Space)
            {
                _spacePressed = false;

                var location = Cursor.Position;

                if (!ClientRectangle.Contains(location))
                    SetButtonState(ControlState.Normal);
                else
                    SetButtonState(ControlState.Hover);
            }
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(value);

            if (!DesignMode)
                return;

            _isDefault = value;
            Invalidate();
        }

        #endregion Event Handler Region

        #region Paint Region

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            var textColor = Styles.Control.Color;
            var borderColor = Styles.Control.SelectionBackgroundColor;
            var fillColor = _isDefault ? Styles.Button.EmphaBackgroundColor : Styles.Button.BackgroundColor;

            if (Enabled)
            {
                if (ButtonStyle == BrightButtonStyle.Normal)
                {
                    if (Focused && TabStop)
                        borderColor = Styles.Control.EmphaColor;

                    switch (ButtonState)
                    {
                        case ControlState.Hover:
                            fillColor = _isDefault ? Styles.Button.DownBackgroundColor : Styles.Button.HoverBackgroundColor;
                            break;

                        case ControlState.Pressed:
                            //fillColor = _isDefault ? Colors.BrightBackground : Colors.BrightBackground;
                            fillColor = Styles.Button.BackgroundColor;
                            break;
                    }
                }
                else if (ButtonStyle == BrightButtonStyle.Flat)
                {
                    switch (ButtonState)
                    {
                        case ControlState.Normal:
                            fillColor = Styles.Button.BackgroundColor;
                            break;

                        case ControlState.Hover:
                            fillColor = Styles.Button.HoverBackgroundColor;
                            break;

                        case ControlState.Pressed:
                            fillColor = Styles.Button.PressedBackgroundColor;
                            break;
                    }
                }
            }
            else
            {
                textColor = Styles.Control.DisabledColor;
                fillColor = Styles.Button.HoverBackgroundColor;
            }

            using (var b = new SolidBrush(fillColor))
            {
                g.FillRectangle(b, rect);
            }

            if (ButtonStyle == BrightButtonStyle.Normal)
            {
                using (var p = new Pen(borderColor, 1))
                {
                    var modRect = new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);

                    g.DrawRectangle(p, modRect);
                }
            }

            var textOffsetX = 0;
            var textOffsetY = 0;

            if (Image != null)
            {
                var stringSize = g.MeasureString(Text, Font, rect.Size);

                var x = (ClientSize.Width / 2) - (Image.Size.Width / 2);
                var y = (ClientSize.Height / 2) - (Image.Size.Height / 2);

                switch (TextImageRelation)
                {
                    case TextImageRelation.ImageAboveText:
                        textOffsetY = (Image.Size.Height / 2) + (ImagePadding / 2);
                        y -= ((int)(stringSize.Height / 2) + (ImagePadding / 2));
                        break;

                    case TextImageRelation.TextAboveImage:
                        textOffsetY = ((Image.Size.Height / 2) + (ImagePadding / 2)) * -1;
                        y += ((int)(stringSize.Height / 2) + (ImagePadding / 2));
                        break;

                    case TextImageRelation.ImageBeforeText:
                        textOffsetX = Image.Size.Width + (ImagePadding * 2);
                        x = ImagePadding;
                        break;

                    case TextImageRelation.TextBeforeImage:
                        x += (int)stringSize.Width;
                        break;
                }

                g.DrawImageUnscaled(Image, x, y);
            }

            using (var b = new SolidBrush(textColor))
            {
                var modRect = new Rectangle(rect.Left + textOffsetX + Padding.Left,
                                            rect.Top + textOffsetY + Padding.Top, rect.Width - Padding.Horizontal,
                                            rect.Height - Padding.Vertical);

                var stringFormat = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };

                g.DrawString(Text, Font, b, modRect, stringFormat);
            }
        }

        #endregion Paint Region
    }

    public enum BrightButtonStyle
    {
        Normal,
        Flat
    }
}