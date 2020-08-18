using DarkUI.Forms;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WindowsInput.Native;

namespace NUMC.Forms.Dialogs
{
    public partial class JsonEditorDialog : DarkDialog
    {
        private readonly Script.Script Script = new Script.Script();

        public JsonEditorDialog(Script.Script script)
        {
            Script = script;
            InitializeComponent();
            InitializeEvents();
            LoadSetting();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.JsonEditorDialog_Title);

            FileToolStripMenuItem.Text = Language.Language.Program_File_Button;
            EditToolStripMenuItem.Text = Language.Language.Program_Edit_Button;
            SaveMenuItem.Text = Language.Language.Program_Save_Button;
            ExitMenuItem.Text = Language.Language.Program_Exit;

            SaveAndApplyMenuItem.Text = Language.Language.JsonEditorDialog_SaveAndApply;
            NewCustomKeyMenuItem.Text = Language.Language.JsonEditorDialog_NewCustomKey;
            NewWhiteListKeyMenuItem.Text = Language.Language.JsonEditorDialog_NewWhiteListKey;
            EditingModeCheckBox.Text = Language.Language.JsonEditorDialog_EditingMode;
            CleanUpButton.Text = Language.Language.JsonEditorDialog_CleanUp;
            FindKeyButton.Text = Language.Language.JsonEditorDialog_FindKey;
            FindVirtualKeyButton.Text = Language.Language.JsonEditorDialog_FindVirtualKey;

            CodeTextBox.ScrollBars = ScrollBars.Vertical;
        }

        private void InitializeEvents()
        {
            SaveMenuItem.Click += ToolsMenuStrip_Click;
            SaveAndApplyMenuItem.Click += ToolsMenuStrip_Click;
            ExitMenuItem.Click += ToolsMenuStrip_Click;
            NewCustomKeyMenuItem.Click += ToolsMenuStrip_Click;
            NewWhiteListKeyMenuItem.Click += ToolsMenuStrip_Click;
        }

        private void SaveSetting()
        {
            File.WriteAllText(Setting.Setting.KEY_SETTING_PATH, Script.Object.ToString());
        }

        private void LoadSetting()
        {
            if (File.Exists(Setting.Setting.KEY_SETTING_PATH))
            {
                Point point = CodeTextBox.AutoScrollOffset;
                CodeTextBox.Text = File.ReadAllText(Setting.Setting.KEY_SETTING_PATH);
                CodeTextBox.AutoScrollOffset = point;
            }
        }

        private void ToolsMenuStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            switch (menu.Tag)
            {
                case "Save":
                    File.WriteAllText(Setting.Setting.KEY_SETTING_PATH, CodeTextBox.Text);
                    break;

                case "SaveAndApply":
                    try
                    {
                        File.WriteAllText(Setting.Setting.KEY_SETTING_PATH, CodeTextBox.Text);
                        Script.Object.SetScript(CodeTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        if (DarkMessageBox.ShowError($"{Language.Language.Message_Error_LoadSetting_Fail}\n{ex.Message.Split('\n')[0]}",
                            Assembly.GetExecutingAssembly().GetName().Name, DarkDialogButton.YesNo) == DialogResult.Yes)
                        {
                            Script.Object.Reset();
                            SaveSetting();
                        }
                    }
                    break;

                case "Exit":
                    Close();
                    break;

                case "NewCustomKey":
                    NewCustomKey();
                    break;

                case "NewWhiteListKey":
                    NewWhiteListKey();
                    break;
            }
        }

        private void NewCustomKey()
        {
            using (EnumDialog key = new EnumDialog(typeof(Keys), Language.Language.KeyAddDialog_Title))
            {
                if (key.ShowDialog() == DialogResult.OK)
                {
                    CustomKeySeting((Keys)key.SelectItem);

                    SaveSetting();
                    LoadSetting();
                }
            }

            LoadSetting();
        }

        private void NewWhiteListKey()
        {
            using (EnumDialog key = new EnumDialog(typeof(Keys), Language.Language.KeyAddDialog_Title))
            {
                if (key.ShowDialog() == DialogResult.OK)
                {
                    List<Keys> keys = Script.Object.WVKeys.ToList();
                    keys.Add((Keys)key.SelectItem);
                    Script.Object.WVKeys = keys.ToArray();

                    SaveSetting();
                    LoadSetting();
                }
            }
        }

        private void CustomKeySeting(Keys keys)
        {
            KeyObject keyObject = Script.Object.GetKeyObject(keys, false);
            KeyScript keyScript;

            if (keyObject != null && keyObject.KeyScript != null && keyObject.KeyScript.Length >= 1)
                keyScript = keyObject.KeyScript[0];
            else
                keyScript = (keyObject.KeyScript = new KeyScript[] { new KeyScript() })[0];

            using (CustomKeyDialog customKey = new CustomKeyDialog(keyScript))
            {
                if (customKey.ShowDialog() == DialogResult.OK)
                {
                    // 확인
                }
            }

            GC.Collect(1);
        }

        private void EditJsonDialog_Load(object sender, EventArgs e)
        {
            titleBar.BringToFront();
        }

        private void EditingModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EditingModeCheckBox.Checked)
            {
                if (DarkMessageBox.ShowWarning(Language.Language.Message_Warning_Editing, Text, DarkDialogButton.YesNo) != DialogResult.Yes)
                {
                    EditingModeCheckBox.Checked = false;
                }
            }

            CleanUpButton.Enabled = EditingModeCheckBox.Checked;
        }

        private void CleanUpButton_Click(object sender, EventArgs e)
        {
            string old = CodeTextBox.Text;
            CodeTextBox.Text = Json.BeautifierJson(old);

            if (DarkMessageBox.ShowInformation(Language.Language.Message_Information_ThisSetting, Text, DarkDialogButton.YesNo) != DialogResult.Yes)
                CodeTextBox.Text = old;
        }

        private void CodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!EditingModeCheckBox.Checked)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void FindKeyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CodeTextBox.SelectedText))
            {
                if (int.TryParse(CodeTextBox.SelectedText, out int result))
                {
                    TipBox.SetToolTip((Control)sender, $"Index: {result}\nKeys: {(Keys)result}");
                }
            }
        }

        private void FindVirtualKeyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CodeTextBox.SelectedText))
            {
                if (int.TryParse(CodeTextBox.SelectedText, out int result))
                {
                    TipBox.SetToolTip((Control)sender, $"Index: {result}\nVirtualKeys: {(VirtualKeyCode)result}");
                }
            }
        }

        private void EditJsonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.ReadAllText(Setting.Setting.KEY_SETTING_PATH) != CodeTextBox.Text)
            {
                DialogResult result = DarkMessageBox.ShowInformation(Language.Language.Message_Information_SaveThisSetting, Text, DarkDialogButton.YesNoCancel);
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(Setting.Setting.KEY_SETTING_PATH, CodeTextBox.Text);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}