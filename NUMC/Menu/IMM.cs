using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Menu
{
    public interface IMM
    {
        ToolStripItem[] Menus { get; }
        void MenuClicking(Script.KeyObject keyObject, Keys selectedKey);
    }
}
