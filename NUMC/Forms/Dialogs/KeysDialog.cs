using NUMC.Design;
using System;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs
{
    public partial class KeysDialog : Dialog
    {
        public Keys SelectItem { get; private set; }

        public KeysDialog()
        {
            InitializeComponent();

            Text = Setting.Setting.GetTitleName(Language.Language.KeysDialog_Title);
            MainComboBox.DataSource = Enum.GetValues(typeof(Keys));
            MainComboBox.SelectedIndex = 0;

            hookingControl.KeyChanged += HookingControl_KeyChanged;
        }

        private void HookingControl_KeyChanged(Keys key) => MainComboBox.SelectedItem = key;

        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e) => SelectItem = (Keys)MainComboBox.SelectedValue;

        private void KeyAddDialog_Load(object sender, EventArgs e) => MainComboBox.Refresh();

        private void KeyDialog_FormClosing(object sender, FormClosingEventArgs e) => hookingControl.UnHook();
    }
}