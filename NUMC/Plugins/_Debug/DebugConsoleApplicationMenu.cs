#if DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins._Debug
{
    public class DebugConsoleApplicationMenu : Plugin.Menu.IApplicationMenu
    {
        public int Index => 10;

        public ToolStripItem[] Menus { get; private set; } = new ToolStripItem[] { new ToolStripMenuItem("debug console", null, Click) };

        private static void Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                new Thread(() => {
                    using (var console = new Forms.Dialogs.DebugConsole())
                        console.ShowDialog();
                }) { IsBackground = true }.Start();
            });
        }
        public void Dispose() => Menu.MenuStripSupport.DisposeItems(Menus);

        public void Initialize(Script.Script script) { }

        public void MenuClicking() { }
    }
}

#endif
