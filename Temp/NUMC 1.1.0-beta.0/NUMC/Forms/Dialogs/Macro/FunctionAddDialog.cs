using Hook;
using NUMC.Design;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WindowsInput.Native;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class FunctionAddDialog : NDialog
    {
        public string Value { get; internal set; }

        public FunctionAddDialog()
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.FunctionAddDialog_Title);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Value = textBox.Text;
        }
    }
}