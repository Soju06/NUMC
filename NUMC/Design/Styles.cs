using System.Drawing;
using System.Drawing.Drawing2D;

namespace NUMC.Design {
    public class Styles {
        private static Styles _styles;

        public static Styles GetStyles() => _styles ??= new Styles();
        public static void SetStyle(Styles styles) => _styles = styles;

        public FontFamily FontFamily { get => _fontFamily; set => _fontFamily = value; }
        public float FontSize { get => _fontSize; set => _fontSize = value; }
        public FontStyle FontStyle { get => _fontStyle; set => _fontStyle = value; }
        public Font Font { get => _font ??= new Font(FontFamily, FontSize, FontStyle); set => _font = value; }

        public StyleObject.Form Form { get => _form ??= new StyleObject.Form(); set => _form = value; }
        public StyleObject.Control Control { get => _control ??= new StyleObject.Control(); set => _control = value; }
        public StyleObject.TitleBar TitleBar { get => _titleBar ??= new StyleObject.TitleBar(); set => _titleBar = value; }
        public StyleObject.Label Label { get => _label ??= new StyleObject.Label(); set => _label = value; }
        public StyleObject.UserControl UserControl { get => _userControl ??= new StyleObject.UserControl(); set => _userControl = value; }
        public StyleObject.Button Button { get => _button ??= new StyleObject.Button(); set => _button = value; }
        public StyleObject.ContextMenu ContextMenu { get => _contextMenu ??= new StyleObject.ContextMenu(); set => _contextMenu = value; }
        public StyleObject.ComboBox ComboBox { get => _comboBox ??= new StyleObject.ComboBox(); set => _comboBox = value; }
        public StyleObject.RadioButton RadioButton { get => _radioButton ??= new StyleObject.RadioButton(); set => _radioButton = value; }
        public StyleObject.ScrollBar ScrollBar { get => _scrollBar ??= new StyleObject.ScrollBar(); set => _scrollBar = value; }
        public StyleObject.ScrollView ScrollView { get => _scrollView ??= new StyleObject.ScrollView(); set => _scrollView = value; }

        private FontFamily _fontFamily = new FontFamily("Segoe UI");
        private float _fontSize = 10F;
        private FontStyle _fontStyle = FontStyle.Regular;
        private Font _font;

        private StyleObject.Form _form;
        private StyleObject.Control _control;
        private StyleObject.TitleBar _titleBar;
        private StyleObject.Label _label;
        private StyleObject.UserControl _userControl;
        private StyleObject.Button _button;
        private StyleObject.ContextMenu _contextMenu;
        private StyleObject.ComboBox _comboBox;
        private StyleObject.RadioButton _radioButton;
        private StyleObject.ScrollBar _scrollBar;
        private StyleObject.ScrollView _scrollView;
    }

}

namespace NUMC.Design.StyleObject {
    public class Form {
        public ColorBlend BackgroundGradient { get; set; } = new ColorBlend() {
                Colors = new Color[] { Color.FromArgb(48, 52, 59), Color.FromArgb(38, 41, 47), 
                Color.FromArgb(35, 39, 46) }, Positions = new float[] { 0f, 0.4f, 1f } 
        };
        public Color[] BorderGradient { get; set; } = new Color[] { 
            Color.FromArgb(0, 204, 255), Color.FromArgb(51, 103, 255) 
        };

        public Color BackgroundColor { get; set; } = Color.FromArgb(35, 39, 46);
        public Color TransparentBackColor { get; set; } = Color.FromArgb(120, 51, 58, 64);
        public Color TitleBarColor { get; set; } = Color.FromArgb(70, 40, 40, 40);
        public Color Color { get; set; } = Color.White;
    }

    public class Control {
        public Color BackgroundColor { get; set; } = Color.FromArgb(40, 42, 47);
        public Color SelectionBackgroundColor { get; set; } = Color.FromArgb(50, 53, 59);

        public Color Color { get; set; } = Color.FromArgb(230, 230, 230);
        public Color DisabledColor { get; set; } = Color.FromArgb(190, 190, 190);
        public Color EmphaColor { get; set; } = Color.FromArgb(44, 63, 120);

        public Color ColorSelectionBackgroundColor { get; set; } = Color.FromArgb(50, 78, 140);
    }

    public class TitleBar : Button { 
        public new Color BackgroundColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
    }

    public class Label {
        public Color BackgroundColor { get; set; } = Color.Transparent;
        public Color Color { get; set; } = Color.FromArgb(220, 220, 220);
    }

    public class UserControl {
        public Color BackgroundColor { get; set; } = Color.FromArgb(120, 52, 57, 65);
        public Color Color { get; set; } = Color.FromArgb(230, 230, 230);
    }

    public class Button {
        public Color BackgroundColor { get; set; } = Color.FromArgb(40, 42, 46);
        public Color EmphaBackgroundColor { get; set; } = Color.FromArgb(46, 48, 53);
        public Color DownBackgroundColor { get; set; } = Color.FromArgb(45, 47, 52);
        public Color HoverBackgroundColor { get; set; } = Color.FromArgb(44, 47, 51);
        public Color PressedBackgroundColor { get; set; } = Color.FromArgb(50, 53, 58);
    }

    public class ContextMenu {
        public Color BorderColor { get; set; } = Color.FromArgb(58, 62, 67);
        public Color BackgroundColor { get; set; } = Color.FromArgb(38, 41, 47);
    }

    public class ComboBox {
        public Color BackgroundColor { get; set; } = Color.FromArgb(55, 58, 64);
    }

    public class RadioButton {
        public Color BackgroundColor { get; set; } = Color.FromArgb(55, 58, 64);
    }

    public class ScrollBar {
        public Color BackgroundColor { get; set; } = Color.FromArgb(52, 56, 63);
        public Color HeaderColor { get; set; } = Color.FromArgb(72, 76, 82);
        public Color HeaderDownColor { get; set; } = Color.FromArgb(78, 82, 91);
        public Color ActiveColor { get; set; } = Color.FromArgb(83, 87, 97);
    }

    public class ScrollView {
        public Color BackgroundColor { get; set; } = Color.FromArgb(120, 38, 38, 38);
        public Color Color { get; set; } = Color.FromArgb(225, 225, 225);
        public Color HeaderBackgroundColor { get; set; } = Color.FromArgb(120, 42, 42, 42);
    }
}