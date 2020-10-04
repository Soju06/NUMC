using System.Windows.Forms;

namespace NUMC.Design.Bright
{
    public class BrightTextBox : TextBox
    {
        #region Constructor Region

        public BrightTextBox()
        {
            BackColor = Colors.LightBackground;
            ForeColor = Colors.LightText;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion
    }
}
