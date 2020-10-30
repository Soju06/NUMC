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
        private IKeyMenuModule[] KeyMenuModules;
        private INotifyMenuModule[] NotifyMenuModules;
        private IApplicationMenuModule[] ApplicationMenuModules;

        public Main()
        {
            InitializeComponent();
            InitializeForm();
            InitializeHandler();
            InitializeSetting();
            InitializeLanguage();
            InitializeModule();
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
            titleBar.MaximizeBox = false;
            titleBar.MinimizeBox = false;

            notifyIcon.Icon = System.Drawing.Icon.FromHandle(Design.Images.NUMC_SMALL_ICON.GetHicon());
            Icon = System.Drawing.Icon.FromHandle(Design.Images.NUMC_ICON_24px.GetHicon());
        }

        #endregion Initialize_Form

        #region Initialize_Language

        private void InitializeLanguage()
        {
            Text = Setting.Setting.TitleName;
            titleBar.Title = Setting.Setting.GetTitleName(Language.Language.Main_Title);
        }

        #endregion Initialize_Language

        #region Initialize_Notify_Menu

        private void InitializeNotifyMenu()
        {
            NotifyIconContextMenu.Items.Clear();

            for (int i = 0; i < NotifyMenuModules.Length; i++)
                NotifyIconContextMenu.Items.AddRange(NotifyMenuModules[i].Menus);
        }

        #endregion Initialize_Notify_Menu

        #region Initialize_Application_Menu

        private void InitializeApplicationMenu()
        {
            ApplicationContextMenu.Items.Clear();

            for (int i = 0; i < ApplicationMenuModules.Length; i++)
                ApplicationContextMenu.Items.AddRange(ApplicationMenuModules[i].Menus);
        }

        #endregion Initialize_Application_Menu



        #region Initialize_NUM_Menu

        private void InitializeNUMMenu()
        {
            NUMContextMenu.Items.Clear();

            for (int i = 0; i < KeyMenuModules.Length; i++)
                NUMContextMenu.Items.AddRange(KeyMenuModules[i].Menus);

            // InitializeSampleItems
            NUMContextMenu.Items.AddRange(NUMC.Script.Menu.GetSampleItems());
        }

        #endregion Initialize_NUM_Menu



        #region Initialize_Menu

        private void InitializeMenu()
        {
            InitializeApplicationMenu();
            InitializeNotifyMenu();
            InitializeNUMMenu();

            var startProgramItem = (ToolStripMenuItem)MenuStripSupport.SubItamTagSearch(NotifyIconContextMenu.Items, "StartProgram");

            if(startProgramItem != null)
                startProgramItem.Checked = Setting.Setting.StartProgram;
        }

        #endregion Initialize_Menu

        #region Initialize_Module

        public void InitializeModule()
        {
            KeyMenuModules = Plugin.Handler.ExtractPlugin<IKeyMenuModule>();
            NotifyMenuModules = Plugin.Handler.ExtractPlugin<INotifyMenuModule>();
            ApplicationMenuModules = Plugin.Handler.ExtractPlugin<IApplicationMenuModule>();
        }

        #endregion Initialize_Module

        #region Initialize_Setting

        private void InitializeSetting()
        {
            if (File.Exists(Setting.Setting.KeySettingPath))
            {
                LoadSetting();
            }
            else
            {
                Script.Object.Reset();
                SaveSetting();
            }

            Language.Languages.Change(Script.Object.Language);
        }

        #endregion Initialize_Setting

        #region Initialize_Events

        private void InitializeEvents()
        {
            KeyboardLayout.MouseClick += Layout_MouseClick;

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            KeyboardHook.KeyUp += KeyboardHook_KeyUp;
            KeyboardHook.HookStart();
        }

        #endregion Initialize_Events

        #region Initialize_Handler

        private void InitializeHandler()
        {
            Handler.Handler.LoadSetting += Handler_LoadSetting;
            Handler.Handler.G_etScript += Handler_GetScript;
            Handler.Handler.Show += Handler_Show;
            Handler.Handler.Setting.Load += Setting_Load;
            Handler.Handler.Setting.Save += Setting_Save;
        }

        #endregion Initialize_Handler

        #endregion Initialize

        #region ReloadLanguage

        private void ReloadLanguage()
        {
            InitializeLanguage();
            InitializeMenu();
            GC.Collect();
        }

        #endregion ReloadLanguage

        #region Setting

        private void SaveSetting()
        {
            File.WriteAllText(Setting.Setting.KeySettingPath, Script.Object.ToString());
        }

        private void LoadSetting()
        {
            try
            {
                Script.Object.SetScript(File.ReadAllText(Setting.Setting.KeySettingPath));
            }
            catch (Exception ex)
            {
                if (MessageBox.Show($"{Language.Language.Message_Error_LoadSetting_Fail}\n{ex.Message.Split('\n')[0]}",
                    Setting.Setting.TitleName, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;

            var menu = (ToolStripMenuItem)sender;

            if (menu.Tag != null)
            {
                if (menu.Tag.GetType() == typeof(KeyObject)) // Sample
                {
                    var SampleScript = (KeyObject)menu.Tag;
                    var script = Script.Object.GetKeyObject(SelectedKey, false);
                    script.KeyScript = SampleScript.KeyScript;
                    script.Ignore = SampleScript.Ignore;
                }
            }

            SaveSetting();
        }

        #endregion KeySetting_MenuItem_Click

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

            for (int i = 0; i < KeyMenuModules.Length; i++)
            {
                try
                {
                    KeyMenuModules[i].MenuClicking(keyObject, keys);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Language.Language.Module_Exception, KeyMenuModules[i].GetType().Name, ex.Message, ex),
                        Setting.Setting.TitleName);
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
                Setting.Setting.KeySettingPath = path;
                InitializeSetting();
                ReloadLanguage();
            }));
        }

        private Script.Script Handler_GetScript()
        {
            return Script;
        }

        private void Handler_Show()
        {
            Show();
        }

        private void Setting_Load()
        {
            InitializeSetting();
            ReloadLanguage();
        }

        private void Setting_Save()
        {
            SaveSetting();
        }

        #endregion Handler
    }
}