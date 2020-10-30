using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface INotifyMenuModule : Array.ISortIndex
    {
        ToolStripItem[] Menus { get; }
    }
}