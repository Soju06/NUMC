using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface IMenuModule
    {
        ToolStripItem[] Menus { get; }

        void MenuClicking(Script.KeyObject keyObject, Keys selectedKey);
    }
}