using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Expansion
{
    public static class AssemblyExpansion
    {
        public static AssemblyTitleAttribute GetTitleAttribute(this Assembly assembly) =>
            GetAttribute<AssemblyTitleAttribute>(assembly);

        public static AssemblyDescriptionAttribute GetDescriptionAttribute(this Assembly assembly) =>
            GetAttribute<AssemblyDescriptionAttribute>(assembly);

        public static AssemblyCompanyAttribute GetCompanyAttribute(this Assembly assembly) =>
            GetAttribute<AssemblyCompanyAttribute>(assembly);

        public static AssemblyVersionAttribute GetVersionAttribute(this Assembly assembly) =>
            GetAttribute<AssemblyVersionAttribute>(assembly);

        public static T GetAttribute<T>(this Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : default;
        }
    }
}
