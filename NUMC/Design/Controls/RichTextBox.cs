using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class RichTextBox : System.Windows.Forms.RichTextBox
    {
        public RichTextBox()
        {
            BackColor = Styles.Control.BackgroundColor;
            ForeColor = Styles.Control.Color;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
        }
    }
}