using NUMC.Config.Object;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public interface IKeyMenu : IPlugin, IMenu
    {
        void MenuClicking(KeyObject keyObject, Keys selectedKey);
    }
}