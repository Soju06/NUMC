using System.Windows.Forms;

namespace NUMC.Design.Bright
{
    public class BrightMenuStrip : MenuStrip
    {
        #region Constructor Region

        public BrightMenuStrip()
        {
            Renderer = new BrightMenuRenderer();
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