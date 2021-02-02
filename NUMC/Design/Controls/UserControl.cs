using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class UserControl : System.Windows.Forms.UserControl
    {
        private float _fontSize;
        protected Styles _styles = Styles.GetStyles();

        public float FontSize { get => _fontSize; set { if (value == _fontSize) return;
                _fontSize = value; Font = new System.Drawing.Font(_styles.FontFamily, value, _styles.FontStyle); } }

        public UserControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            FontSize = _styles.FontSize;
            BackColor = _styles.UserControl.BackgroundColor;
            ForeColor = _styles.UserControl.Color;
        }
    }
}