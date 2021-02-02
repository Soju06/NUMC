using Hook;
using NUMC.Forms.Dialogs;
using NUMC.Menu;
using NUMC.Script;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NUMC
{
    public partial class Main : Design.Form
    {
        private readonly Script.Script Script = new Script.Script();

        private Keys SelectedKey;
        private bool InfoShowed = false;
        private ToolStripMenuItem StPgItem = null;

        public Main()
        {
            InitializeComponent();
            InitializeForm();
            InitializeHandler();
            InitializeSetting();
            InitializeLanguage();
            InitializeLanguageMenu();
            InitializeNotifyMenu();
            InitializeMenu();
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

        #endregion FormEvents

        #region KeyboardHook

        private bool KeyboardHook_KeyUp(int vkCode)
        {
            if (Script.Object.WVKeys.Contains((Keys)vkCode))
            {
                Console.WriteLine("KeyUp; {0}", (Keys)vkCode);
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
                Console.WriteLine("KeyDown; {0}", (Keys)vkCode);
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
            titleBar.MaximizeBox = false;
            titleBar.MinimizeBox = false;

            notifyIcon.Icon = System.Drawing.Icon.FromHandle(Design.Images.NUMC_SMALL_ICON.GetHicon());
            Icon = System.Drawing.Icon.FromHandle(Design.Images.NUMC_ICON_24px.GetHicon());
        }

        #endregion Initialize_Form

        #region Initialize_Language

        private void InitializeLanguage()
        {
            JsonEditToolStripMenuItem.Text = Language.Language.Main_JsonEditor;
            ExitToolStripMenuItem.Text = Language.Language.Program_Exit;

            NotifyIconContextMenu.Items.Clear();
            NotifyIconContextMenu.AddItem(Language.Language.Program_Open, "Open");
            NotifyIconContextMenu.AddItem(Language.Language.Main_StartProgram, "StartProgram");
            NotifyIconContextMenu.AddItem(Language.Language.Program_Info, "Info");
            NotifyIconContextMenu.AddSeparator();
            NotifyIconContextMenu.AddItem("Language", "Language");
            NotifyIconContextMenu.AddSeparator();
            NotifyIconContextMenu.AddItem(Language.Language.Program_Exit, "Exit");

            Text = Setting.Setting.TITLE_NAME;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.Main_Title);
        }

        #endregion Initialize_Language

        #region Initialize_Notify_Menu

        private void InitializeNotifyMenu()
        {
            for (int i = 0; i < NotifyIconContextMenu.Items.Count; i++)
                if (NotifyIconContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                    NotifyIconContextMenu.Items[i].Click += Application_MenuItem_Click;
        }

        #endregion Initialize_Notify_Menu

        #region Initialize_Language_Menu

        private void InitializeLanguageMenu()
        {
            ToolStripMenuItem langitem = null;
            for (int i = 0; i < NotifyIconContextMenu.Items.Count; i++)
                if (NotifyIconContextMenu.Items[i].Tag != null && NotifyIconContextMenu.Items[i].Tag.ToString() == "Language")
                    langitem = (ToolStripMenuItem)NotifyIconContextMenu.Items[i];

            langitem.DropDownItems.Clear();

            string cl = Setting.Setting.Languages.Import();

            for (int i = 0; i < Setting.Setting.Languages.Support.GetLength(0); i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(Setting.Setting.Languages.Support[i, 2]) { Tag = Setting.Setting.Languages.Support[i, 0] };

                item.Checked = (string)item.Tag == cl;
                item.Click += Language_MenuItem_Click;

                langitem.DropDownItems.Add(item);
            }
        }

        #endregion Initialize_Language_Menu

        #region Initialize_Menu

        private void InitializeMenu()
        {
            NUMContextMenu.Items.Clear();

            IMenuModule[] modules = Module.GetModules();

            for (int i = 0; i < modules.Length; i++)
            {
                NUMContextMenu.Items.AddRange(modules[i].Menus);
            }

            InitializeSampleItems();

            for (int i = 0; i < NotifyIconContextMenu.Items.Count; i++)
                if (NotifyIconContextMenu.Items[i].Tag != null && NotifyIconContextMenu.Items[i].Tag.ToString() == "StartProgram")
                    StPgItem = (ToolStripMenuItem)NotifyIconContextMenu.Items[i];

            StPgItem.Checked = Setting.Setting.StartProgram;
        }

        #endregion Initialize_Menu

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
        }

        #endregion Initialize_Setting

        #region Initialize_SampleItems

        private void InitializeSampleItems()
        {
            NUMContextMenu.Items.AddRange(NUMC.Script.Menu.GetSampleItems());
        }

        #endregion Initialize_SampleItems

        #region Initialize_Events

        private void InitializeEvents()
        {
            KeyboardLayout.MouseClick += Layout_MouseClick;

            InitializeNUMEvents();

            // ApplicationContextMenu
            for (int i = 0; i < ApplicationContextMenu.Items.Count; i++)
            {
                if (ApplicationContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    ApplicationContextMenu.Items[i].Click += Application_MenuItem_Click;
                }
            }

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            KeyboardHook.KeyUp += KeyboardHook_KeyUp;
            KeyboardHook.HookStart();
        }

        private void InitializeNUMEvents()
        {
            // NUMContextMenu
            for (int i = 0; i < NUMContextMenu.Items.Count; i++)
            {
                if (NUMContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    NUMContextMenu.Items[i].Click += KeySetting_MenuItem_Click;
                }
            }
        }

        #endregion Initialize_Events

        #region Initialize_Handler

        private void InitializeHandler()
        {
            Handler.Handler.LoadSetting += Handler_LoadSetting;
            Handler.Handler.G_etScript += Handler_GetScript;
        }

        #endregion Initialize_Handler

        #endregion Initialize

        #region ReloadLanguage

        private void ReloadLanguage()
        {
            InitializeLanguage();
            InitializeLanguageMenu();
            InitializeNotifyMenu();
            InitializeNUMEvents();
            InitializeMenu();
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
                if (MessageBox.Show($"{Language.Language.Message_Error_LoadSetting_Fail}\n{ex.Message.Split('\n')[0]}",
                    Setting.Setting.TITLE_NAME, System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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

            if (menu.Tag != null)
            {
                if (menu.Tag.GetType() == typeof(KeyObject)) // Sample
                {
                    KeyObject SampleScript = (KeyObject)menu.Tag;
                    KeyObject script = Script.Object.GetKeyObject(SelectedKey, false);
                    script.KeyScript = SampleScript.KeyScript;
                    script.Ignore = SampleScript.Ignore;
                }
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
                    using (JsonEditorDialog jsonDialog = new JsonEditorDialog(Script))
                    {
                        if (jsonDialog.ShowDialog() == DialogResult.OK)
                        {
                            LoadSetting();
                        }
                    }
                    break;

                case "StartProgram":
                    Setting.Setting.StartProgram = !StPgItem.Checked;
                    StPgItem.Checked = Setting.Setting.StartProgram;
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

        #region NumPadUI_MouseClick

        private void Layout_MouseClick(Keys Key, MouseButtons Button)
        {
            SelectedKey = Key;
            Set_NUMContextMenu_Checked();
            NUMContextMenu.Show(MousePosition);
        }

        #endregion NumPadUI_MouseClick

        #region Set_NUMContextMenu_Checked

        private void Set_NUMContextMenu_Checked()
        {
            Keys keys = SelectedKey;
            KeyObject keyObject = Script.Object.GetKeyObject(keys, false);

            for (int i = 0; i < NUMContextMenu.Items.Count; i++)
            {
                if (NUMContextMenu.Items[i].GetType() == typeof(ToolStripMenuItem) && NUMContextMenu.Items[i].Tag != null)
                {
                    // Sample
                    if (NUMContextMenu.Items[i].Tag.GetType() == typeof(KeyObject))
                    {
                        keyObject.Key = 0;
                        JavaScriptSerializer serializer = new JavaScriptSerializer();

                        string kobj = serializer.Serialize(keyObject);
                        keyObject.Key = keys;

                        KeyObject menuObject = (KeyObject)NUMContextMenu.Items[i].Tag;
                        ((ToolStripMenuItem)NUMContextMenu.Items[i]).Checked = serializer.Serialize(menuObject) == kobj;
                    }
                }
            }

            IMenuModule[] modules = Module.GetModules();

            for (int i = 0; i < modules.Length; i++)
            {
                try
                {
                    modules[i].MenuClicking(keyObject, keys);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Language.Language.Module_Exception, modules[i].GetType().Name, ex.Message, ex),
                        Setting.Setting.TITLE_NAME);
                }
            }
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
            new Task(delegate ()
            {
                if (Updater.Updater.CheckUpdates())
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        Updater.Updater.StartUpdate();
                    }));
                }
            }).Start();
        }

        #endregion CheckUpdate

        #region Handler

        private void Handler_LoadSetting(string path)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                Setting.Setting.KEY_SETTING_PATH = path;
                InitializeSetting();
                ReloadLanguage();
            }));
        }

        private Script.Script Handler_GetScript()
        {
            return Script;
        }

        #endregion Handler
    }
}