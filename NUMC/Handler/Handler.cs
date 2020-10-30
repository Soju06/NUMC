using System;
using System.IO;

namespace NUMC.Handler
{
    public static class Handler
    {
        public static event LoadSettingHandler LoadSetting;

        public static event ShowHandler Show;

        internal static event GetScriptHandler G_etScript;

        public static void LoadSettings(string path)
        {
            if (!File.Exists(path))
                return;

            LoadSetting?.Invoke(path);
        }

        public static Script.Script GetScript()
        {
               Delegate[] delegates = G_etScript.GetInvocationList();

            if (delegates.Length >= 1)
                return (Script.Script)delegates[0].DynamicInvoke();

            return null;
        }

        public static void Showing()
        {
            Show?.Invoke();
        }

        public static class Setting
        {
            public static event ShowHandler Save;
            public static event ShowHandler Load;

            public static void Saving() =>
                Save?.Invoke();

            public static void Loading() =>
                Load?.Invoke();

            public delegate void SaveHandler();
            public delegate void LoadHandler();
        }

        public delegate void ShowHandler();
        public delegate void LoadSettingHandler(string path);
        internal delegate Script.Script GetScriptHandler();
    }
}