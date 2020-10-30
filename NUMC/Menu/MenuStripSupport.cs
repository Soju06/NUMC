using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NUMC.Menu
{
    public static class MenuStripSupport
    {
        public static void AddClickEventAdding(ToolStripMenuItem src, IList<ToolStripItem> items, EventHandler clickEvent)
        {
            AddClickEvent(items, clickEvent);
            src.DropDownItems.AddRange(items.ToArray());
        }

        public static ToolStripItem SubItamTagSearch(IList<ToolStripItem> src, object tag)
        {
            for (int i = 0; i < src.Count; i++)
                if (src[i].Tag == tag)
                    return src[i];

            return null;
        }

        public static ToolStripItem SubItamTagSearch(ToolStripItemCollection src, object tag)
        {
            for (int i = 0; i < src.Count; i++)
                if (src[i].Tag == tag)
                    return src[i];

            return null;
        }

        public static void AddClickEvent(IList<ToolStripItem> src, EventHandler clickEvent)
        {
            for (int i = 0; i < src.Count; i++)
                src[i].Click += clickEvent;
        }

        public static void AddClickEvent(ToolStripItemCollection src, EventHandler clickEvent)
        {
            for (int i = 0; i < src.Count; i++)
                src[i].Click += clickEvent;
        }
    }
}