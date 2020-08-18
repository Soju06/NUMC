using DarkUI.Forms;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class TextInputAddDialog : DarkDialog
    {
        public string text { get; internal set; }

        public TextInputAddDialog(string text)
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.TextInputAddDialog_Title);

            textBox.Text = text;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            text = textBox.Text;
        }
    }
}