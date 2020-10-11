using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC
{
    public static class Constant
    {
        public static class Form
        {
            public const int TitleBarHeight = 35;
            public const int PaddingSize = 12;

            public static readonly Padding Padding = 
                new Padding(PaddingSize, TitleBarHeight + PaddingSize, PaddingSize, PaddingSize);
        }
    }
}
