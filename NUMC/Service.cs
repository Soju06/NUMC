using Microsoft.Win32;
using NUMC.Keyboard;
using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput;

namespace NUMC {
    public class Service {
        private Main Main;
        private Script.Script Script;
        private Config.Config Config;
        private Client.Client Client;
        private readonly IInputSimulator InputSimulator = new InputSimulator();

        private List<IKeyMenu> KeyMenus;
        private List<INotifyMenu> NotifyMenus;
        private List<IApplicationMenu> ApplicationMenus;

        public StateCode State { get; private set; }

        public Service() {
            service = this;
            InitializeConfig();
            InitializeScript();
            InitializePlugin();
            InitializePluginExp();
            InitializeApplication();
            InitializeKeyboardHook();
            InitializeClient();
        }

        #region Initialize_Config

        private void InitializeConfig()
        {
            Config = new();
            Config.Loaded += Config_Loaded;
            Config.Load();
        }

        #endregion Initialize_Config

        #region Initialize_Script

        private void InitializeScript() {
            Script = new(Config, this);
            Script.Initialize();
        }

        #endregion Initialize_Script

        #region Initialize_Menu

        private void InitializePluginExp()
        {
            Plugin.PluginExp.PluginExpInitialize(KeyMenus, service);
            Plugin.PluginExp.PluginExpInitialize(NotifyMenus, service);
            Plugin.PluginExp.PluginExpInitialize(ApplicationMenus, service);
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

        #region Service

        public void Start() => State = StateCode.Running;

        public void Pause() {
            State = StateCode.Paused;
            Script?.StopInput();
        }

        public void Stop() {
            if (State == StateCode.Stoped) return;
            State = StateCode.Stoped;
            Script?.StopInput();
            KeyboardHook.HookEnd();
        }

        public enum StateCode {
            Running = 0,
            Paused = 1,
            Stoped = 2
        }

        #endregion

        #region KeyboardHook

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

        private void Config_Loaded(Config.Config config, string path) {
            Language.Languages.Change(Config?.Language);
            Main?.ReloadLanguage();
        }

        public void Save() => Config?.Save();

        public void Load(bool save = true) {
            if (save) Save(); 
            Config?.Load();
        }

        public void Load(string path, bool save = true) {
            if (save) Save();
            Config?.Load(path);
        }

        #endregion Script

        #region static Service

        private static Service service;

        public static Service GetService() => service;

        #endregion static Service

        #region Get

        public Main GetMain() => Main;
        public Config.Config GetConfig() => Config;
        public Script.Script GetScript() => Script;
        public IInputSimulator GetInputSimulator() => InputSimulator;
        public List<IKeyMenu> GetKeyMenus() => KeyMenus;
        public List<INotifyMenu> GetNotifyMenus() => NotifyMenus;
        public List<IApplicationMenu> GetApplicationMenus() => ApplicationMenus;

        #endregion Get

        #region Title

        public static string TitleName = $"NUMC - {Language.Language.Setting_Portable}" + (Constant.DEV_MODE ? " developer mode" : "");

        public static string GetTitleName(string subtitle) =>
            string.Format("NUMC {0} - {1}{2}", subtitle, Language.Language.Setting_Portable, (Constant.DEV_MODE ? " developer mode" : ""));

        #endregion

        #region StartProgram

        private static RegistryKey _startProgramReg;
        private static RegistryKey StartProgramReg {
            get => _startProgramReg ??= Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); 
        }

        public static bool StartProgram {
            get {
                try {
                    return StartProgramReg.GetValue(TitleName) != null;
                } catch { }
                return false;
            }
            set {
                try {
                    if (value) StartProgramReg.SetValue(TitleName, Application.ExecutablePath.Replace('/', '\\'));
                    else StartProgramReg.DeleteValue(TitleName, false);
                } catch (Exception ex) {
                    MessageBox.Show($"{Language.Language.Message_Error_ChangeStartProgram_Fail}\n{ex.Message}", TitleName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}