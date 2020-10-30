using NUMC.Design;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class FunctionAddDialog : Dialog
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