using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Design.Controls
{
    public class Label : System.Windows.Forms.Label
    {
        private float _fontSize;
        private readonly Styles _styles = Styles.GetStyles();

        public float FontSize { get => _fontSize; set { if (value == _fontSize) return;
                _fontSize = value; Font = new System.Drawing.Font(_styles.FontFamily, value, _styles.FontStyle); } }

        public Label()
        {
            ForeColor = _styles.Label.Color;
            BackColor = _styles.Label.BackgroundColor;
            FontSize = _styles.FontSize;
        }
    }
}
