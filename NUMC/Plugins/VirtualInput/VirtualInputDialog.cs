using NUMC.Keyboard;
using NUMC.Design;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NUMC.Forms.Dialogs;

namespace NUMC.Plugins.VirtualInput
{
    public partial class VirtualInputDialog : Dialog
    {
        public string[] Types => new string[] {
            Language.Language.VirtualInputDialog_VirtualKey_Name,
            Language.Language.VirtualInputDialog_VirtualSendKeys_Name,
            Language.Language.VirtualInputDialog_TextEntry_Name
        };

        public RuntimeScript RuntimeScript { get; internal set; }
        public KeyObject KeyObject { get; internal set; }

        public VirtualInputDialog(RuntimeScript runtimeScript, KeyObject obj)
        {
            RuntimeScript = runtimeScript;
            KeyObject = obj;

            InitializeComponent();
            InitializeForm();
            InitializeComboBox();
            InitializeSetting();

            btnOk.DialogResult = DialogResult.None;
        }

        private void InitializeForm()
        {
            RemoveButton.Text = Language.Language.Program_Remove_Button;
            AddButton.Text = Language.Language.Program_Add_Button;
            ClearButton.Text = Language.Language.Program_Reset_Button;

            btnOk.Click += BtnOk_Click;
            Text = Setting.Setting.GetTitleName(Language.Language.VirtualInputDialog_Title);
            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        private void InitializeComboBox()
        {
            for (int i = 0; i < Types.GetLength(0); i++)
                KeyboardTypeComboBox.Items.Add(Types[i]);
        }

        public void InitializeSetting()
        {
            if (RuntimeScript != null) {
                var a = System.Array.IndexOf(VirtualInputRuntime.RuntimeNames, RuntimeScript.RuntimeName);

                switch (a) {
                    case 0:
                    case 1:
                        ScriptTextBox.Text = string.Join(", ", VirtualInputRuntime.ConvertKeys(RuntimeScript.Data));
                        break;

                    case 2:
                    default:
                        ScriptTextBox.Text = RuntimeScript.Data;
                        break;
                }

                KeyboardTypeComboBox.SelectedIndex = a == -1 ? 0 : a;
            } else
                KeyboardTypeComboBox.SelectedIndex = 0;

            _initializedSetting = true;
        }

        private void VirtualInput_Load(object sender, EventArgs e) => KeyboardTypeComboBox.Refresh();

        private void VirtualInput_Closing(object sender, FormClosingEventArgs e) => KeyboardHook.KeyDown -= KeyboardHook_KeyDown;

        private bool KeyboardHook_KeyDown(Keys Keys)
        {
            if (hook && VirtualMode && ScriptTextBox.Text.Split(',').Length <= 25)
                AddVirtualKey(Keys);

            return !hook;
        }

        private void AddVirtualKey(Keys keyCode)
        {
            if (string.IsNullOrWhiteSpace(ScriptTextBox.Text))
                ScriptTextBox.AppendText(keyCode.ToString());
            else {
                ScriptTextBox.AppendText(", ");
                ScriptTextBox.AppendText(keyCode.ToString());
            }
        }

        private void DeleteVirtualKey()
        {
            string[] ary = ScriptTextBox.Text.Replace(" ", "").Split(',');

            ScriptTextBox.Text = string.Join(", ", ary, 0, ary.Length - 1);
        }

        private void KeyboardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hook = false;
            ScriptTextBox.ReadOnly = VirtualMode;

            if (_initializedSetting)
                ScriptTextBox.Text = string.Empty;
        }

        private bool hook = false;
        private bool _initializedSetting = false;

        private void KeyTextBox_Enter(object sender, EventArgs e)
        {
            if (VirtualMode)
                hook = true;
        }

        private void KeyTextBox_Leave(object sender, EventArgs e) => hook = false;

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (VirtualMode) {
                if (e.KeyCode == Keys.Back)
                    DeleteVirtualKey();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private bool VirtualMode { get => KeyboardTypeComboBox.SelectedIndex < 2; }

        private void ClearButton_Click(object sender, EventArgs e) => ScriptTextBox.Text = string.Empty;

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!VirtualMode)
                return;

            if (ScriptTextBox.Text.Split(',').Length > 25)
                return;

            using (KeysDialog addDialog = new KeysDialog())
                if (addDialog.ShowDialog() == DialogResult.OK)
                    AddVirtualKey(addDialog.SelectItem);
        }

        private Keys[] GetVirtualKeys()
        {
            List<Keys> virtualKeys = new List<Keys>();
            string[] ary = ScriptTextBox.Text.Replace(" ", "").Split(',');

            for (int i = 0; i < ary.Length; i++)
                if (Enum.TryParse(ary[i], out Keys keyCode))
                    virtualKeys.Add(keyCode);

            return virtualKeys.ToArray();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ScriptTextBox.Text)) {
                KeyObject.Scripts.RemoveScriptByRuntimeScript(RuntimeScript);
                RuntimeScript.RuntimeName = null;
                DialogResult = DialogResult.Cancel;
            } else {
                if (VirtualMode)
                    RuntimeScript.Data = VirtualInputRuntime.ConvertString(GetVirtualKeys());
                else
                    RuntimeScript.Data = ScriptTextBox.Text;

                RuntimeScript.RuntimeName = VirtualInputRuntime.RuntimeNames[KeyboardTypeComboBox.SelectedIndex];
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (VirtualMode)
                DeleteVirtualKey();
        }
    }
}