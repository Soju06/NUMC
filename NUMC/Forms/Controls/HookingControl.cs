using NUMC.Keyboard;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public partial class HookingControl : Design.Controls.UserControl
    {
        public event KeyChanged KeyChanged;

        private bool hook = false;

        public HookingControl()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Service.GetService()?.Pause();
            hook = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Service.GetService()?.Start();
            hook = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var sf = new StringFormat {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            base.OnPaintBackground(e);

            //using (var sb = new SolidBrush(BackColor))
            //    g.FillRectangle(sb, ClientRectangle);

            using (var sb = new SolidBrush(ForeColor))
                g.DrawString(Language.Language.HookingControl_Text, 
                    Font, sb, ClientRectangle, sf);
        }

        private bool KeyboardHook_KeyDown(Keys key)
        {
            if (hook) KeyChanged?.Invoke(key);
            return !hook;
        }

        private void Label_MouseEnter(object sender, EventArgs e) => hook = true;

        private void Label_MouseLeave(object sender, EventArgs e) => hook = false;

        public void UnHook() => KeyboardHook.KeyDown -= KeyboardHook_KeyDown;
    }

    public delegate void KeyChanged(Keys key);
}