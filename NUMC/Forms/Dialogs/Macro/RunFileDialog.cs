using NUMC.Desion;
using System;
using System.IO;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class RunFileDialog : NDialog
    {
        public string Path { get; internal set; }
        public string Args { get; internal set; }

        public RunFileDialog()
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.RunFileDialog_Title);
            DropButton.Text = Language.Language.SetSettingDialog_DropLabel;
        }

        private void DropButton_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DropButton_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length >= 1)
                ConfirmProcessing(files[0]);
        }

        private void ConfirmProcessing(string file)
        {
            if (!File.Exists(file))
                return;

            try
            {
                FileInfo info = new FileInfo(file);

                DropButton.Text = info.Name;

                Path = info.FullName;
            }
            catch { }
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                    ConfirmProcessing(dialog.FileName);
            }
        }

        private void ArgsTextBox_TextChanged(object sender, EventArgs e)
        {
            Args = ArgsTextBox.Text;
        }
    }
}