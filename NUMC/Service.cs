using NUMC.Keyboard;
using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NUMC
{
    public class Service
    {
        private Main Main;
        private Script.Script Script;
        private Client.Client Client;

        private List<IKeyMenu> KeyMenus;
        private List<INotifyMenu> NotifyMenus;
        private List<IApplicationMenu> ApplicationMenus;

        public StateCode State { get; private set; }

        public Service()
        {
            service = this;

            InitializeScript();
            InitializePlugin();
            InitializePluginExp();
            InitializeApplication();
            InitializeKeyboardHook();
            InitializeClient();
        }

        #region Initialize_Script

        private void InitializeScript()
        {
            Script = new Script.Script();
            Script.Loaded += Script_Loaded;
            Script.Load(Setting.Setting.KeySettingPath, false);
        }

        #endregion Initialize_Script

        #region Initialize_Menu

        private void InitializePluginExp()
        {
            Plugin.PluginExp.PluginExpInitialize(KeyMenus, Script);
            Plugin.PluginExp.PluginExpInitialize(NotifyMenus, Script);
            Plugin.PluginExp.PluginExpInitialize(ApplicationMenus, Script);
        }

        #endregion Initialize_Menu

        #region Initialize_Plugin

        public void InitializePlugin()
        {
            Plugin.Plugin.Initialize();

            KeyMenus = Plugin.Plugin.ExtractPlugin<IKeyMenu>();
            NotifyMenus = Plugin.Plugin.ExtractPlugin<INotifyMenu>();
            ApplicationMenus = Plugin.Plugin.ExtractPlugin<IApplicationMenu>();
        }

        #endregion Initialize_Plugin

        #region Initialize_KeyboardHook

        private void InitializeKeyboardHook()
        {
            KeyboardHook.KeyDown += Keyboard_KeyDown;
            KeyboardHook.KeyUp += Keyboard_KeyUp;
            KeyboardHook.HookStart();
        }

        #endregion Initialize_KeyboardHook

        #region Initialize_Application

        private void InitializeApplication()
        {
            WinUtils.WinAPI.SetProcessDpiAwareness(WinUtils.DpiAwareness.None);
            Application.ApplicationExit += Application_ApplicationExit;
            Main = new Main(this);
        }

        #endregion Initialize_Application

        #region Initialize_Client

        private void InitializeClient()
        {
            Client = new Client.Client();

            Client.Initialize();
        }

        #endregion Initialize_Client

        #region KeyboardHook

        public void Start() {
            State = StateCode.Running;
        }

        public void Pause()
        {
            State = StateCode.Paused;
            Script?.StopInput();
        }

        public void Stop()
        {
            if (State == StateCode.Stoped)
                return;

            State = StateCode.Stoped;
            Script?.StopInput();
            KeyboardHook.HookEnd();
        }

        private bool Keyboard_KeyUp(Keys key) => Script == null || State != 0 || Script.Run(key, false);

        private bool Keyboard_KeyDown(Keys key) => Script == null || State != 0 || Script.Run(key, true);

        #endregion KeyboardHook

        #region Application

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Stop();
            Save();
        }

        public void Show() => Main?.Show();

        #endregion Application

        #region Script

        private void Script_Loaded(ScriptObject script, string path)
        {
            Language.Languages.Change(Script.GetObject().Language);
            Main?.ReloadLanguage();
        }

        public void Save() => Script?.Save(Setting.Setting.KeySettingPath);

        public void Load(bool save = true)
        {
            if (save) Save(); Script?.Load(Setting.Setting.KeySettingPath);
        }

        public void Load(string path, bool save = true)
        {
            if (save) Save(); Script?.Load(path);
        }

        #endregion Script

        #region static Servic

        private static Service service;

        public static Service GetService() => service;

        #endregion static Servic

        #region Get

        public Main GetMain() => Main;

        public Script.Script GetScript() => Script;

        public List<IKeyMenu> GetKeyMenus() => KeyMenus;

        public List<INotifyMenu> GetNotifyMenus() => NotifyMenus;

        public List<IApplicationMenu> GetApplicationMenus() => ApplicationMenus;

        #endregion Get

        public enum StateCode {
            Running = 0,
            Paused = 1,
            Stoped = 2
        }
    }
}