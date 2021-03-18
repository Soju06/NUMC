using NUMC.WinUtils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design.Controls {
    public class TextBox : System.Windows.Forms.TextBox {
        private float _fontSize;
        private readonly Styles _styles = Styles.GetStyles();

        public float FontSize { get => _fontSize; set { if (value == _fontSize) return;
                _fontSize = value; Font = new Font(_styles.FontFamily, value, _styles.FontStyle); } }

        public TextBox() {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = _styles.Control.BackgroundColor;
            ForeColor = _styles.Control.Color;
            FontSize = _styles.FontSize;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.None;
            Text = string.Empty;
        }

        protected override void OnTextChanged(EventArgs e) => Invalidate(true);

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(Text.Trim()) && !string.IsNullOrEmpty(Text) && !Focused) {
                StringFormat format = new StringFormat();

                if (RightToLeft == RightToLeft.Yes) {
                    format.LineAlignment = StringAlignment.Far;
                    format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                }

                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, format);
            }
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);

            if (m.Msg == Constants.WM_PAINT)
                OnPaint(new PaintEventArgs(Graphics.FromHwnd(m.HWnd), ClientRectangle));
        }
    }
}