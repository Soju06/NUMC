using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design
{
    public partial class ProgressBar : UserControl
    {
        public Panel ValuePanel { get; internal set; }

        public ProgressBar()
        {
            InitializeComponent();
            ValuePanel = new Panel();

            Controls.Add(ValuePanel);

            ValuePanel.Location = new Point(0, 0);
            ValuePanel.Size = new Size(ValuePanel.Size.Width, Size.Height);

            ValuePanel.BackColor = Color.FromArgb(0, 122, 204);

            Value = 0.1;
        }

        private void SetValue(double val)
        {
            double f = val;

            if (f < 0)
                f = 0;

            if (f > 1)
                f = 1;

            int w = (int)(Size.Width * f);

            ValuePanel.Size = new Size(w, Size.Height);
        }

        private double v_alue;

        private void NProgressBar_SizeChanged(object sender, EventArgs e)
        {
            SetValue(v_alue);
        }

        public double Value
        {
            get
            {
                return v_alue;
            }
            set
            {
                v_alue = value;
                SetValue(value);
            }
        }
    }
}