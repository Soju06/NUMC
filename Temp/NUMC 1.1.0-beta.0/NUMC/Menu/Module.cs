using System.Collections.Generic;

namespace NUMC.Menu
{
    public static class Module
    {
        private static List<IMenuModule> Modules;

        public static IMenuModule[] BASIC_MACRO_MODULE
        {
            get
            {
                return new IMenuModule[]
                {
                    new Modules.CustomKey(),
                    new Modules.Macro(),
                    new Modules.KeyIgnore()
                };
            }
        }

        public static IMenuModule[] GetModules()
        {
            if (Modules == null)
            {
                Modules = new List<IMenuModule>();

                Modules.AddRange(BASIC_MACRO_MODULE);

                var items = Plugin.Handler.ExtractPlugin<IMenuModule>();

                if(items != null)
                    Modules.AddRange(items);
            }

            return Modules.ToArray();
        }
    }
}