using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class MenuStrip : System.Windows.Forms.MenuStrip
    {
        #region Constructor Region

        public MenuStrip()
        {
            Renderer = new MenuRenderer();
            Padding = new Padding(3, 2, 0, 2);
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