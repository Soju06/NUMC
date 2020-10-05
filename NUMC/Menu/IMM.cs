using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface IMM
    {
        ToolStripItem[] Menus { get; }

        void MenuClicking(Script.KeyObject keyObject, Keys selectedKey);
    }
}