using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public partial class FileDropControl : Design.Controls.UserControl
    {
        public event EventHandler FileChanged;

        public string Filter { get; set; }
        public string File { get; set; }
        public string[] AllowExtensions { get; set; }

        public FileDropControl()
        {
            InitializeComponent();
            DropButton.Text = Language.Language.SetSettingDialog_DropLabel;
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = Filter;
                if (dialog.ShowDialog() == DialogResult.OK)
                    ConfirmProcessing(dialog.FileName);
            }
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
            if (!System.IO.File.Exists(file))
                return;

            try
            {
                FileInfo info = new FileInfo(file);

                if (AllowExtensions != null && (!AllowExtensions.Contains(info.Extension) || AllowExtensions.Length == 0))
                    return;

                DropButton.Text = info.Name;

                File = info.FullName;
                FileChanged?.Invoke(this, null);
            }
            catch { }
        }
    }
}