using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public abstract class ScrollView : ScrollBase
    {
        public readonly Styles _styles = Styles.GetStyles();

        #region Constructor Region

        protected ScrollView()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion Constructor Region

        #region Paint Region

        protected abstract void PaintContent(Graphics g);

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;


            // Draw background
            base.OnPaintBackground(e);
            //using (var b = new SolidBrush(Color.Transparent))
            //    g.FillRectangle(b, ClientRectangle);

            // Offset the graphics based on the viewport, render the control contents, then reset it.
            g.TranslateTransform(Viewport.Left * -1, Viewport.Top * -1);

            PaintContent(g);

            g.TranslateTransform(Viewport.Left, Viewport.Top);

            // Draw the bit where the scrollbars meet
            if (_vScrollBar.Visible && _hScrollBar.Visible)
            {
                using (var b = new SolidBrush(BackColor))
                {
                    var rect = new Rectangle(_hScrollBar.Right, _vScrollBar.Bottom, _vScrollBar.Width,
                                             _hScrollBar.Height);

                    g.FillRectangle(b, rect);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Absorb event
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        #endregion Paint Region
    }
}