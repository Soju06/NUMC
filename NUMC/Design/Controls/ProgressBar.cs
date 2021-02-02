using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class ProgressBar : System.Windows.Forms.ProgressBar
    {
        private readonly Styles _styles = Styles.GetStyles();
        private readonly Timer _timer;
        private double _v = 0;
        private Rectangle _rectangle;
        private ProgressBarStyle _style;
        private int _border = 1;
        private double _value = 0;
        private bool _animation = true;
        private double _animationValue = -1;
        private double _animationMoveSpeed = 0.015;
        private int _animationTickSpeed = 15;
        private double _marqueeValue = 1;

        public ProgressBar()
        {
            _timer = new Timer {
                Interval = _animationTickSpeed
            };

            _timer.Tick += Tick;

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
            
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new double Maximum { get => 1D; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new double Minimum { get => 0D; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int MarqueeAnimationSpeed { get => AnimationTickSpeed; }

        public new double Value { get => _value; set { _value = value < 0 ? 0 : value > 1 ? 1 : value; 
                if (_animationValue == -1 || !_animation) _animationValue = _value; Invalidate(); if(_animation && !_timer.Enabled) _timer.Start(); } }

        public new bool Visible { get => base.Visible; set { base.Visible = value;
                if (Visible && (Style == ProgressBarStyle.Marquee || _animation) && !_timer.Enabled) 
                _timer.Start(); else if (!Visible && _timer.Enabled) _timer.Stop(); } }

        public double MarqueeValue { get => _marqueeValue; set { _marqueeValue = value < 0 ? 0 : value > 1 ? 1 : value; Invalidate(); } }

        public int Border { get => _border; set { if (value < 0) return; _border = value; Invalidate(); } }

        public new ProgressBarStyle Style { get => _style; set { _style = value; _animationValue = _value; Invalidate(); 
                if ((value == ProgressBarStyle.Marquee || _animation) && !_timer.Enabled) _timer.Start(); else _timer.Stop(); } }
        
        public double AnimationMoveSpeed { get => _animationMoveSpeed; set { _animationMoveSpeed = value < 0 ? 0 : value > 1 ? 1 : value; } }

        public int AnimationTickSpeed { get => _animationTickSpeed; set { 
                if (value < 1) return; _animationTickSpeed = value; _timer.Interval = value; } }
        
        public bool Animation { get => _animation; set { _animation = value; 
                if (Style != ProgressBarStyle.Marquee &&_timer.Enabled) _timer.Stop(); _animationValue = _value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            // Border
            if (_border > 0)
            {
                var d = _border;
                var f = d * 2;

                // Set inbox
                _rectangle = new Rectangle(d, d, Size.Width - f, Size.Height - f);

                g.DrawRectangle(new Pen(_styles.Control.EmphaColor, _border),
                    new Rectangle(_rectangle.X - (d - (_border / 2)), _rectangle.Y - (d - (_border / 2)), Size.Width - _border, Size.Height - _border));
            }
            else
                // Set inbox
                _rectangle = new Rectangle(0, 0, Size.Width, Size.Height);

            // Background
            DrawBackground(g);

            // Style
            if (Style == ProgressBarStyle.Marquee)
                DrawMarquee(g);
            // Value
            else if ((_animation ? _animationValue : _value) > 0)
                g.FillRectangle(new SolidBrush(_styles.Control.ColorSelectionBackgroundColor),
                    new Rectangle(_rectangle.X, _rectangle.Y, (int)(_rectangle.Width * (_animation ? _animationValue : _value)), _rectangle.Height));
        }

        private void DrawMarquee(Graphics g)
        {
            var f = _rectangle.Width * Math.Abs(_v);
            var j = _rectangle.X + (_v < 0 ? -(int)f : (int)f);
            var w = (int)(_rectangle.Width * _marqueeValue) - (_border * 2);

            //if (j < 0) { w += j; j = _rectangle.X; }
            if (w + j > _rectangle.Width + _border) w -= w + j - _rectangle.Width - _border;
            if (j < _rectangle.X)
            {
                w -= _rectangle.X - j;
                j = _rectangle.X;
            }
            if (w > 0 && j >= 0)
                g.FillRectangle(new SolidBrush(_styles.Control.ColorSelectionBackgroundColor),
                        new Rectangle(j, _rectangle.Y, w, _rectangle.Height));
        }

        private void DrawBackground(Graphics g) =>
            g.FillRectangle(new SolidBrush(_styles.Control.BackgroundColor), _rectangle);

        private void Tick(object sender, EventArgs e)
        {
            if (Style == ProgressBarStyle.Marquee && Visible)
            {
                if (_v > 1.3)
                    _v = -(_marqueeValue + 0.1);

                Invalidate();

                _v += _animationMoveSpeed;
            }
            else if(_value != _animationValue)
            {
                if (!_animation)
                {
                    _animationValue = _value;
                    return;
                }

                double r;

                if(_value > _animationValue)
                {
                    r = _animationValue + _animationMoveSpeed;
                    r = r > _value ? _value : r;
                }
                else
                {
                    r = _animationValue - _animationMoveSpeed;
                    r = r < _value ? _value : r;
                }

                _animationValue = r;
                Invalidate();
            }
            else
                _timer.Stop();
        }

    }
}