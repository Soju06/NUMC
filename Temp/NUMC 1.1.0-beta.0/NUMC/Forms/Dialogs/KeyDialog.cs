using NUMC.Design;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs
{
    public partial class KeyDialog : NDialog
    {
        public Keys SelectItem { get; internal set; }
        public string InfoURI { get; internal set; }

        public KeyDialog()
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Text = Language.Language.KeyAddDialog_Title;

            MainComboBox.DataSource = Enum.GetValues(typeof(Keys));
            MainComboBox.SelectedIndex = 0;

            hookingControl.KeyChanged += HookingControl_KeyChanged;
        }

        private void HookingControl_KeyChanged(Keys key)
        {
            MainComboBox.SelectedItem = key;
        }

        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectItem = (Keys)MainComboBox.SelectedValue;
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InfoURI))
                Process.Start(new ProcessStartInfo(InfoURI));
        }

        private void KeyAddDialog_Load(object sender, EventArgs e)
        {
            MainComboBox.Refresh();
        }

        private void KeyDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            hookingControl.UnHook();
        }
    }
}