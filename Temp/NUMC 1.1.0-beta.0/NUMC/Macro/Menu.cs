using System.Collections.Generic;

namespace NUMC.Macro
{
    public class Menu
    {
        public static IMacroModule[] BASIC_MACRO_MODULE
        {
            get
            {
                return new IMacroModule[]
                {
                    new RUN_FILE(),
                    new CHANGE_SETTING()
                };
            }
        }

        private static List<IMacroModule> modules;

        public static List<IMacroModule> GET_ALL_MACRO_MODULE()
        {
            if (modules != null)
                return modules;

            modules = new List<IMacroModule>();

            modules.AddRange(BASIC_MACRO_MODULE);

            var items = Plugin.Handler.ExtractPlugin<IMacroModule>();

            if (items != null)
                modules.AddRange(items);

            return modules;
        }
    }
}