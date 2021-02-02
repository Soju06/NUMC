using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public class ScrollBar : Control
    {
        #region Event Region

        public event EventHandler<ScrollValueEventArgs> ValueChanged;

        #endregion Event Region

        #region Field Region

        private ScrollOrientation _scrollOrientation;

        private int _value;
        private int _minimum = 0;
        private int _maximum = 100;

        private int _viewSize;

        private Rectangle _trackArea;
        private float _viewContentRatio;

        private Rectangle _thumbArea;
        private Rectangle _upArrowArea;
        private Rectangle _downArrowArea;

        private bool _thumbHot;
        private bool _upArrowHot;
        private bool _downArrowHot;

        private bool _upArrowClicked;
        private bool _downArrowClicked;

        private bool _isScrolling;
        private int _initialValue;
        private Point _initialContact;

        private readonly Timer _scrollTimer;
        private readonly Styles _styles = Styles.GetStyles();

        #endregion Field Region

        #region Property Region

        [Category("Behavior")]
        [Description("The orientation type of the scrollbar.")]
        [DefaultValue(ScrollOrientation.Vertical)]
        public ScrollOrientation ScrollOrientation
        {
            get { return _scrollOrientation; }
            set
            {
                _scrollOrientation = value;
                UpdateScrollBar();
            }
        }

        [Category("Behavior")]
        [Description("The value that the scroll thumb position represents.")]
        [DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < Minimum)
                    value = Minimum;

                var maximumValue = Maximum - ViewSize;
                if (value > maximumValue)
                    value = maximumValue;

                if (_value == value)
                    return;

                _value = value;

                UpdateThumb(true);

                ValueChanged?.Invoke(this, new ScrollValueEventArgs(Value));
            }
        }

        [Category("Behavior")]
        [Description("The lower limit value of the scrollable range.")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                UpdateScrollBar();
            }
        }

        [Category("Behavior")]
        [Description("The upper limit value of the scrollable range.")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                UpdateScrollBar();
            }
        }

        [Category("Behavior")]
        [Description("The view size for the scrollable area.")]
        [DefaultValue(0)]
        public int ViewSize
        {
            get { return _viewSize; }
            set
            {
                _viewSize = value;
                UpdateScrollBar();
            }
        }

        public new bool Visible
        {
            get { return base.Visible; }
            set
            {
                if (base.Visible == value)
                    return;

                base.Visible = value;
            }
        }

        #endregion Property Region

        #region Constructor Region

        public ScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            SetStyle(ControlStyles.Selectable, false);

            _scrollTimer = new Timer
            {
                Interval = 1
            };
            _scrollTimer.Tick += ScrollTimerTick;
        }

        #endregion Constructor Region

        #region Event Handler Region

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateScrollBar();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_thumbArea.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                _isScrolling = true;
                _initialContact = e.Location;

                if (_scrollOrientation == ScrollOrientation.Vertical)
                    _initialValue = _thumbArea.Top;
                else
                    _initialValue = _thumbArea.Left;

                Invalidate();
                return;
            }

            if (_upArrowArea.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                _upArrowClicked = true;
                _scrollTimer.Enabled = true;

                Invalidate();
                return;
            }

            if (_downArrowArea.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                _downArrowClicked = true;
                _scrollTimer.Enabled = true;

                Invalidate();
                return;
            }

            if (_trackArea.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                // Step 1. Check if our input is at least aligned with the thumb
                if (_scrollOrientation == ScrollOrientation.Vertical)
                {
                    var modRect = new Rectangle(_thumbArea.Left, _trackArea.Top, _thumbArea.Width, _trackArea.Height);
                    if (!modRect.Contains(e.Location))
                        return;
                }
                else if (_scrollOrientation == ScrollOrientation.Horizontal)
                {
                    var modRect = new Rectangle(_trackArea.Left, _thumbArea.Top, _trackArea.Width, _thumbArea.Height);
                    if (!modRect.Contains(e.Location))
                        return;
                }

                // Step 2. Scroll to the area initially clicked.
                if (_scrollOrientation == ScrollOrientation.Vertical)
                {
                    var loc = e.Location.Y;
                    loc -= _upArrowArea.Bottom - 1;
                    loc -= _thumbArea.Height / 2;
                    ScrollToPhysical(loc);
                }
                else
                {
                    var loc = e.Location.X;
                    loc -= _upArrowArea.Right - 1;
                    loc -= _thumbArea.Width / 2;
                    ScrollToPhysical(loc);
                }

                // Step 3. Initiate a thumb drag.
                _isScrolling = true;
                _initialContact = e.Location;
                _thumbHot = true;

                if (_scrollOrientation == ScrollOrientation.Vertical)
                    _initialValue = _thumbArea.Top;
                else
                    _initialValue = _thumbArea.Left;

                Invalidate();
                return;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _isScrolling = false;

            _upArrowClicked = false;
            _downArrowClicked = false;

            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!_isScrolling)
            {
                var thumbHot = _thumbArea.Contains(e.Location);
                if (_thumbHot != thumbHot)
                {
                    _thumbHot = thumbHot;
                    Invalidate();
                }

                var upArrowHot = _upArrowArea.Contains(e.Location);
                if (_upArrowHot != upArrowHot)
                {
                    _upArrowHot = upArrowHot;
                    Invalidate();
                }

                var downArrowHot = _downArrowArea.Contains(e.Location);
                if (_downArrowHot != downArrowHot)
                {
                    _downArrowHot = downArrowHot;
                    Invalidate();
                }
            }

            if (_isScrolling)
            {
                if (e.Button != MouseButtons.Left)
                {
                    OnMouseUp(null);
                    return;
                }

                var difference = new Point(e.Location.X - _initialContact.X, e.Location.Y - _initialContact.Y);

                if (_scrollOrientation == ScrollOrientation.Vertical)
                {
                    var thumbPos = (_initialValue - _trackArea.Top);
                    var newPosition = thumbPos + difference.Y;

                    ScrollToPhysical(newPosition);
                }
                else if (_scrollOrientation == ScrollOrientation.Horizontal)
                {
                    var thumbPos = (_initialValue - _trackArea.Left);
                    var newPosition = thumbPos + difference.X;

                    ScrollToPhysical(newPosition);
                }

                UpdateScrollBar();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _thumbHot = false;
            _upArrowHot = false;
            _downArrowHot = false;

            Invalidate();
        }

        private void ScrollTimerTick(object sender, EventArgs e)
        {
            if (!_upArrowClicked && !_downArrowClicked)
            {
                _scrollTimer.Enabled = false;
                return;
            }

            if (_upArrowClicked)
                ScrollBy(-1);
            else if (_downArrowClicked)
                ScrollBy(1);
        }

        #endregion Event Handler Region

        #region Method Region

        public void ScrollTo(int position)
        {
            Value = position;
        }

        public void ScrollToPhysical(int positionInPixels)
        {
            var isVert = _scrollOrientation == ScrollOrientation.Vertical;

            var trackAreaSize = isVert ? _trackArea.Height - _thumbArea.Height : _trackArea.Width - _thumbArea.Width;

            var positionRatio = (float)positionInPixels / (float)trackAreaSize;
            var viewScrollSize = (Maximum - ViewSize);

            var newValue = (int)(positionRatio * viewScrollSize);
            Value = newValue;
        }

        public void ScrollBy(int offset)
        {
            var newValue = Value + offset;
            ScrollTo(newValue);
        }

        public void ScrollByPhysical(int offsetInPixels)
        {
            var isVert = _scrollOrientation == ScrollOrientation.Vertical;

            var thumbPos = isVert ? (_thumbArea.Top - _trackArea.Top) : (_thumbArea.Left - _trackArea.Left);

            var newPosition = thumbPos - offsetInPixels;

            ScrollToPhysical(newPosition);
        }

        public void UpdateScrollBar()
        {
            var area = ClientRectangle;

            // Arrow buttons
            if (_scrollOrientation == ScrollOrientation.Vertical)
            {
                _upArrowArea = new Rectangle(area.Left, area.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
                _downArrowArea = new Rectangle(area.Left, area.Bottom - Consts.ArrowButtonSize, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
            }
            else if (_scrollOrientation == ScrollOrientation.Horizontal)
            {
                _upArrowArea = new Rectangle(area.Left, area.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
                _downArrowArea = new Rectangle(area.Right - Consts.ArrowButtonSize, area.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
            }

            // Track
            if (_scrollOrientation == ScrollOrientation.Vertical)
            {
                _trackArea = new Rectangle(area.Left, area.Top + Consts.ArrowButtonSize, area.Width, area.Height - (Consts.ArrowButtonSize * 2));
            }
            else if (_scrollOrientation == ScrollOrientation.Horizontal)
            {
                _trackArea = new Rectangle(area.Left + Consts.ArrowButtonSize, area.Top, area.Width - (Consts.ArrowButtonSize * 2), area.Height);
            }

            // Thumb
            UpdateThumb();

            Invalidate();
        }

        private void UpdateThumb(bool forceRefresh = false)
        {
            if (ViewSize >= Maximum)
                return;

            // Cap to maximum value
            var maximumValue = Maximum - ViewSize;
            if (Value > maximumValue)
                Value = maximumValue;

            // Calculate size ratio
            _viewContentRatio = (float)ViewSize / (float)Maximum;
            var viewAreaSize = Maximum - ViewSize;
            var positionRatio = (float)Value / (float)viewAreaSize;

            // Update area
            if (_scrollOrientation == ScrollOrientation.Vertical)
            {
                var thumbSize = (int)(_trackArea.Height * _viewContentRatio);

                if (thumbSize < Consts.MinimumThumbSize)
                    thumbSize = Consts.MinimumThumbSize;

                var trackAreaSize = _trackArea.Height - thumbSize;
                var thumbPosition = (int)(trackAreaSize * positionRatio);

                _thumbArea = new Rectangle(_trackArea.Left + 3, _trackArea.Top + thumbPosition, Consts.ScrollBarSize - 6, thumbSize);
            }
            else if (_scrollOrientation == ScrollOrientation.Horizontal)
            {
                var thumbSize = (int)(_trackArea.Width * _viewContentRatio);

                if (thumbSize < Consts.MinimumThumbSize)
                    thumbSize = Consts.MinimumThumbSize;

                var trackAreaSize = _trackArea.Width - thumbSize;
                var thumbPosition = (int)(trackAreaSize * positionRatio);

                _thumbArea = new Rectangle(_trackArea.Left + thumbPosition, _trackArea.Top + 3, thumbSize, Consts.ScrollBarSize - 6);
            }

            if (forceRefresh)
            {
                Invalidate();
                Update();
            }
        }

        #endregion Method Region

        #region Paint Region

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var b = new SolidBrush(_styles.ScrollBar.BackgroundColor))
                g.FillRectangle(b, ClientRectangle);

            // DEBUG: Arrow backgrounds
            /* using (var b = new SolidBrush(Color.White))
            {
                g.FillRectangle(b, _upArrowArea);
                g.FillRectangle(b, _downArrowArea);
            } */

            // Up arrow
            var upIcon = _upArrowHot ? Icons.scrollbar_arrow_hot : Icons.scrollbar_arrow_standard;

            if (_upArrowClicked)
                upIcon = Icons.scrollbar_arrow_clicked;

            if (!Enabled)
                upIcon = Icons.scrollbar_arrow_disabled;

            if (_scrollOrientation == ScrollOrientation.Vertical)
                upIcon.RotateFlip(RotateFlipType.RotateNoneFlipY);
            else if (_scrollOrientation == ScrollOrientation.Horizontal)
                upIcon.RotateFlip(RotateFlipType.Rotate90FlipNone);

            g.DrawImageUnscaled(upIcon,
                                _upArrowArea.Left + (_upArrowArea.Width / 2) - (upIcon.Width / 2),
                                _upArrowArea.Top + (_upArrowArea.Height / 2) - (upIcon.Height / 2));

            // Down arrow
            var downIcon = _downArrowHot ? Icons.scrollbar_arrow_hot : Icons.scrollbar_arrow_standard;

            if (_downArrowClicked)
                downIcon = Icons.scrollbar_arrow_clicked;

            if (!Enabled)
                downIcon = Icons.scrollbar_arrow_disabled;

            if (_scrollOrientation == ScrollOrientation.Horizontal)
                downIcon.RotateFlip(RotateFlipType.Rotate270FlipNone);

            g.DrawImageUnscaled(downIcon,
                                _downArrowArea.Left + (_downArrowArea.Width / 2) - (downIcon.Width / 2),
                                _downArrowArea.Top + (_downArrowArea.Height / 2) - (downIcon.Height / 2));

            // Draw thumb
            if (Enabled)
            {
                var scrollColor = _thumbHot ? _styles.ScrollBar.HeaderDownColor : _styles.ScrollBar.HeaderColor;

                if (_isScrolling)
                    scrollColor = _styles.ScrollBar.ActiveColor;

                using (var b = new SolidBrush(scrollColor))
                    g.FillRectangle(b, _thumbArea);
            }
        }

        #endregion Paint Region
    }

    public abstract class ScrollBase : Control
    {
        #region Event Region

        public event EventHandler ViewportChanged;

        public event EventHandler ContentSizeChanged;

        #endregion Event Region

        #region Field Region

        protected readonly ScrollBar _vScrollBar;
        protected readonly ScrollBar _hScrollBar;

        private Size _visibleSize;
        private Size _contentSize;

        private Rectangle _viewport;

        private Point _offsetMousePosition;

        private int _maxDragChange = 0;
        private readonly Timer _dragTimer;

        private bool _hideScrollBars = true;

        #endregion Field Region

        #region Property Region

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle Viewport
        {
            get { return _viewport; }
            private set
            {
                _viewport = value;

                ViewportChanged?.Invoke(this, null);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size ContentSize
        {
            get { return _contentSize; }
            set
            {
                _contentSize = value;
                UpdateScrollBars();

                ContentSizeChanged?.Invoke(this, null);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point OffsetMousePosition
        {
            get { return _offsetMousePosition; }
        }

        [Category("Behavior")]
        [Description("Determines the maximum scroll change when dragging.")]
        [DefaultValue(0)]
        public int MaxDragChange
        {
            get { return _maxDragChange; }
            set
            {
                _maxDragChange = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDragging { get; private set; }

        [Category("Behavior")]
        [Description("Determines whether scrollbars will remain visible when disabled.")]
        [DefaultValue(true)]
        public bool HideScrollBars
        {
            get { return _hideScrollBars; }
            set
            {
                _hideScrollBars = value;
                UpdateScrollBars();
            }
        }

        #endregion Property Region

        #region Constructor Region

        protected ScrollBase()
        {
            SetStyle(ControlStyles.Selectable |
                     ControlStyles.UserMouse, true);

            _vScrollBar = new ScrollBar { ScrollOrientation = ScrollOrientation.Vertical };
            _hScrollBar = new ScrollBar { ScrollOrientation = ScrollOrientation.Horizontal };

            Controls.Add(_vScrollBar);
            Controls.Add(_hScrollBar);

            _vScrollBar.ValueChanged += delegate { UpdateViewport(); };
            _hScrollBar.ValueChanged += delegate { UpdateViewport(); };

            _vScrollBar.MouseDown += delegate { Select(); };
            _hScrollBar.MouseDown += delegate { Select(); };

            _dragTimer = new Timer
            {
                Interval = 1
            };
            _dragTimer.Tick += DragTimer_Tick;
        }

        #endregion Constructor Region

        #region Method Region

        private void UpdateScrollBars()
        {
            if (_vScrollBar.Maximum != ContentSize.Height)
                _vScrollBar.Maximum = ContentSize.Height;

            if (_hScrollBar.Maximum != ContentSize.Width)
                _hScrollBar.Maximum = ContentSize.Width;

            var scrollSize = Consts.ScrollBarSize;

            _vScrollBar.Location = new Point(ClientSize.Width - scrollSize, 0);
            _vScrollBar.Size = new Size(scrollSize, ClientSize.Height);

            _hScrollBar.Location = new Point(0, ClientSize.Height - scrollSize);
            _hScrollBar.Size = new Size(ClientSize.Width, scrollSize);

            if (DesignMode)
                return;

            // Do this twice in case changing the visibility of the scrollbars
            // causes the VisibleSize to change in such a way as to require a second scrollbar.
            // Probably a better way to detect that scenario...
            SetVisibleSize();
            SetScrollBarVisibility();
            SetVisibleSize();
            SetScrollBarVisibility();

            if (_vScrollBar.Visible)
                _hScrollBar.Width -= scrollSize;

            if (_hScrollBar.Visible)
                _vScrollBar.Height -= scrollSize;

            _vScrollBar.ViewSize = _visibleSize.Height;
            _hScrollBar.ViewSize = _visibleSize.Width;

            UpdateViewport();
        }

        private void SetScrollBarVisibility()
        {
            _vScrollBar.Enabled = _visibleSize.Height < ContentSize.Height;
            _hScrollBar.Enabled = _visibleSize.Width < ContentSize.Width;

            if (_hideScrollBars)
            {
                _vScrollBar.Visible = _vScrollBar.Enabled;
                _hScrollBar.Visible = _hScrollBar.Enabled;
            }
        }

        private void SetVisibleSize()
        {
            var scrollSize = Consts.ScrollBarSize;

            _visibleSize = new Size(ClientSize.Width, ClientSize.Height);

            if (_vScrollBar.Visible)
                _visibleSize.Width -= scrollSize;

            if (_hScrollBar.Visible)
                _visibleSize.Height -= scrollSize;
        }

        private void UpdateViewport()
        {
            var left = 0;
            var top = 0;
            var width = ClientSize.Width;
            var height = ClientSize.Height;

            if (_hScrollBar.Visible)
            {
                left = _hScrollBar.Value;
                height -= _hScrollBar.Height;
            }

            if (_vScrollBar.Visible)
            {
                top = _vScrollBar.Value;
                width -= _vScrollBar.Width;
            }

            Viewport = new Rectangle(left, top, width, height);

            var pos = PointToClient(MousePosition);
            _offsetMousePosition = new Point(pos.X + Viewport.Left, pos.Y + Viewport.Top);

            Invalidate();
        }

        public void ScrollTo(Point point)
        {
            HScrollTo(point.X);
            VScrollTo(point.Y);
        }

        public void VScrollTo(int value)
        {
            if (_vScrollBar.Visible)
                _vScrollBar.Value = value;
        }

        public void HScrollTo(int value)
        {
            if (_hScrollBar.Visible)
                _hScrollBar.Value = value;
        }

        protected virtual void StartDrag()
        {
            IsDragging = true;
            _dragTimer.Start();
        }

        protected virtual void StopDrag()
        {
            IsDragging = false;
            _dragTimer.Stop();
        }

        public Point PointToView(Point point)
        {
            return new Point(point.X - Viewport.Left, point.Y - Viewport.Top);
        }

        public Rectangle RectangleToView(Rectangle rect)
        {
            return new Rectangle(new Point(rect.Left - Viewport.Left, rect.Top - Viewport.Top), rect.Size);
        }

        #endregion Method Region

        #region Event Handler Region

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            UpdateScrollBars();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateScrollBars();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            _offsetMousePosition = new Point(e.X + Viewport.Left, e.Y + Viewport.Top);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
                Select();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            var horizontal = false;

            if (_hScrollBar.Visible && ModifierKeys == Keys.Control)
                horizontal = true;

            if (_hScrollBar.Visible && !_vScrollBar.Visible)
                horizontal = true;

            if (!horizontal)
            {
                if (e.Delta > 0)
                    _vScrollBar.ScrollByPhysical(9);
                else if (e.Delta < 0)
                    _vScrollBar.ScrollByPhysical(-9);
            }
            else
            {
                if (e.Delta > 0)
                    _hScrollBar.ScrollByPhysical(9);
                else if (e.Delta < 0)
                    _hScrollBar.ScrollByPhysical(-9);
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            // Allows arrow keys to trigger OnKeyPress
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void DragTimer_Tick(object sender, EventArgs e)
        {
            var pos = PointToClient(MousePosition);

            var right = ClientRectangle.Right;
            var bottom = ClientRectangle.Bottom;

            if (_vScrollBar.Visible)
                right = _vScrollBar.Left;

            if (_hScrollBar.Visible)
                bottom = _hScrollBar.Top;

            if (_vScrollBar.Visible)
            {
                // Scroll up
                if (pos.Y < ClientRectangle.Top)
                {
                    var difference = (pos.Y - ClientRectangle.Top) * -1;

                    if (MaxDragChange > 0 && difference > MaxDragChange)
                        difference = MaxDragChange;

                    _vScrollBar.Value -= difference;
                }

                // Scroll down
                if (pos.Y > bottom)
                {
                    var difference = pos.Y - bottom;

                    if (MaxDragChange > 0 && difference > MaxDragChange)
                        difference = MaxDragChange;

                    _vScrollBar.Value += difference;
                }
            }

            if (_hScrollBar.Visible)
            {
                // Scroll left
                if (pos.X < ClientRectangle.Left)
                {
                    var difference = (pos.X - ClientRectangle.Left) * -1;

                    if (MaxDragChange > 0 && difference > MaxDragChange)
                        difference = MaxDragChange;

                    _hScrollBar.Value -= difference;
                }

                // Scroll right
                if (pos.X > right)
                {
                    var difference = pos.X - right;

                    if (MaxDragChange > 0 && difference > MaxDragChange)
                        difference = MaxDragChange;

                    _hScrollBar.Value += difference;
                }
            }
        }

        #endregion Event Handler Region
    }

    public enum ScrollOrientation
    {
        Vertical,
        Horizontal
    }

    public class ScrollValueEventArgs : EventArgs
    {
        public int Value { get; private set; }

        public ScrollValueEventArgs(int value)
        {
            Value = value;
        }
    }
}