using NUMC.Design;
using System;
using System.Diagnostics;

namespace NUMC.Forms.Dialogs
{
    public partial class EnumDialog : NDialog
    {
        public Type EnumType { get; internal set; }
        public object SelectItem { get; internal set; }
        public string InfoURI { get; internal set; }

        public EnumDialog(Type enumType, string Title, string infoURI = null)
        {
            InfoURI = infoURI;
            EnumType = enumType;

            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Title;

            MainComboBox.DataSource = Enum.GetValues(enumType);

            MainComboBox.SelectedIndex = 0;
        }

        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectItem = MainComboBox.SelectedValue;
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
    }
}