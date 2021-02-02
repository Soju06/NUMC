using System;
using System.Windows.Forms;
using WinUtils;

namespace NUMC.Design.Controls
{
    public class ContextMenuStrip : System.Windows.Forms.ContextMenuStrip
    {
        public ContextMenuStrip() {
            Renderer = new MenuRenderer();
        }

        public void AddSeparator() => Items.Add(new ToolStripSeparator());

        public void AddItem(string text, object tag) => 
            Items.Add(new ToolStripMenuItem() { Text = text, Tag = tag });
    }
}