using DarkUI.Forms;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NUMC.Setting
{
    public class Setting
    {
        public static string KEY_SETTING_PATH = Path.Combine(Application.StartupPath, $"{Process.GetCurrentProcess().ProcessName}.json");

        public static string TITLE_NAME = $"NUMC - {Language.Language.Setting_Portable}";

        public static string GetTitleName(string subtitle)
        {
            return string.Format("NUMC {0} - {1}", subtitle, Language.Language.Setting_Portable);
        }

        private static readonly RegistryKey RunRegKey;

        static Setting()
        {
            try
            {
                RunRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            }
            catch (Exception ex)
            {
                DarkMessageBox.ShowError($"{Language.Language.Message_Error_CheckStartProgram_Fail}\n{ex.Message}", TITLE_NAME);
            }
        }

        public static bool StartProgram
        {
            get
            {
                try
                {
                    return RunRegKey.GetValue(TITLE_NAME) != null;
                }
                catch { }
                return false;
            }
            set
            {
                try
                {
                    if (value)
                    {
                        RunRegKey.SetValue(TITLE_NAME, Application.ExecutablePath.Replace('/', '\\'));
                    }
                    else
                    {
                        RunRegKey.DeleteValue(TITLE_NAME, false);
                    }
                }
                catch (Exception ex)
                {
                    DarkMessageBox.ShowError($"{Language.Language.Message_Error_ChangeStartProgram_Fail}\n{ex.Message}", TITLE_NAME);
                }
            }
        }

        public class Languages
        {
            public static void Change(string code)
            {
                string scode = Support[0, 1];

                if (code.ToLower() == "auto" || string.IsNullOrWhiteSpace(code))
                {
                    code = CultureInfo.CurrentCulture.Name;
                }

                for (int i = 0; i < Support.GetLength(0); i++)
                {
                    if (Support[i, 0].Contains(code))
                    {
                        scode = Support[i, 1];
                        break;
                    }
                }

                Language.Language.resourceMan = new System.Resources.ResourceManager($"NUMC.Language.{scode}", typeof(Language.Language).Assembly);
            }

            public static string Import()
            {
                string s = Language.Language.resourceMan.BaseName;
                for (int i = 0; i < Support.GetLength(0); i++)
                {
                    if (s == $"NUMC.Language.{Support[i, 1]}")
                    {
                        return Support[i, 0];
                    }
                }

                return Support[0, 0];
            }

            public static readonly string[,] Support = new string[2, 3]
            {
                {
                    "en-US",
                    "Language",
                    "English"
                },
                {
                    "ko-KR",
                    "ko-KR",
                    "한국어"
                }
            };
        }
    }
}