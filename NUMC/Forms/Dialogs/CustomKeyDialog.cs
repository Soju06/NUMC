using DarkUI.Forms;
using Hook;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput.Native;

namespace NUMC.Forms.Dialogs
{
    public partial class CustomKeyDialog : DarkDialog
    {
        public string[,] Types = new string[4, 3]
        {
            {
                "SendKeys",
                Language.Language.CustomKeyDialog_SendKeys_Name,
                Language.Language.CustomKeyDialog_SendKeys_Caption
            },
            {
                "VirtualSendKeys",
                Language.Language.CustomKeyDialog_VirtualSendKeys_Name,
                Language.Language.CustomKeyDialog_VirtualSendKeys_Caption
            },
            {
                "TextEntry",
                Language.Language.CustomKeyDialog_TextEntry_Name,
                Language.Language.CustomKeyDialog_TextEntry_Caption
            },
            {
                "VirtualKey",
                Language.Language.CustomKeyDialog_VirtualKey_Name,
                Language.Language.CustomKeyDialog_VirtualKey_Caption
            }
        };

        public KeyScript KeyScript { get; internal set; }

        public CustomKeyDialog(KeyScript keyScript)
        {
            KeyScript = keyScript;

            InitializeComponent();

            RemoveButton.Text = Language.Language.Program_Remove_Button;
            AddButton.Text = Language.Language.Program_Add_Button;
            ClearButton.Text = Language.Language.Program_Reset_Button;

            InitializeComboBox();
            InitializeSetting();

            btnOk.Click += BtnOk_Click;

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.CustomKeyDialog_Title);
            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }

        private void InitializeComboBox()
        {
            for (int i = 0; i < Types.GetLength(0); i++)
            {
                KeyboardTypeComboBox.Items.Add(Types[i, 1]);
            }

            KeyboardTypeComboBox.SelectedIndex = 3;
        }

        public void InitializeSetting()
        {
            if (KeyScript != null)
            {
                for (int i = 0; i < Types.GetLength(0); i++)
                    if (KeyScript.Type == Types[i, 0])
                    {
                        KeyboardTypeComboBox.SelectedIndex = i;

                        if (KeyboardTypeComboBox.SelectedIndex == 0 && KeyboardTypeComboBox.SelectedIndex == 2)
                        {
                            if (KeyScript.SendKeys != null && KeyScript.SendKeys.Text != null)
                                ScriptTextBox.Text = string.Join("\n", KeyScript.SendKeys.Text);
                        }
                        else
                        {
                            if (KeyScript.VirtualKey != null && KeyScript.VirtualKey.Keys != null)
                            {
                                ScriptTextBox.Text = string.Join(", ", KeyScript.VirtualKey.Keys);
                            }
                        }
                    }
            }
        }

        private void CustomKey_Load(object sender, EventArgs e)
        {
            KeyboardTypeComboBox.Refresh();
        }

        private void CustomKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.KeyDown -= KeyboardHook_KeyDown;
        }

        private bool KeyboardHook_KeyDown(int vkCode)
        {
            if (hook && VirtualMode && ScriptTextBox.Text.Split(',').Length <= 25)
            {
                AddVirtualKey((VirtualKeyCode)vkCode);
            }

            return !hook;
        }

        private void AddVirtualKey(VirtualKeyCode keyCode)
        {
            if (string.IsNullOrWhiteSpace(ScriptTextBox.Text))
                ScriptTextBox.AppendText((keyCode).ToString());
            else
            {
                ScriptTextBox.AppendText(", ");
                ScriptTextBox.AppendText((keyCode).ToString());
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
            TipLabel.Text = Types[KeyboardTypeComboBox.SelectedIndex, 2];
            ScriptTextBox.Text = string.Empty;
        }

        private void KeyTextBox_MouseHover(object sender, EventArgs e)
        {
            if (VirtualMode)
            {
                TipBox.ToolTipTitle = Language.Language.CustomKeyDialog_KeyHook_Tip_Title;
                TipBox.SetToolTip((Control)sender, Language.Language.CustomKeyDialog_KeyHook_Tip_Caption);
            }
        }

        private bool hook = false;

        private void KeyTextBox_Enter(object sender, EventArgs e)
        {
            if (VirtualMode)
                hook = true;
        }

        private void KeyTextBox_Leave(object sender, EventArgs e)
        {
            hook = false;
        }

        private void KeyTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (VirtualMode) // 문자열 입력이 아니면
            {
                // 백스페이스
                if (e.KeyCode == Keys.Back)
                    DeleteVirtualKey();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private bool VirtualMode
        {
            get
            {
                return KeyboardTypeComboBox.SelectedIndex != 0 && KeyboardTypeComboBox.SelectedIndex != 2;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ScriptTextBox.Text = string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!VirtualMode)
                return;

            if (ScriptTextBox.Text.Split(',').Length > 25)
                return;

            using (EnumDialog addDialog = new EnumDialog(typeof(VirtualKeyCode), Language.Language.KeyAddDialog_Title, @"http://www.kbdedit.com/manual/low_level_vk_list.html"))
            {
                if (addDialog.ShowDialog() == DialogResult.OK)
                {
                    AddVirtualKey((VirtualKeyCode)addDialog.SelectItem);
                }
                addDialog.Dispose();
            }
        }

        private VirtualKeyCode[] GetVirtualKeys()
        {
            List<VirtualKeyCode> virtualKeys = new List<VirtualKeyCode>();
            string[] ary = ScriptTextBox.Text.Replace(" ", "").Split(',');
            for (int i = 0; i < ary.Length; i++)
            {
                if (Enum.TryParse(ary[i], out VirtualKeyCode keyCode))
                    virtualKeys.Add(keyCode);
            }

            return virtualKeys.ToArray();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (KeyScript == null)
                KeyScript = new KeyScript();

            if (string.IsNullOrWhiteSpace(ScriptTextBox.Text))
            {
                KeyScript.SendKeys = null;
                KeyScript.VirtualKey = null;
            }
            else
            {
                if (VirtualMode)
                {
                    VirtualKeyCode[] virtualKeys = GetVirtualKeys();

                    KeyScript.SendKeys = null;

                    if (virtualKeys.Length == 0)
                    {
                        KeyScript.VirtualKey = null;
                    }
                    else
                    {
                        VirtualKey virtualKey = new VirtualKey(virtualKeys);

                        KeyScript.VirtualKey = virtualKey;
                    }
                }
                else
                {
                    Script.SendKeys sendKeys = new Script.SendKeys(new string[] { ScriptTextBox.Text });

                    KeyScript.VirtualKey = null;
                    KeyScript.SendKeys = sendKeys;
                }
            }

            KeyScript.Type = Types[KeyboardTypeComboBox.SelectedIndex, 0];
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (VirtualMode)
            {
                DeleteVirtualKey();
            }
        }
    }
}