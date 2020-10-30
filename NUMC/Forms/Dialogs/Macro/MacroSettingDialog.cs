using Hook;
using NUMC.Design.Controls;
using NUMC.Macro;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs.Macro
{
    public partial class MacroSettingDialog : Design.Dialog
    {
        public KeyScript KeyScript { get; internal set; }

        private IMacroModule[] MacroModules;

        public MacroSettingDialog(KeyScript keyScript)
        {
            KeyScript = keyScript;
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.MacroSettingDialog_Title);

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            KeyboardHook.KeyUp += KeyboardHook_KeyUp;

            AddKeystrokeButton.Text = Language.Language.MacroSettingDialog_AddKeystroke;
            AddTextInputButton.Text = Language.Language.MacroSettingDialog_AddTextInput;
            AddDelayButton.Text = Language.Language.MacroSettingDialog_AddDelay;
            AddFunctionButton.Text = Language.Language.MacroSettingDialog_AddFunction;
            GotoFunctionButton.Text = Language.Language.MacroSettingDialog_GotoFunction;
            AddKeyUpAllButton.Text = Language.Language.MacroSettingDialog_KeyUpAll;
            AddExitButton.Text = Language.Language.Program_Exit;
            MoveupButton.Text = Language.Language.Program_Moveup;
            MovedownButton.Text = Language.Language.Program_Movedown;
            RemoveButton.Text = Language.Language.MacroSettingDialog_Remove;
            RemoveAllButton.Text = Language.Language.MacroSettingDialog_RemoveAll;
            ModuleButton.Text = Language.Language.MacroSettingDialog_Modules;

            btnOk.Click += BtnOk_Click;

            if (keyScript.Macro != null && keyScript.Macro.Code.Length >= 1)
            {
                SetItems(keyScript.Macro.Code.Split('\n'));
            }

            InitializeModules();
        }

        private void InitializeModules()
        {
            MacroModules = Plugin.Handler.ExtractPlugin<IMacroModule>();

            for (int i = 0; i < MacroModules.Length; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(MacroModules[i].BUTTON_NAME)
                {
                    Tag = MacroModules[i]
                };
                ModuleContextMenu.Items.Add(item);
                item.Click += ModuleItem_Click;
            }
        }

        private void AddKeystrokeButton_Click(object sender, EventArgs e)
        {
            using (KeyAddDialog dialog = new KeyAddDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AddKeystroke(dialog.Key, dialog.KeystrokeType);
                }
            }
        }

        private void AddKeystroke(Keys Key, KeyboardEventType KeystrokeType)
        {
            string line = null;
            string name = null;
            switch (KeystrokeType)
            {
                case KeyboardEventType.KEYDOWN:
                    line = Script.Macro.CreateKeyDown(Key);
                    name = $"{Language.Language.MacroSettingDialog_Keydown} ({Key})";
                    break;

                case KeyboardEventType.KEYUP:
                    line = Script.Macro.CreateKeyUp(Key);
                    name = $"{Language.Language.MacroSettingDialog_Keyup} ({Key})";
                    break;

                case KeyboardEventType.KEYCLICK:
                    line = Script.Macro.CreateKeyClick(Key);
                    name = $"{Language.Language.MacroSettingDialog_KeyClick} ({Key})";
                    break;

                default:
                    break;
            }

            if (line != null)
                AddEvents(name, line);
        }

        private void AddDelay(int delay)
        {
            AddEvents($"{Language.Language.MacroSettingDialog_Delay} ({delay}ms)", Script.Macro.CreateDelay(delay));
        }

        private void AddTextInput(string text)
        {
            AddEvents($"{Language.Language.MacroSettingDialog_TextInput} ({text})", Script.Macro.CreateTextEntry(text));
        }

        private void AddFunction(string name)
        {
            AddEvents($"{Language.Language.MacroSettingDialog_Function} ({name})", Script.Macro.CreateFunction(name));
        }

        private void AddGotoFunction(string name)
        {
            AddEvents($"{Language.Language.MacroSettingDialog_GotoFunction} ({name})", Script.Macro.CreateGotoFunction(name));
        }

        private void AddKeyUpAll()
        {
            AddEvents(Language.Language.MacroSettingDialog_KeyUpAll, Script.Macro.CreateKeyUpAll());
        }

        private void AddExit()
        {
            AddEvents(Language.Language.Program_Exit, Script.Macro.CreateExit());
        }

        private void AddEvents(string Name, string code)
        {
            EventsView.Items.Add(new BrightListItem(Name) { Tag = code });
        }

        private void AddDelayButton_Click(object sender, EventArgs e)
        {
            using (DelayAddDialog dialog = new DelayAddDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AddDelay(dialog.Delay);
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventsView.SelectedIndices.Count >= 1)
                {
                    EventsView.Items.RemoveAt(EventsView.SelectedIndices[0]);
                }
            }
            catch { }
        }

        private void AddTextInputButton_Click(object sender, EventArgs e)
        {
            using (TextInputAddDialog dialog = new TextInputAddDialog(""))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AddTextInput(dialog.Value);
                }
            }
        }

        private void AddFunctionButton_Click(object sender, EventArgs e)
        {
            using (FunctionAddDialog dialog = new FunctionAddDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.Value))
                        return;

                    // 중복 확인
                    foreach (var item in Script.Macro.GetFunctions(GetCodes()))
                    {
                        if (item.name == dialog.Value)
                            return;
                    }

                    AddFunction(dialog.Value);
                }
            }
        }

        private void GotoFunctionButton_Click(object sender, EventArgs e)
        {
            using (GotoFunctionDialog dialog = new GotoFunctionDialog(Script.Macro.GetFunctions(GetCodes()).ToArray()))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.Value))
                        return;

                    AddGotoFunction(dialog.Value);
                }
            }
        }

        public string[] GetCodes()
        {
            List<string> codes = new List<string>();

            for (int i = 0; i < EventsView.Items.Count; i++)
            {
                codes.Add((string)EventsView.Items[i].Tag);
            }

            return codes.ToArray();
        }

        private void AddKeyUpAllButton_Click(object sender, EventArgs e)
        {
            AddKeyUpAll();
        }

        private void AddExitButton_Click(object sender, EventArgs e)
        {
            AddExit();
        }

        private void MoveupButton_Click(object sender, EventArgs e)
        {
            SelectItemMove(false);
        }

        private void MovedownButton_Click(object sender, EventArgs e)
        {
            SelectItemMove(true);
        }

        private void SelectItemMove(bool up)
        {
            if (EventsView.SelectedIndices.Count >= 1)
            {
                int n = EventsView.SelectedIndices[0] - (up ? -1 : 1);

                if (n < 0 || n >= EventsView.Items.Count)
                    return;

                var selectItem = EventsView.Items[EventsView.SelectedIndices[0]];

                EventsView.Items.Remove(selectItem);

                EventsView.Items.Insert(n, selectItem);

                EventsView.SelectItem(n);
            }
        }

        private bool hook = false;

        private void EventsView_MouseEnter(object sender, EventArgs e)
        {
            hook = true;
        }

        private void EventsView_MouseLeave(object sender, EventArgs e)
        {
            hook = false;
        }

        private readonly List<KeyUDDelay> KeyUDDelays = new List<KeyUDDelay>();

        private bool KeyboardHook_KeyDown(int vkCode)
        {
            if (hook)
            {
                KeyHookDown((Keys)vkCode);
            }

            return !hook;
        }

        private void KeyHookDown(Keys keys)
        {
            try
            {
                // 중복 검사
                for (int i = 0; i < KeyUDDelays.Count; i++)
                {
                    if (KeyUDDelays[i].Key == keys)
                        return;
                }

                Invoke(new MethodInvoker(delegate ()
                {
                    AddKeystroke(keys, KeyboardEventType.KEYDOWN);
                }));
                KeyUDDelays.Add(new KeyUDDelay(keys));
            }
            catch { }
        }

        private void KeyHookUp(Keys keys)
        {
            try
            {
                // 중복 검사
                for (int i = 0; i < KeyUDDelays.Count; i++)
                {
                    if (KeyUDDelays[i].Key == keys)
                    {
                        KeyUDDelays[i].Stopwatch.Stop();
                        Invoke(new MethodInvoker(delegate ()
                        {
                            try { AddDelay((int)KeyUDDelays[i].Stopwatch.ElapsedMilliseconds); } catch { }
                            AddKeystroke(KeyUDDelays[i].Key, KeyboardEventType.KEYUP);
                        }));

                        KeyUDDelays.Remove(KeyUDDelays[i]);

                        break;
                    }
                }

                // 시간 초기화
                for (int i = 0; i < KeyUDDelays.Count; i++)
                {
                    if (KeyUDDelays[i].Stopwatch != null)
                        KeyUDDelays[i].Stopwatch.Restart();
                }
            }
            catch { }
        }

        private bool KeyboardHook_KeyUp(int vkCode)
        {
            if (hook)
            {
                KeyHookUp((Keys)vkCode);
            }

            return !hook;
        }

        private void MacroSettingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.KeyDown -= KeyboardHook_KeyDown;
            KeyboardHook.KeyDown -= KeyboardHook_KeyUp;
        }

        private class KeyUDDelay
        {
            public Keys Key;
            public Stopwatch Stopwatch;

            public KeyUDDelay(Keys key)
            {
                Key = key;
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (KeyScript == null)
                KeyScript = new KeyScript();

            if (EventsView.Items.Count == 0)
            {
                KeyScript.Macro = null;
                return;
            }

            if (KeyScript.Macro == null)
                KeyScript.Macro = new Script.Macro();

            KeyScript.Macro.Code = string.Join("\n", GetCodes());
        }

        private void SetItems(string[] Code)
        {
            string line;

            int length;

            for (int i = 0; i < Code.Length; i++)
            {
                // 코드가 없으면
                if (string.IsNullOrWhiteSpace(Code[i]))
                    continue;

                line = Code[i].TrimStart().Split(new string[] { "//" }, StringSplitOptions.None)[0];

                // 자주 사용되는 변수
                length = line.Length;

                if (length > 1)
                {
                    string data = line.Substring(1);

                    // function
                    if (line[0] == ':')
                    {
                        AddFunction(data);
                    }
                    // goto
                    else if (line[0] == '>')
                    {
                        AddGotoFunction(data);
                    }
                    // delay
                    else if (line[0] == '|')
                    {
                        if (int.TryParse(data, out int a))
                        {
                            AddDelay(a);
                        }
                    }
                    // keyDown
                    else if (line[0] == '-')
                    {
                        if (int.TryParse(data, out int a))
                        {
                            AddKeystroke((Keys)a, KeyboardEventType.KEYDOWN);
                        }
                    }
                    // keyUp
                    else if (line[0] == '+')
                    {
                        if (int.TryParse(data, out int a))
                        {
                            AddKeystroke((Keys)a, KeyboardEventType.KEYUP);
                        }
                    }
                    // keyClick
                    else if (line[0] == '=')
                    {
                        if (int.TryParse(data, out int a))
                        {
                            AddKeystroke((Keys)a, KeyboardEventType.KEYCLICK);
                        }
                    }
                    // text
                    else if (line[0] == '#')
                    {
                        AddTextInput(data);
                    }
                    // keyUp All
                    else if (line[0] == '^')
                    {
                        AddKeyUpAll();
                    }
                    // exit
                    else if (line[0] == '!')
                    {
                        AddExit();
                    }
                    else
                    {
                        for (int m = 0; m < MacroModules.Length; m++)
                        {
                            if (MacroModules[m].MODULE_NAME == line[0] && MacroModules[m].CODE_RESULT(data, ref Code, out string NAME, out string RCODE))
                            {
                                AddEvents(NAME, RCODE);
                            }
                        }
                    }
                }
            }
        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            EventsView.Items.Clear();
        }

        private void ModuleButton_Click(object sender, EventArgs e)
        {
            ModuleContextMenu.Show(MousePosition);
        }

        private void ModuleItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] code = GetCodes();
            if (item.Tag != null)
            {
                NUMC.Macro.IMacroModule module = ((NUMC.Macro.IMacroModule)item.Tag);
                if (module.SHOW_DIALOG(ref code, out string NAME, out string RCODE))
                {
                    AddEvents(NAME, RCODE);
                }
            }
        }
    }
}