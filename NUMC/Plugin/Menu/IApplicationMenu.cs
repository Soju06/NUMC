using NUMC.Plugin;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public interface IApplicationMenu : IPlugin, IMenu
    {
        void MenuClicking();
    }
}