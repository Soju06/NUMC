using Hook;
using System;
using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public partial class HookingControl : UserControl
    {
        public event KeyChanged KeyChanged;

        private bool hook = false;

        public HookingControl()
        {
            InitializeComponent();
            label.Text = Language.Language.KeyAddDialog_TipLabel;

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        private bool KeyboardHook_KeyDown(int vkCode)
        {
            if (hook)
                KeyChanged?.Invoke((Keys)vkCode);

            return !hook;
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            TipBox.ToolTipTitle = Language.Language.CustomKeyDialog_KeyHook_Tip_Title;
            TipBox.SetToolTip((Control)sender, Language.Language.CustomKeyDialog_KeyHook_Tip_Caption);
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            hook = true;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            hook = false;
        }

        public void UnHook()
        {
            KeyboardHook.KeyDown -= KeyboardHook_KeyDown;
        }
    }

    public delegate void KeyChanged(Keys key);
}