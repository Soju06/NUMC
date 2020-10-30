using NUMC.Design;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace NUMC.Language
{
    public static class Languages
    {
        public static void Change(string code)
        {
            string scode = Support[0, 1];

            if (code.ToLower() == "auto" || string.IsNullOrWhiteSpace(code))
            {
                code = CultureInfo.CurrentCulture.Name;
            }

            for (int i = 0; i < Support.GetLength(0); i++)
            {
                if (Support[i, 0].Contains(code))
                {
                    scode = Support[i, 1];
                    break;
                }
            }

            Language.resourceMan = new System.Resources.ResourceManager($"NUMC.Language.{scode}", typeof(Language).Assembly);
        }

        public static string Import()
        {
            string s = Language.resourceMan.BaseName;
            for (int i = 0; i < Support.GetLength(0); i++)
            {
                if (s == $"NUMC.Language.{Support[i, 1]}")
                {
                    return Support[i, 0];
                }
            }

            return Support[0, 0];
        }

        public static ToolStripItem[] GetToolStripItems()
        {
            var langItems = new List<ToolStripItem>();

            string cl = Import();

            for (int i = 0; i < Support.GetLength(0); i++)
            {
                var item = new ToolStripMenuItem(Support[i, 2]) { Tag = Support[i, 0], BackColor = Styles.Control.BackgroundColor };

                item.Checked = (string)item.Tag == cl;

                langItems.Add(item);
            }

            return langItems.ToArray();
        }

        public static readonly string[,] Support = new string[2, 3]
        {
                {
                    "en-US",
                    "Language",
                    "English"
                },
                {
                    "ko-KR",
                    "ko-KR",
                    "한국어"
                }
        };
    }
}