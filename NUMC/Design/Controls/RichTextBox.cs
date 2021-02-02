using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class RichTextBox : System.Windows.Forms.RichTextBox
    {
        private readonly Styles _styles = Styles.GetStyles();
        public RichTextBox()
        {
            BackColor = _styles.Control.BackgroundColor;
            ForeColor = _styles.Control.Color;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}