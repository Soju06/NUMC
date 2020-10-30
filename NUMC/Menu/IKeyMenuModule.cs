using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface IKeyMenuModule : Array.ISortIndex
    {
        ToolStripItem[] Menus { get; }

        void MenuClicking(Script.KeyObject keyObject, Keys selectedKey);
    }
}