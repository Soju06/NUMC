using System;

namespace NUMC.Handler
{
    public class Handler
    {
        public static event LoadSetting LoadSetting;

        internal static event GetScript G_etScript;

        public static void LoadSettings(string path)
        {
            LoadSetting(path);
        }

        public static Script.ScriptObject GetScript()
        {
            Delegate[] delegates = G_etScript.GetInvocationList();

            if (delegates.Length >= 1)
                return (Script.ScriptObject)delegates[0].DynamicInvoke();

            return null;
        }
    }

    public delegate void LoadSetting(string path);

    internal delegate Script.Script GetScript();
}