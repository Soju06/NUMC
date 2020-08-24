using DarkUI.Forms;
using NUMC.Desion;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class GotoFunctionDialog : NDialog
    {
        public string name { get; internal set; }

        public GotoFunctionDialog(Script.Macro.Function[] functions)
        {
            InitializeComponent();
            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.KeyAddDialog_Title);

            for (int i = 0; i < functions.Length; i++)
            {
                FunctionsComboBox.Items.Add(functions[i].name);
            }

            if (FunctionsComboBox.Items.Count >= 1)
                FunctionsComboBox.SelectedIndex = 0;
        }

        private void GotoFunctionDialog_Load(object sender, EventArgs e)
        {
            FunctionsComboBox.Refresh();
        }

        private void FunctionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = (string)FunctionsComboBox.SelectedItem;
        }
    }
}