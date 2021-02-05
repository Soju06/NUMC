using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NUMC.Setting
{
    public class Setting
    {
        public static string KeySettingPath = Path.Combine(Application.StartupPath, $"{Process.GetCurrentProcess().ProcessName}{Constant.Setting.FileExtension}");

        public static string TitleName = $"NUMC - {Language.Language.Setting_Portable}" + (Constant.DEV_MODE ? " developer mode" : "");

        public static string GetTitleName(string subtitle) =>
            string.Format("NUMC {0} - {1}{2}", subtitle, Language.Language.Setting_Portable, (Constant.DEV_MODE ? " developer mode" : ""));

        private static readonly RegistryKey RunRegKey;

        static Setting()
        {
            try
            {
                RunRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Language.Language.Message_Error_CheckStartProgram_Fail}\n{ex.Message}", TitleName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool StartProgram
        {
            get
            {
                try
                {
                    return RunRegKey.GetValue(TitleName) != null;
                }
                catch { }
                return false;
            }
            set
            {
                try
                {
                    if (value)
                        RunRegKey.SetValue(TitleName, Application.ExecutablePath.Replace('/', '\\'));
                    else
                        RunRegKey.DeleteValue(TitleName, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Language.Language.Message_Error_ChangeStartProgram_Fail}\n{ex.Message}", TitleName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}