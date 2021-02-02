using NUMC.Plugin;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public interface IKeyMenu : IPlugin, IMenu
    {
        void MenuClicking(Script.KeyObject keyObject, Keys selectedKey);
    }
}