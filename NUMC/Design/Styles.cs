using System.Drawing;

namespace NUMC.Design
{
    public class Styles
    {
        public class Form
        {
            public static Color BackgroundColor { get => Color.FromArgb(33, 33, 33); }
            public static Color Color { get => Color.White; }
        }

        public class Control
        {
            public static Color BackgroundColor { get => Color.FromArgb(40, 40, 40); }
            public static Color SelectionBackgroundColor { get => Color.FromArgb(50, 50, 50); }

            public static Color Color { get => Color.FromArgb(230, 230, 230); }
            public static Color DisabledColor { get => Color.FromArgb(190, 190, 190); }
            public static Color EmphaColor { get => Color.FromArgb(100, 44, 63); }

            public static Color ColorSelectionBackgroundColor { get => Color.FromArgb(133, 48, 77); }
        }

        public class UserControl
        {
            public static Color BackgroundColor { get => Color.FromArgb(33, 33, 33); }
            public static Color Color { get => Color.FromArgb(230, 230, 230); }
        }

        public class Button
        {
            public static Color BackgroundColor { get => Color.FromArgb(40, 40, 40); }
            public static Color EmphaBackgroundColor { get => Color.FromArgb(51, 45, 47); }
            public static Color DownBackgroundColor { get => Color.FromArgb(56, 45, 51); }
            public static Color HoverBackgroundColor { get => Color.FromArgb(44, 44, 44); }
            public static Color PressedBackgroundColor { get => Color.FromArgb(50, 50, 50); }
        }

        public class ContextMenu
        {
            public static Color BackgroundColor { get => Color.FromArgb(58, 58, 58); }
        }

        public class ComboBox
        {
            public static Color BackgroundColor { get => Color.FromArgb(55, 55, 55); }
        }

        public class RadioButton
        {
            public static Color BackgroundColor { get => Color.FromArgb(55, 55, 55); }
        }

        public class ScrollBar
        {
            public static Color BackgroundColor { get => Color.FromArgb(52, 52, 52); }
            public static Color ActiveColor { get => Color.FromArgb(76, 76, 76); }
        }

        public class ListView
        {
            public static Color BackgroundColor { get => Color.FromArgb(38, 38, 38); }
            public static Color HeaderBackgroundColor { get => Color.FromArgb(42, 42, 42); }
        }
    }
}