using System;
using System.Windows.Forms;
using NUMC.Forms.Controls;

namespace NUMC.Forms.Controls
{
    public partial class DefaultLayout : UserControl, IKeyboardLayout
    {
        new public event Click Click;
        new public event MouseClick MouseClick;
        new public event DoubleClick DoubleClick;

        public Keys[] VKeys { get; } = new Keys[]
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

        public DefaultLayout()
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
}