using DarkUI.Forms;
using NUMC.Desion;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            ScriptObject script = new ScriptObject();

            try
            {
                script.SetScript(File.ReadAllText(file));
            }
            catch (Exception ex)
            {
                if (DarkMessageBox.ShowError($"{Language.Language.Message_Error_LoadSetting_Fail}\n{ex.Message.Split('\n')[0]}",
                    Assembly.GetExecutingAssembly().GetName().Name, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    script.Reset();

                    File.WriteAllText(file, script.ToString());
                }
                else
                    return;
            }

            FileInfo info = new FileInfo(file);

            DropButton.Text = info.Name;

            Path = info.FullName;
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Json Files|*.json|All Files|*.*";
                if(dialog.ShowDialog() == DialogResult.OK)
                    ConfirmProcessing(dialog.FileName);
            }
        }
    }
}