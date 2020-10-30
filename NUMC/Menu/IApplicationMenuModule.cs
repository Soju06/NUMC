using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface IApplicationMenuModule : Array.ISortIndex
    {
        ToolStripItem[] Menus { get; }
    }
}