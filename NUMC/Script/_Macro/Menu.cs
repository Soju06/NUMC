using System.Collections.Generic;

namespace NUMC.Script._Macro
{
    public class Menu
    {
        public static IMacroModule[] BASIC_MACRO_MODULE
        {
            get
            {
                return new IMacroModule[]
                {
                    new RUN_FILE()
                };
            }
        }

        public static IMacroModule[] FILE_MACRO_MODULES
        {
            get
            {
                return null;
            }
        }

        private static List<IMacroModule> modules;

        public static List<IMacroModule> GET_ALL_MACRO_MODULE()
        {
            if (modules != null)
                return modules;

            modules = new List<IMacroModule>();

            modules.AddRange(BASIC_MACRO_MODULE);

            return modules;
        }
    }
}