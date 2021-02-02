using NUMC.Plugin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Plugin.KeyboardLayout
{
    public interface IKeyboardLayout : IPlugin
    {
        string Name { get; }

        event LayoutMenuShowEventHandler LayoutMenuShow;
        event MouseClickEventHandler MouseClick;

        void LayoutLoad();
        void LayoutRemove();
    }

    public delegate void LayoutMenuShowEventHandler(Keys Key, Point loc);
    public delegate void MouseClickEventHandler(Keys Key, MouseButtons Button);
}