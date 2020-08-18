using DarkUI.Controls;
using DarkUI.Forms;
using Hook;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WindowsInput.Native;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class FunctionAddDialog : DarkDialog
    {
        public string name { get; internal set; }

        public FunctionAddDialog()
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.FunctionAddDialog_Title);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            name = textBox.Text;
        }
    }
}