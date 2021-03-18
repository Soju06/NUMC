using System;
using System.Drawing;

namespace NUMC.Design.Designer {
    public class TitleBarDesigner : IDisposable {
        public event EventHandler Invalidate;

        private readonly Bitmap[] _buttonImages;
        private readonly Styles _styles;
        private Font _titleFont;
        private Bitmap _icon;
        private string _title;
        private Color _color;
        private Color _downBackgroundColor;
        private Color _pressedBackgroundColor;
        private Color _backgroundColor;
        private Font _font;
        private bool _close = true;
        private bool _maximize = true;
        private bool _minimize = true;

        public Bitmap Icon { get => _icon; set { _icon = value; Invalidate?.Invoke(this, default); } }
        public string Title { get => _title; set { _title = value; Invalidate?.Invoke(this, default); } }
        public Color Color { get => _color; set { _color = value; Invalidate?.Invoke(this, default); } }
        public Color DownBackgroundColor { get => _downBackgroundColor; set { _downBackgroundColor = value; SetButtonImage(); Invalidate?.Invoke(this, default); } }
        public Color PressedBackgroundColor { get => _pressedBackgroundColor; set { _pressedBackgroundColor = value; Invalidate?.Invoke(this, default); } }
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; Invalidate?.Invoke(this, default); } }
        public Font Font { get => _font; set { _font = value; SetFont(); Invalidate?.Invoke(this, default); } }

        public bool Close { get => _close; set { _close = value; Invalidate?.Invoke(this, default); } }
        public bool Maximize { get => _maximize; set { _maximize = value; Invalidate?.Invoke(this, default); } }
        public bool Minimize { get => _minimize; set { _minimize = value; Invalidate?.Invoke(this, default); } }

        public TitleBarDesigner(Styles styles) {
            _styles = styles;
            _color = _styles.Form.Color;
            _font = _styles.Font;
            _backgroundColor = _styles.TitleBar.BackgroundColor;
            _downBackgroundColor = _styles.TitleBar.HoverBackgroundColor;
            _pressedBackgroundColor = _styles.TitleBar.PressedBackgroundColor;
            _buttonImages = new Bitmap[3];
            SetButtonImage();
            SetFont();
        }

        private void SetFont() {
            _titleFont?.Dispose();
            _titleFont = GetFont(Font, 2);
        }

        public void Drawing(Rectangle rect, Graphics g, byte[] rightButtonsState, out Rectangle rightButtonsRect,
            out Rectangle[] rightButtonRects, out Rectangle titleBarRect, out Rectangle clientRect) {
            var padding = 5;
            var leftPadding = 2;
            var buttonWidth = 50;
            var iconWidth = 40;

            titleBarRect = new Rectangle(rect.X, rect.Y,
                rect.Width, Constant.Form.TitleBarHeight);

            // Draw Background
            using (var sb = new SolidBrush(BackgroundColor))
                g.FillRectangle(sb, titleBarRect);

            // Draw Icon
            var titleIconRect = new Rectangle(titleBarRect.X + leftPadding, 
                titleBarRect.Y, iconWidth, titleBarRect.Height);
            if (Icon != null) {
                var r = Math.Min(titleIconRect.Width / (double)Icon.Width, 
                    titleIconRect.Height / (double)Icon.Height);
                int w = (int)(Icon.Width * r), h = (int)(Icon.Height * r);
                var titleIconImageRect = new Rectangle(titleIconRect.X + (titleIconRect.Width / 2) - (w / 2), 
                    titleIconRect.Y + (titleIconRect.Height / 2) - (h / 2), w, h);
                g.DrawImage(Icon, titleIconImageRect.X, titleIconImageRect.Y,
                    titleIconImageRect.Width, titleIconImageRect.Height);
            }

            // Draw Buttons
            var rightButtonCount = (Close ? 1 : 0) + (Maximize ? 1 : 0) + (Minimize ? 1 : 0);
            rightButtonRects = new Rectangle[3];
            var rightButtonWidth = (buttonWidth * rightButtonCount);
            rightButtonsRect = new Rectangle(titleBarRect.Right - rightButtonWidth,
                titleBarRect.Y, rightButtonWidth, titleBarRect.Height);
            var buttonIndex = 0;
            for (int i = 0; i < rightButtonRects.Length; i++) {
                // Draw Button
                if ((!Close && i == 2) || (!Maximize && i == 1) || (!Minimize && i == 0)) continue;
                var state = rightButtonsState.Length - 1 >= i ? rightButtonsState[i] : 0;
                var bRect = rightButtonRects[i] = new Rectangle(rightButtonsRect.X + (buttonWidth * buttonIndex++),
                    rightButtonsRect.Y, buttonWidth, rightButtonsRect.Height);
                using (var sb = new SolidBrush(state == 1 ? DownBackgroundColor : state == 2 ?
                    PressedBackgroundColor : BackgroundColor))
                        g.FillRectangle(sb, bRect);
                // Draw Button Image
                var image = _buttonImages[i];
                g.DrawImage(image, bRect.X + (bRect.Width / 2) - (image.Width / 2),
                    bRect.Y + (bRect.Height / 2) - (image.Height / 2), image.Width, image.Height);
            }

            // Draw Title
            var titleTextRect = new Rectangle(titleIconRect.Right + padding,
                titleIconRect.Y, titleBarRect.Right - (rightButtonWidth + (padding * 2)), titleBarRect.Height);
            if(Title != null)
                using (var sb = new SolidBrush(Color))
                using (var sf = new StringFormat { LineAlignment = StringAlignment.Center })
                    g.DrawString(Title, _titleFont, sb, titleTextRect, sf);
            clientRect = new Rectangle(titleBarRect.X, titleBarRect.Bottom,
                rect.Width, rect.Height - titleBarRect.Height);
        }

        public void Dispose() {
            _titleFont?.Dispose();
        }

        private void SetButtonImage() {
            try {
                bool b = Resources.Render.IsBrightColor(BackgroundColor);
                for (int i = 0; i < _buttonImages.Length; i++)
                    _buttonImages[i]?.Dispose();
                _buttonImages[0] = Resources.Images.GetImage("minimize_16px", b);
                _buttonImages[1] = Resources.Images.GetImage("maximize_16px", b);
                _buttonImages[2] = Resources.Images.GetImage("close_16px", b);
            } catch { 
                
            }
        }

        private static Font GetFont(Font font, int s) => new Font(font.FontFamily, font.Size + s, font.Style, font.Unit);
    }
}