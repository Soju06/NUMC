using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public interface IMenu : IPluginExp
    {
        ToolStripItem[] Menus { get; }
    }
}
