using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NUMC.Client
{
    public class Version : IFormattable
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; } 
        public int Revision { get; set; }
        public VersionType BuildType { get; set; }

        public static Version Parse(string version)
        {
            if (version != null) {
                string[] v = version.Split('.');
                if (v.Length == 4) {
                    var ver = new Version();
                    var e = VersionType.release;
                    if (int.TryParse(Regex.Replace(v[0], @"\D", ""), out int a) &&
                        int.TryParse(Regex.Replace(v[1], @"\D", ""), out int b) &&
                        int.TryParse(Regex.Replace(v[2], @"\D", ""), out int c) &&
                        int.TryParse(Regex.Replace(v[3], @"\D", ""), out int d) &&
                        (!v[2].Contains('-') || Enum.TryParse(Regex.Replace(v[2],
                        @"[^a-zA-Z]", "").ToLower(), out e))) {
                        ver.Major = a; ver.Minor = b;
                        ver.Build = c; ver.Revision = d;
                        ver.BuildType = e;
                        Debug.WriteLine($"version parse\tv:\t{version}");
                        return ver;
                    }
                }
            }
            Debug.WriteLine($"version parse failed\tv:\t{version}");
            return null;
        }

        public static bool TryParse(string version, out Version v) => (v = Parse(version)) != null;

        new public string ToString() => $"{Major}.{Minor}.{Build}-{BuildType}.{Revision}";

        public string ToString(string format, IFormatProvider formatProvider) => ToString();

        public static bool operator >(Version version, Version version1) => 
            version.Major >= version1.Major &&
            version.Minor >= version1.Minor && 
            version.Build >= version1.Build &&
            version.BuildType >= version1.BuildType &&
            version.Revision >= version1.Revision;

        public static bool operator <(Version version, Version version1) => !(version > version1);
    }

    public class VersionObject<T>
    {
        public VersionObject() { }
        public VersionObject(T obj, Version version) { Object = obj; Version = version; }

        public T Object { get; set; }
        public Version Version { get; set; }
    }

    public enum VersionType { release = 2, beta = 1, alpha = 0, }
}
