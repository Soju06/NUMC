using DarkUI.Forms;
using System;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class DelayAddDialog : DarkDialog
    {
        public int Delay { get; internal set; }

        public DelayAddDialog()
        {
            InitializeComponent();
            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.DelayAddDialog_Title);
        }

        private void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(DelayTextBox.Text, out int delay))
                Delay = delay;
        }

        private void DelayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}