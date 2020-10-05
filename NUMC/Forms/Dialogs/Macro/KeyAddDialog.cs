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

            hookingControl.KeyChanged += HookingControl_KeyChanged;
        }

        private void HookingControl_KeyChanged(Keys key)
        {
            MainComboBox.SelectedItem = key;
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

        private void KeyAddDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            hookingControl.UnHook();
        }
    }
}