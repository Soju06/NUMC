using DarkUI.Forms;
using Hook;
using NUMC.Forms.Dialogs;
using NUMC.Script;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NUMC
{
    public partial class Main : Form
    {
        private readonly int SampleItemCount = 4;

        private readonly Script.Script Script = new Script.Script();

        private Keys SelectedKey;
        private bool InfoShowed = false;

        public Main()
        {
            InitializeComponent();
            InitializeForm();
            InitializeSetting();
            InitializeLanguage();
            InitializeSampleItems();
            InitializeEvents();

            CheckUpdate();
        }

        #region FormEvents

        #region Main_FormClosing

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                return;
            }
            KeyboardHook.HookEnd();
            Script.StopInput();
        }

        #endregion Main_FormClosing

        #region Form_Resize

        private const int cGrip = 16;
        private const int cCaption = 32;

        private readonly Pen Pen = new Pen(Color.FromArgb(34, 34, 34));

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(ClientSize.Width - cGrip, ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
            rc = new Rectangle(0, 0, ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Pen.Brush, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }

        #endregion Form_Resize

        #endregion FormEvents

        #region KeyboardHook

        private bool KeyboardHook_KeyUp(int vkCode)
        {
            if (Script.Object.WVKeys.Contains((Keys)vkCode))
            {
                Script.KeyUp(vkCode);
                return !Script.GetIgnoreStatus((Keys)vkCode);
            }
            else
                return true;
        }

        private bool KeyboardHook_KeyDown(int vkCode)
        {
            if (Script.Object.WVKeys.Contains((Keys)vkCode))
            {
                Script.KeyDown(vkCode);
                return !Script.GetIgnoreStatus((Keys)vkCode);
            }
            else
                return true;
        }

        #endregion KeyboardHook

        #region Initialize

        #region Initialize_Form

        private void InitializeForm()
        {
            TitleBar.Form = this;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        #endregion Initialize_Form

        #region Initialize_Language

        private void InitializeLanguage()
        {
            JsonEditToolStripMenuItem.Text = Language.Language.Main_JsonEditor;
            ExitToolStripMenuItem.Text = Language.Language.Program_Exit;
            NExitToolStripMenuItem.Text = Language.Language.Program_Exit;
            CustomKeyToolStripMenuItem.Text = Language.Language.Main_CustomKey;
            OpenToolStripMenuItem.Text = Language.Language.Program_Open;
            StartProgramMenuItem.Text = Language.Language.Main_StartProgram;
            MacroToolStripMenuItem.Text = Language.Language.Main_Macro;
            InfoToolStripMenuItem.Text = Language.Language.Program_Info;
            KeyIgnoreToolStripMenuItem.Text = Language.Language.Main_KeyIgnore;

            Text = Setting.Setting.TITLE_NAME;
            TitleBar.Title = Setting.Setting.GetTitleName(Language.Language.Main_Title);

            LanguageMenuItem.DropDownItems.Clear();

            string cl = Setting.Setting.Languages.Import();

            for (int i = 0; i < Setting.Setting.Languages.Support.GetLength(0); i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(Setting.Setting.Languages.Support[i, 2]) { Tag = Setting.Setting.Languages.Support[i, 0] };

                item.Checked = (string)item.Tag == cl;
                item.Click += Language_MenuItem_Click;

                LanguageMenuItem.DropDownItems.Add(item);
            }
        }

        #endregion Initialize_Language

        #region Initialize_Setting

        private void InitializeSetting()
        {
            if (File.Exists(Setting.Setting.KEY_SETTING_PATH))
            {
                LoadSetting();
            }
            else
            {
                Script.Object.Reset();
            }

            Setting.Setting.Languages.Change(Script.Object.Language);

            StartProgramMenuItem.Checked = Setting.Setting.StartProgram;
        }

        #endregion Initialize_Setting

        #region Initialize_SampleItems

        private void InitializeSampleItems()
        {
            while (NUMContextMenu.Items.Count > SampleItemCount + 1)
            {
                NUMContextMenu.Items.RemoveAt(SampleItemCount + 1);
            }

            NUMContextMenu.Items.AddRange(NUMC.Script.Menu.GetSampleItems());
        }

        #endregion Initialize_SampleItems

        #region Initialize_Events

        private void InitializeEvents()
        {
            NumPadUI.MouseClick += NumPadUI_MouseClick;

            // NUMContextMenu
            for (int i = 0; i < NUMContextMenu.Items.Count; i++)
            {
                if (NUMContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    NUMContextMenu.Items[i].Click += KeySetting_MenuItem_Click;
                }
            }

            // ApplicationContextMenu
            for (int i = 0; i < ApplicationContextMenu.Items.Count; i++)
            {
                if (ApplicationContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    ApplicationContextMenu.Items[i].Click += Application_MenuItem_Click;
                }
            }

            // NotifyIconContextMenu
            for (int i = 0; i < NotifyIconContextMenu.Items.Count; i++)
            {
                if (NotifyIconContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    NotifyIconContextMenu.Items[i].Click += Application_MenuItem_Click;
                }
            }

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            KeyboardHook.KeyUp += KeyboardHook_KeyUp;
            KeyboardHook.HookStart();
        }

        #endregion Initialize_Events

        #endregion Initialize

        #region ReloadLanguage

        private void ReloadLanguage()
        {
            InitializeLanguage();
            InitializeSampleItems();
            GC.Collect();
        }

        #endregion ReloadLanguage

        #region Setting

        private void SaveSetting()
        {
            File.WriteAllText(Setting.Setting.KEY_SETTING_PATH, Script.Object.ToString());
        }

        private void LoadSetting()
        {
            try
            {
                Script.Object.SetScript(File.ReadAllText(Setting.Setting.KEY_SETTING_PATH));
            }
            catch (Exception ex)
            {
                if (DarkMessageBox.ShowError($"{Language.Language.Message_Error_LoadSetting_Fail}\n{ex.Message.Split('\n')[0]}",
                    Setting.Setting.TITLE_NAME, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    Script.Object.Reset();
                    SaveSetting();
                }
            }
        }

        #endregion Setting

        #region ToolStripMenuItem_Click

        #region KeySetting_MenuItem_Click

        private void KeySetting_MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            if (menu.Tag != null && menu.Tag.GetType().FullName == typeof(KeyObject).FullName) // Sample
            {
                KeyObject SampleScript = (KeyObject)menu.Tag;
                KeyObject script = Script.Object.GetKeyObject(SelectedKey, false);
                script.KeyScript = SampleScript.KeyScript;
                script.Ignore = SampleScript.Ignore;
            }
            else if (menu == CustomKeyToolStripMenuItem) // Custom Key
            {
                Open_KeySetting_Dialog();
            }
            else if (menu == MacroToolStripMenuItem) // Macro
            {
                Open_MacroSetting_Dialog();
            }
            else if(menu == KeyIgnoreToolStripMenuItem) // Key Ignore
            {
                SetKeyIgnore(!menu.Checked);
            }

            SaveSetting();
        }

        #endregion KeySetting_MenuItem_Click

        #region Application_MenuItem_Click

        private void Application_MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            switch (menu.Tag)
            {
                case "Open":
                    Show();
                    break;

                case "Exit":
                    Application.Exit();
                    break;

                case "Info":
                    if (InfoShowed)
                        return;

                    InfoShowed = true;
                    using (ProgramInformation dialog = new ProgramInformation())
                    {
                        dialog.ShowDialog();
                    }
                    InfoShowed = false;
                    break;

                case "JsonEdit":
                    if (DarkMessageBox.ShowWarning(Language.Language.Message_Warning_Menu,
                        Setting.Setting.TITLE_NAME, DarkDialogButton.YesNo) != DialogResult.Yes)
                        return;

                    using (JsonEditorDialog jsonDialog = new JsonEditorDialog(Script))
                    {
                        if (jsonDialog.ShowDialog() == DialogResult.OK)
                        {
                            LoadSetting();
                        }
                        GC.Collect();
                    }
                    break;

                case "StartProgram":
                    Setting.Setting.StartProgram = !StartProgramMenuItem.Checked;
                    StartProgramMenuItem.Checked = Setting.Setting.StartProgram;
                    break;
            }
        }

        #endregion Application_MenuItem_Click

        #region Language_MenuItem_Click

        private void Language_MenuItem_Click(object sender, EventArgs e)
        {
            string code = (string)((ToolStripMenuItem)sender).Tag;
            Setting.Setting.Languages.Change(code);
            Script.Object.Language = code;

            SaveSetting();
            ReloadLanguage();
        }

        #endregion Language_MenuItem_Click

        #endregion ToolStripMenuItem_Click

        #region Open_KeySetting_Dialog

        private void Open_KeySetting_Dialog()
        {
            Keys keys = SelectedKey;
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

        #endregion Open_KeySetting_Dialog

        #region Open_MacroSetting_Dialog

        private void Open_MacroSetting_Dialog()
        {
            if (DarkMessageBox.ShowWarning(Language.Language.Message_Warning_Menu,
                Setting.Setting.TITLE_NAME, DarkDialogButton.YesNo) != DialogResult.Yes)
                return;

            Keys keys = SelectedKey;
            KeyObject keyObject = Script.Object.GetKeyObject(keys, false);
            KeyScript keyScript;

            if (keyObject != null && keyObject.KeyScript != null && keyObject.KeyScript.Length >= 1)
                keyScript = keyObject.KeyScript[0];
            else
                keyScript = (keyObject.KeyScript = new KeyScript[] { new KeyScript() })[0];

            using (Forms.Dialogs.Macro.MacroSettingDialog dialog = new Forms.Dialogs.Macro.MacroSettingDialog(keyScript))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }

            GC.Collect(1);
        }

        #endregion

        #region NumPadUI_MouseClick

        private void NumPadUI_MouseClick(Keys Key, MouseButtons Button)
        {
            SelectedKey = Key;
            Set_NUMContextMenu_Checked();
            NUMContextMenu.Show(MousePosition);
        }

        #endregion NumPadUI_MouseClick

        #region Set_NUMContextMenu_Checked

        private void Set_NUMContextMenu_Checked()
        {
            bool s = false;

            Keys keys = SelectedKey;
            KeyObject keyObject = Script.Object.GetKeyObject(keys, false);

            keyObject.Key = 0;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string kobj = serializer.Serialize(keyObject);
            keyObject.Key = keys;

            // Sample
            for (int i = 0; i < NUMContextMenu.Items.Count; i++)
            {
                if (NUMContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    KeyObject menuObject = (KeyObject)NUMContextMenu.Items[i].Tag;
                    if (((ToolStripMenuItem)NUMContextMenu.Items[i]).Checked = serializer.Serialize(menuObject) == kobj)
                        s = true;
                }
            }

            // Custom key
            if (!s && keyObject.KeyScript != null &&
                keyObject.KeyScript.Length >= 1 && 
                (keyObject.KeyScript[0].SendKeys != null ||
                keyObject.KeyScript[0].VirtualKey != null))
                CustomKeyToolStripMenuItem.Checked = true;

            // Macro
            if (keyObject.KeyScript != null &&
                keyObject.KeyScript.Length >= 1 &&
                keyObject.KeyScript[0] != null &&
                keyObject.KeyScript[0].Macro != null)
            {
                MacroToolStripMenuItem.Checked = true;
            }

            // KeyIgnore
            KeyIgnoreToolStripMenuItem.Checked = keyObject.Ignore;
        }

        #endregion Set_NUMContextMenu_Checked

        #region NotifyIcon

        #region NotifyIcon_MouseClick

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
            else
                NotifyIconContextMenu.Show(MousePosition);
        }

        #endregion NotifyIcon_MouseClick

        #endregion NotifyIcon

        #region CheckUpdate

        private void CheckUpdate()
        {
            Thread thread = new Thread(() =>
            {
                if (Updater.Updater.CheckUpdates())
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        Updater.Updater.StartUpdate();
                    }));
                }
            })
            {
                IsBackground = true
            };
            thread.Start();
        }

        #endregion

        #region KeyIgnore

        private void SetKeyIgnore(bool ignore)
        {
            Keys keys = SelectedKey;
            Script.Object.GetKeyObject(keys, false).Ignore = ignore;
        }

        #endregion
    }
}