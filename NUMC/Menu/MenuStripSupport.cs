using NUMC.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NUMC.Menu
{
    public static class MenuStripSupport
    {
        public static void AddClickEventSubItemsAdding(ToolStripMenuItem src, IList<ToolStripItem> items, EventHandler clickEvent) {
            AddClickEvent(items, clickEvent); src.DropDownItems.AddRange(items.ToArray());
        }

        public static ToolStripItem SubItamTagSearch(IList<ToolStripItem> src, object tag) {
            for (int i = 0; i < src.Count; i++) if (src[i].Tag == tag) return src[i]; return null;
        }

        public static ToolStripItem SubItamTagSearch(ToolStripItemCollection src, object tag) {
            for (int i = 0; i < src.Count; i++) if (src[i].Tag == tag) return src[i]; return null;
        }

        public static ToolStripSeparator AddSeparator(IList<ToolStripItem> items) {
            var item = new ToolStripSeparator(); if (items != null) items.Add(item); return item;
        }

        public static ToolStripMenuItem AddMenuItem(List<ToolStripItem> items, string text, object tag) { 
            var item = new ToolStripMenuItem() { Text = text, Tag = tag, BackColor = Styles.GetStyles().ContextMenu.BackgroundColor };
            if(items != null) items.Add(item); return item; 
        }

        public static void AddClickEvent(IList<ToolStripItem> src, EventHandler clickEvent) {
            for (int i = 0; i < src.Count; i++) src[i].Click += clickEvent;
        }

        public static void AddClickEvent(ToolStripItemCollection src, EventHandler clickEvent) {
            for (int i = 0; i < src.Count; i++) src[i].Click += clickEvent;
        }

        public static void DisposeItems(IList<ToolStripItem> items) {
            if (items == null) return; 

            for (int i = 0; i < items.Count; i++) 
                if (items[i] != null && !items[i].IsDisposed) items[i].Dispose(); 

            if(!items.IsReadOnly) items.Clear();
        }

        public static void DisposeItem(ToolStripItem item) { if (item != null && !item.IsDisposed) item.Dispose(); }
    }
}