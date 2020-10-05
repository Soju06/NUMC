using System.Collections.Generic;

namespace NUMC.Menu
{
    public static class Module
    {
        private static List<IMM> Modules;

        public static IMM[] BASIC_MACRO_MODULE
        {
            get
            {
                return new IMM[]
                {
                    new Modules.CustomKey(),
                    new Modules.Macro(),
                    new Modules.KeyIgnore()
                };
            }
        }

        public static IMM[] GetModules()
        {
            if (Modules == null)
            {
                Modules = new List<IMM>();

                Modules.AddRange(BASIC_MACRO_MODULE);
            }

            return Modules.ToArray();
        }
    }
}