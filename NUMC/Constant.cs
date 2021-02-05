using System.Windows.Forms;

namespace NUMC
{
    public static class Constant
    {
        public const bool DEV_MODE = false;
        public const string Verison = "2.0.0-alpha.0";

        public static class Form
        {
            public const bool EnableTransparent = false;
            public const int TitleBarHeight = 32;
            public const int PaddingSize = 12;
            public const int Border = 2;

            public static readonly Padding Padding =
                new Padding(PaddingSize, TitleBarHeight + PaddingSize, PaddingSize, PaddingSize);
        }

        public static class Setting
        {
            public const string FileExtension = ".ns";
            public const string FileFilter = "NUMC Setting Files|*.ns";
        }
    }
}