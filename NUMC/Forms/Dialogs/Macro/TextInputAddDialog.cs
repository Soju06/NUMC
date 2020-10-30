using NUMC.Design;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class TextInputAddDialog : Dialog
    {
        public string Value { get; internal set; }

        public TextInputAddDialog(string text)
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.TextInputAddDialog_Title);

            textBox.Text = text;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Value = textBox.Text;
        }
    }
}