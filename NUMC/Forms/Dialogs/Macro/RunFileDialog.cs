using NUMC.Design;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class RunFileDialog : Dialog
    {
        public string Path { get; internal set; }
        public string Args { get; internal set; }

        public RunFileDialog()
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.RunFileDialog_Title);

            fileDropControl.FileChanged += FileDropControl_FileChanged;
            fileDropControl.Filter = "All Files|*.*";
        }

        private void FileDropControl_FileChanged(object sender, EventArgs e)
        {
            Path = fileDropControl.File;
        }

        private void ArgsTextBox_TextChanged(object sender, EventArgs e)
        {
            Args = ArgsTextBox.Text;
        }
    }
}