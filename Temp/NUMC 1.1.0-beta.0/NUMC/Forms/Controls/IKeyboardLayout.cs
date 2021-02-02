using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public interface IKeyboardLayout
    {
        event Click Click; 
        event MouseClick MouseClick;
        event DoubleClick DoubleClick;

        Keys [] VKeys { get; }
    }

    public delegate void Click(Keys Key);

    public delegate void MouseClick(Keys Key, MouseButtons Button);

    public delegate void DoubleClick(Keys Key);
}
