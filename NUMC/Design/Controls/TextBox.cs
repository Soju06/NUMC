using System;
using System.Drawing;
using System.Windows.Forms;
using WinUtils;

namespace NUMC.Design.Controls
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        public TextBox()
        {
            BackColor = Styles.Control.BackgroundColor;
            ForeColor = Styles.Control.Color;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
            ((Control)this).Paint += TextBox_Paint;

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            WinAPI.RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, 0x400 | 0x100 | 0x1);
        }

        private void TextBox_Paint(object sender, PaintEventArgs e)
        {
            WinAPI.RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, 0x400 | 0x100 | 0x1);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x85)
            {
                var hdc = WinAPI.GetWindowDC(Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                using (var p = new Pen(Styles.Control.ColorSelectionBackgroundColor))
                    g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                WinAPI.ReleaseDC(Handle, hdc);
            }
        }
    }
}