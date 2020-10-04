using Hook;
using NUMC.Design;
using NUMC.Design.Bright;
using System;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class KeyAddDialog : NDialog
    {
        public Keys Key { get; internal set; }
        public KeyboardEventType KeystrokeType { get; internal set; } = KeyboardEventType.KEYCLICK;

        public KeyAddDialog()
        {
            InitializeComponent();

            TipLabel.Text = Language.Language.KeyAddDialog_TipLabel;

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.KeyAddDialog_Title);

            MainComboBox.DataSource = Enum.GetValues(typeof(Keys));

            MainComboBox.SelectedIndex = 0;

            TypeRadio_0.Tag = KeyboardEventType.KEYCLICK;
            TypeRadio_1.Tag = KeyboardEventType.KEYDOWN;
            TypeRadio_2.Tag = KeyboardEventType.KEYUP;

            TypeRadio_0.Text = Language.Language.MacroSettingDialog_KeyClick;
            TypeRadio_1.Text = Language.Language.MacroSettingDialog_Keydown;
            TypeRadio_2.Text = Language.Language.MacroSettingDialog_Keyup;

            TypeRadio_0.Checked = true;

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        private bool KeyboardHook_KeyDown(int vkCode)
        {
            if (hook)
            {
                MainComboBox.SelectedItem = (Keys)vkCode;
            }

            return !hook;
        }

        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = (Keys)MainComboBox.SelectedValue;
        }

        private void KeyAddDialog_Load(object sender, EventArgs e)
        {
            MainComboBox.Refresh();
        }

        private void TypeRadio_Changed(object sender, EventArgs e)
        {
            if (((BrightRadioButton)sender).Checked)
                KeystrokeType = (KeyboardEventType)((BrightRadioButton)sender).Tag;
        }

        private void TipLabel_MouseHover(object sender, EventArgs e)
        {
            TipBox.ToolTipTitle = Language.Language.CustomKeyDialog_KeyHook_Tip_Title;
            TipBox.SetToolTip((Control)sender, Language.Language.CustomKeyDialog_KeyHook_Tip_Caption);
        }

        private bool hook = false;

        private void TipLabel_Enter(object sender, EventArgs e)
        {
            hook = true;
        }

        private void TipLabel_Leave(object sender, EventArgs e)
        {
            hook = false;
        }

        private void KeyAddDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.KeyDown -= KeyboardHook_KeyDown;
        }
    }
}