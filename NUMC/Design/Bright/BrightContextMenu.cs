using System.Windows.Forms;

namespace NUMC.Design.Bright
{
    public class BrightContextMenu : ContextMenuStrip
    {
        #region Constructor Region

        public BrightContextMenu()
        {
            Renderer = new BrightMenuRenderer();
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