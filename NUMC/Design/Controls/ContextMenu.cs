using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class ContextMenuStrip : System.Windows.Forms.ContextMenuStrip
    {
        #region Constructor Region

        public ContextMenuStrip()
        {
            Renderer = new MenuRenderer();
        }

        #endregion Constructor Region

        public void AddSeparator()
        {
            Items.Add(new ToolStripSeparator());
        }

        public void AddItem(string text, object tag)
        {
            Items.Add(new ToolStripMenuItem() { Text = text, Tag = tag });
        }
    }
}