using NUMC.Forms.Dialogs.Macro;
using System.Diagnostics;
using System.Windows.Forms;

namespace NUMC.Script._Macro
{
    public class RUN_FILE : IMacroModule
    {
        public string BUTTON_NAME => Language.Language.MacroSettingDialog_RunFile;

        public bool GET_FULL_CODE => false;

        public char MODULE_NAME => 'R';

        public bool CODE_RESULT(string DATA, ref string[] FULL_CODE, out string NAME, out string RCODE)
        {
            GetCode(DATA, out string file, out string args);

            NAME = null;
            RCODE = null;

            if (file == null || string.IsNullOrWhiteSpace(file))
                return false;
            NAME = $"{Language.Language.MacroSettingDialog_RunFile} ({DATA.Replace('|', ' ')})";
            RCODE = CreateCode(file, args);

            return true;
        }

        public void RUN_CODE(string DATA, ref string[] FULL_CODE, ref long CURRENT_LINE)
        {
            GetCode(DATA, out string file, out string args);
            if (string.IsNullOrWhiteSpace(file))
                return;
            try
            {
                if (string.IsNullOrWhiteSpace(args))
                    Process.Start(file);
                else
                    Process.Start(file, args);
            }
            catch { }
        }

        public bool SHOW_DIALOG(ref string[] FULL_CODE, out string NAME, out string RCODE)
        {
            using (RunFileDialog dialog = new RunFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.Path))
                {
                    NAME = $"{Language.Language.MacroSettingDialog_RunFile} ({dialog.Path} {dialog.Args})";
                    RCODE = CreateCode(dialog.Path, dialog.Args);

                    return true;
                }
            }

            NAME = null;
            RCODE = null;

            return false;
        }

        private string CreateCode(string file, string args)
        {
            return "R" + file + '|' + args;
        }

        private void GetCode(string data, out string file, out string args)
        {
            string[] sp = data.Split('|');

            file = null;
            args = null;

            if (sp.Length >= 1)
            {
                file = sp[0];

                if (sp.Length >= 2 && !string.IsNullOrWhiteSpace(sp[1]))
                    args = sp[1];
            }
        }
    }

    public class CHANGE_SETTING : IMacroModule
    {
        public string BUTTON_NAME => Language.Language.MacroSettingDialog_ChangeSetting;

        public bool GET_FULL_CODE => false;

        public char MODULE_NAME => '[';

        public bool CODE_RESULT(string DATA, ref string[] FULL_CODE, out string NAME, out string RCODE)
        {
            NAME = null;
            RCODE = null;

            if (DATA == null || string.IsNullOrWhiteSpace(DATA))
                return false;

            NAME = $"{Language.Language.MacroSettingDialog_ChangeSetting} ({DATA})";
            RCODE = CreateCode(DATA);

            return true;
        }

        public void RUN_CODE(string DATA, ref string[] FULL_CODE, ref long CURRENT_LINE)
        {
            Handler.Handler.LoadSettings(DATA);
        }

        public bool SHOW_DIALOG(ref string[] FULL_CODE, out string NAME, out string RCODE)
        {
            using (SetSettingDialog dialog = new SetSettingDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.Path))
                {
                    NAME = $"{Language.Language.MacroSettingDialog_ChangeSetting} ({dialog.Path})";
                    RCODE = CreateCode(dialog.Path);

                    return true;
                }
            }

            NAME = null;
            RCODE = null;

            return false;
        }

        private string CreateCode(string file)
        {
            return "[" + file;
        }
    }
}