using System;
using System.Windows.Forms;

namespace NUMC.Design
{
    public partial class NUMPadUI : UserControl
    {
        new public event NPClick Click;

        new public event NPMouseClick MouseClick;

        new public event NPDoubleClick DoubleClick;

        private readonly Keys[] VKeys = new Keys[]
        {
            Keys.NumLock,
            Keys.Divide,
            Keys.Multiply,
            Keys.Subtract,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Add,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.Return,
            Keys.NumPad0,
            Keys.Decimal
        };

        public NUMPadUI()
        {
            InitializeComponent();
            InitializeEvents();

            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Tag = VKeys[i];
            }
        }

        private void InitializeEvents()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Click += NUMPadUI_Click;
                Controls[i].MouseClick += NUMPadUI_MouseClick;
                Controls[i].DoubleClick += NUMPadUI_DoubleClick;
            }
        }

        private void NUMPadUI_Click(object sender, EventArgs e)
        {
            Click?.Invoke(VKeys[Controls.IndexOf((Control)sender)]);
        }

        private void NUMPadUI_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClick?.Invoke(VKeys[Controls.IndexOf((Control)sender)], e.Button);
        }

        private void NUMPadUI_DoubleClick(object sender, EventArgs e)
        {
            DoubleClick?.Invoke(VKeys[Controls.IndexOf((Control)sender)]);
        }
    }

    public delegate void NPClick(Keys Key);

    public delegate void NPMouseClick(Keys Key, MouseButtons Button);

    public delegate void NPDoubleClick(Keys Key);
}