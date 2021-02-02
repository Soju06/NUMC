using NUMC.Plugin;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public interface INotifyMenu : IPlugin, IMenu
    {
        void MenuClicking();
    }
}