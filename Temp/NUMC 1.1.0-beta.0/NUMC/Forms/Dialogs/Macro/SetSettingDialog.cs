using NUMC.Design;
using System;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class SetSettingDialog : NDialog
    {
        public string Path { get; internal set; }

        public SetSettingDialog()
        {
            InitializeComponent();

            titleBar.Form = this;

            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.SetSettingDialog_Title);

            fileDropControl.FileChanged += FileDropControl_FileChanged;
            fileDropControl.Filter = "Json Files|*.json|All Files|*.*";
            fileDropControl.AllowExtensions = new string[] { ".json" };
        }

        private void FileDropControl_FileChanged(object sender, EventArgs e)
        {
            Path = fileDropControl.File;
        }
    }
}