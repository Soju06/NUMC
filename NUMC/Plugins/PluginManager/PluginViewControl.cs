using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUMC.Expansion;
using NUMC.Client;
using NUMC.Design.Controls;

namespace NUMC.Plugins.PluginManager
{
    public partial class PluginManagerViewControl : Design.Controls.UserControl, IDisposable
    {
        public event PluginViewItemClickEventHandler ItemClick;
        public event PluginViewItemMouseClickEventHandler ItemMouseClick;
        public event PluginViewItemDoubleClickEventHandler ItemDoubleClick;
        public event PluginViewItemChangedEventHandler ItemChanged;
        public event PluginViewItemButtonClickEventHandler ItemButtonClick;

        private readonly PluginItemDesigner Designer;
        private PluginManagerViewItem[] StoreItemBuffer;
        private Rectangle[] StoreItemBufferRectangles;
        private Rectangle[] StoreItemBufferButtonRectangles;
        private byte[] StoreItemBufferState;
        private int _shownCount = 1;
        private int _itemHeight = 200;
        private Padding _itemMargin = new Padding(2);
        private bool _autuResize = true;

        public int ShownCount { get => _shownCount; set { if (value < 1) return; _shownCount = value; if(AutoSize) SetSize(); ShownCountChanged(); } }
        public int ItemHeight { get => _itemHeight; set { if (value < 1) return; _itemHeight = value; Invalidate(); } }
        public Padding ItemMargin { get => _itemMargin; set { if (value != null) return; _itemMargin = value; Invalidate(); } }
        public new bool AutoSize { get; set; } = false;
        public bool AutoResize { get => _autuResize; set { _autuResize = value; SetAutoResize(); } }

        public PluginManagerViewControl()
        {
            Designer = new PluginItemDesigner(_styles);
            Designer.Invalidate += Designer_Invalidate;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);
            ShownCountChanged();
            Initialize();
        }

        private void Designer_Invalidate()
        {
            Invoke(new MethodInvoker(() => { Invalidate(); }));
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            Invalidate();
            base.OnPaddingChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try {
                base.OnPaintBackground(e);
                var g = e.Graphics;
                var padding = Padding;
                var crect = ClientRectangle;
                var rect = new Rectangle(crect.X + padding.Left, padding.Top,
                    crect.Width - _scrollBar.Width, crect.Height - padding.Bottom);
                var vc = _shownCount;
                var itemSize = GetItemSize(rect, Padding);
                var itemX = rect.X;
                for (int i = 0; i < vc; i++) {
                    var bf = StoreItemBuffer[i];
                    var bfs = StoreItemBufferState[i];
                    var bfrect = StoreItemBufferRectangles[i] = 
                        new Rectangle(new Point(itemX, GetItemY(rect.Y, i)), itemSize);
                    if (bf == null) continue;
                    Rectangle[] rs = null;
                    Designer?.Drawing(bf, g, bfrect, bfs, out rs);
                    if(rs != null && rs.Length >= 1)
                        StoreItemBufferButtonRectangles[i] = rs[0];
                }
            } catch {

            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            OnMouseEvent(e, false);
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            OnMouseEvent(e, true);
            base.OnMouseDoubleClick(e);
        }

        private void OnMouseEvent(MouseEventArgs e, bool d = false)
        {
            try {
                int f = -1;
                if(!d) {
                    for (int i = 0; i < StoreItemBufferButtonRectangles.Length; i++)
                        if (StoreItemBufferButtonRectangles[i].Contains(e.Location)) {
                            f = i; break;
                        }
                    if (f != -1) {
                        ItemButtonClick?.Invoke(StoreItemBuffer[f], e); return;
                    }
                }
                for (int i = 0; i < StoreItemBufferRectangles.Length; i++) {
                    if (StoreItemBufferRectangles[i].Contains(e.Location)) {
                        f = i; _selectedIndex = _scrollIndex + i; StoreItemBufferState[i] = 2;
                    }
                    else if (StoreItemBufferState[i] == 2)
                        StoreItemBufferState[i] = 0;
                }
                if (f >= 0 && StoreItemBuffer.Length > f && StoreItemBuffer[f] != null) {
                    var s = StoreItemBuffer[f];
                    if (d) ItemDoubleClick?.Invoke(s, e);
                    else {
                        ItemMouseClick?.Invoke(s, e);
                        if(e.Button == MouseButtons.Left)
                            ItemClick?.Invoke(s, e);
                        ItemChanged?.Invoke(s);
                    }
                }
                Invalidate();
            } catch { 

            } finally {
                base.OnMouseClick(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            try {
                var rf = false;
                for (int i = 0; i < StoreItemBufferRectangles.Length; i++) {
                    var obs = StoreItemBufferState[i];
                    if (obs == 2) continue;
                    var nbs = StoreItemBufferState[i] = 
                        (byte)(StoreItemBufferRectangles[i].Contains(e.Location) ? 1 : 0);
                    if(obs != nbs) rf = true;
                }
                if (rf) Invalidate();
            } catch { 

            } finally {
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            try {
                for (int i = 0; i < StoreItemBufferState.Length; i++) {
                    if (StoreItemBufferState[i] != 2) StoreItemBufferState[i] = 0;
                } Invalidate();
            } catch { 

            } finally {
                base.OnMouseLeave(e);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            SetAutoResize();
            base.OnResize(e);
        }

        private void ShownCountChanged()
        {
            StoreItemBuffer = new PluginManagerViewItem[_shownCount];
            StoreItemBufferRectangles = new Rectangle[_shownCount];
            StoreItemBufferButtonRectangles = new Rectangle[_shownCount];
            StoreItemBufferState = new byte[_shownCount];
            UpdateView();
        }

        private void ReleaseBufferState()
        {
            for (int i = 0; i < StoreItemBufferState.Length; i++)
                StoreItemBufferState[i] = 0;
            Invalidate();
        }

        public new void Dispose()
        {
            try {
                Designer?.Dispose();
                this?.Invoke(new MethodInvoker(delegate () {
                    base.Dispose();
                }));
            } catch {
                
            }
        }

        private void SetAutoResize()
        {
            var size = Size;
            var padding = Padding;
            var itemMargin = ItemMargin;
            var height = size.Height - (padding.Top + padding.Bottom);
            var itemHeight = ItemHeight + itemMargin.Top + itemMargin.Bottom;
            ShownCount = (height / itemHeight) + 1;
        }

        private void SetSize() => Size = new Size(Width, GetItemY(0, _shownCount) + Padding.Bottom);
        private Size GetItemSize(Rectangle rect, Padding padd) => new Size(rect.Width - (padd.Left + padd.Right), ItemHeight);
        private int GetItemY(int y, int l) => l < 1 ? y : y + (ItemHeight * l) + ((ItemMargin.Top + ItemMargin.Bottom) * l);
    }

    public partial class PluginManagerViewControl
    {
        private readonly Design.Controls.ScrollBar _scrollBar = new Design.Controls.ScrollBar();
        private readonly ObservableList<PluginManagerViewItem> _items = new ObservableList<PluginManagerViewItem>();
        private int _scrollIndex = 0;
        private int _selectedIndex = -1;

        public int SelectedIndex { get => _selectedIndex; set => SelectedIndexChange(true, value); }
        public int ScrollIndex { get => _scrollIndex; set => Scrolling(value); }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObservableList<PluginManagerViewItem> Items { get => _items; }

        private void Initialize()
        {
            _items.ItemsAdded += ItemsChanged;
            _items.ItemsRemoved += ItemsChanged;
            SuspendLayout();
            _scrollBar.Dock = DockStyle.Right;
            _scrollBar.Size = new Size(Consts.ScrollBarSize, Height);
            _scrollBar.ValueChanged += ScrollBar_ValueChanged;
            _scrollBar.Visible = false;
            _scrollBar.Minimum = 0;
            UpdateScrollBar();
            ResumeLayout();
            Controls.Add(_scrollBar);
        }

        private void ItemsChanged(object sender, ObservableListModified<PluginManagerViewItem> e)
        {
            UpdateView();
        }

        private void ScrollBar_ValueChanged(object sender, ScrollValueEventArgs e)
        {
            Scrolling(_scrollBar.Value);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            var s = e.Delta < 0;
            Scrolling(_scrollIndex + (s ? 1 : -1));
            base.OnMouseWheel(e);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
                SelectedIndexChange(true, _selectedIndex - (_selectedIndex > 0 ? 1 : 0));
            else if (keyData == Keys.Down)
                SelectedIndexChange(true, _selectedIndex + (_selectedIndex < _items.Count - 1 ? 1 : 0));
            else return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }

        private void UpdateView()
        {
            ScrollIndex = ScrollIndex;
        }

        private void UpdateScrollBar()
        {
            if(_scrollBar.Visible = _items.Count > _shownCount) {
                var mx = _items.Count - _shownCount;
                if (_scrollBar.Maximum != mx) _scrollBar.Maximum = mx;
                _scrollBar.Value = _scrollIndex;
            }
        }

        public void SelectedIndexChange(bool atscrl, int v)
        {
            if (v < 0 || v > _items.Count - _shownCount) { _scrollIndex = -1; ReleaseBufferState(); }
            bool w;
            if(((w = v < _scrollIndex) || v > _scrollIndex + _shownCount - 1) && atscrl)
                Scrolling(w ? v - _shownCount + 1 : v);
            _selectedIndex = v;
            var q = v - 1 - _scrollIndex;
            for (int i = 0; i < StoreItemBufferState.Length; i++)
                StoreItemBufferState[i] = (byte)(i == q ? 2 : 0);
            Invalidate();
        }

        private void Scrolling(int v)
        {
            var r = _items.Count < _shownCount ? 0 : v < 0 ? 0 :
                v > _items.Count - _shownCount ? _items.Count - _shownCount : v;
            _scrollIndex = r;
            for (int i = 0; i < StoreItemBuffer.Length; i++)
                StoreItemBuffer[i] = _items.TryGetValue(r + i);
            if(_selectedIndex != -1) {
                var q = _selectedIndex - r;
                for (int i = 0; i < StoreItemBufferState.Length; i++)
                    StoreItemBufferState[i] = (byte)(q == i ? 2 : 0);
            }
            UpdateScrollBar();
            Invalidate();
        }
    }

    internal class PluginItemDesigner : IDisposable
    {
        private readonly Design.Styles _styles;
        private readonly List<AsyncImage> _images;
        private readonly Bitmap _installedImage;
        private readonly Bitmap _installImage;
        private Font _titleFont;
        private Font _footerFont;
        private Font _font;

        public event InvalidateEventHandler Invalidate;

        public Font Font { get => _font; set { if (value != null) _font = value; 
                _titleFont = GetFont(_font, 3); _footerFont = GetFont(_font, 0); } }
        public Color TitleColor { get; set; }
        public Color Color { get; set; }
        public Color BackgroundColor { get; set; }
        public Color SelectionBackgroundColor { get; set; }
        public Color EmphaBackgroundColor { get; set; }
        public TextRenderingHint TextRendering { get; set; }

        public PluginItemDesigner(Design.Styles styles)
        {
            _installedImage = GetInstalledImage();
            _installImage = GetInstallImage();
            _styles = styles;
            _font = _styles.Font;
            TitleColor = _styles.Control.Color;
            Color = _styles.Label.Color;
            BackgroundColor = _styles.Control.BackgroundColor;
            SelectionBackgroundColor = _styles.Control.ColorSelectionBackgroundColor;
            EmphaBackgroundColor = _styles.Control.SelectionBackgroundColor;
            TextRendering = TextRenderingHint.SystemDefault;
            _titleFont = GetFont(_font, 3);
            _footerFont = GetFont(_font, 0);
            _images = new List<AsyncImage>();
        }

        public void Drawing(PluginManagerViewItem item, Graphics g, Rectangle r, byte state, out Rectangle[] RightSideBarButtons)
        {
            RightSideBarButtons = null;
            if (item == null || g == null || r == null)
                return;

            var margin = 5;
            var iconHeight = r.Height - (margin * 2);
            var footerHeight = (_footerFont ?? Font).Height + 2;
            var rightSideWidth = 32 + (int)(_styles.FontSize < _font.Size ?
                _font.Size - _styles.FontSize : 0);
            g.TextRenderingHint = TextRendering;

            //Draw Background
            var backgroundColor = state == 1 ? EmphaBackgroundColor : state == 2 ? SelectionBackgroundColor : BackgroundColor;
            using (var sb = new SolidBrush(backgroundColor))
                g.FillRectangle(sb, r);

            // Draw Image
            // Get Image
            var icon = GetImage(item.ImageURL);
            var iconSize = new Size(iconHeight, iconHeight);
            var iconRect = new Rectangle(new Point(r.X + margin, r.Y + margin), iconSize);
            if (icon != null && iconRect.Size.Width > 0 && iconRect.Size.Height > 0)
                if(Math.Max(icon.Width, icon.Height) > Math.Min(iconRect.Width, iconRect.Height))
                    using (var resizeIcon = new Bitmap(icon, iconRect.Size))
                        g.DrawImage(resizeIcon, iconRect.Location);
                else
                    g.DrawImage(icon, new Point(iconRect.Location.X + ((iconRect.Size.Width / 2) - (icon.Width / 2)),
                        iconRect.Location.Y + ((iconRect.Size.Height / 2) - (icon.Height / 2))));

            // Draw Title
            var titleRect = new Rectangle(iconRect.Left + iconRect.Width + margin, iconRect.Top,
                r.Width - (iconRect.Left + iconRect.Width + margin) - (margin + rightSideWidth) - margin, (_titleFont ?? Font).Height);
            if (item.Title != null)
                using (var sb = new SolidBrush(TitleColor))
                    g.DrawString(item.Title, _titleFont ?? Font, sb, titleRect);

            // Draw Right SideBar
            var rightSideBarSize = new Size(rightSideWidth, iconRect.Height - (footerHeight + margin));
            var footerImagesRect = new Rectangle(new Point(titleRect.Right + margin,
                titleRect.Top), rightSideBarSize);
            var footerImage = item.Installed ? _installedImage : _installImage;
            if (footerImage != null)
                using (var resizeImage = new Bitmap(footerImage, rightSideWidth, rightSideWidth))
                    g.DrawImage(resizeImage, footerImagesRect.Location);

            // Draw Overview
            var overviewRect = new Rectangle(titleRect.Left, titleRect.Bottom + margin, titleRect.Width,
                r.Height - (r.Y - titleRect.Y + titleRect.Height + (margin * 2)) - (footerHeight + (margin * 2)));
            if (item.Overview != null)
                using (var sb = new SolidBrush(Color))
                    g.DrawString(item.Overview, Font, sb, overviewRect);

            // Draw Footer Text
            var footerContext = $"{GetSize(item.Size)} | {item.Version ?? "unknown"} | {item.Publisher ?? "unknown"}";
            var footerRect = new Rectangle(overviewRect.Left, r.Bottom - (_footerFont ?? Font).Height - margin, 
                r.Width - (iconRect.Left + iconRect.Width + (margin * 2)), footerHeight);
            if (footerContext != null) {
                using (var sf = new StringFormat { Alignment = StringAlignment.Far })
                using (var sb = new SolidBrush(TitleColor))
                    g.DrawString(footerContext, _footerFont, sb, footerRect, sf);
            }

            RightSideBarButtons = new Rectangle[] { footerImagesRect };
        }

        public void CacheClear()
        {
            for (int i = 0; i < _images.Count; i++)
                _images[i]?.Dispose();
        }

        public void Dispose()
        {
            CacheClear();
            _footerFont?.Dispose();
            _titleFont?.Dispose();
            _installedImage?.Dispose();
            _installImage?.Dispose();
        }

        private Bitmap GetImage(string url)
        {
            if (url == null) return null;
            var ai = _images.OneFilter(delegate (AsyncImage asyncImage) 
            { return asyncImage?.ImageURL == url; });
            if (ai != null) return ai.IsCompletedSuccessfully ? ai.GetImage() :
                    ai.IsCompleted ? Images.discordpoop_256px : null;
            else AddAsyncImageTask(url);
            return null;
        }

        private string GetSize(long s) {
            var sizes = new string[] { "B", "KB", "MB", "GB", "TB" }; var order = 0;
            while (s >= 1024 && order < sizes.Length - 1) { order++; s /= 1024; }
            return string.Format("{0:0.##} {1}", s, sizes[order]);
        }

        private void AddAsyncImageTask(string url) => _images.Add(new AsyncImage(url, AsyncImageCompleted));

        private void AsyncImageCompleted(AsyncImage asyncImage)
        {
            Invalidate();
        }
        
        private static Bitmap GetInstallImage() => Images.cloneToDesktop_32px;
        private static Bitmap GetInstalledImage() => Images.statusInstalled_32px;
        private static Font GetFont(Font font, int s) => new Font(font.FontFamily, font.Size + s, FontStyle.Bold, font.Unit);
    }

    public delegate void PluginViewItemClickEventHandler(PluginManagerViewItem item, MouseEventArgs e);
    public delegate void PluginViewItemDoubleClickEventHandler(PluginManagerViewItem item, MouseEventArgs e);
    public delegate void PluginViewItemMouseClickEventHandler(PluginManagerViewItem item, MouseEventArgs e);
    public delegate void PluginViewItemChangedEventHandler(PluginManagerViewItem item);
    public delegate void PluginViewItemButtonClickEventHandler(PluginManagerViewItem item, MouseEventArgs e);
    internal delegate void InvalidateEventHandler();

    public class PluginManagerViewItem
    {
        public event EventHandler ValueChanged;

        public string Name { get => _name; set { _name = value; ValueChanged?.Invoke(this, default); } }
        public string Title { get => _title; set { _title = value; ValueChanged?.Invoke(this, default); } }
        public string Overview { get => _overview; set { _overview = value; ValueChanged?.Invoke(this, default); } }
        public string Version { get => _version; set { _version = value; ValueChanged?.Invoke(this, default); } }
        public string Publisher { get => _publisher; set { _publisher = value; ValueChanged?.Invoke(this, default); } }
        public string ImageURL { get => _imageURL; set { _imageURL = value; ValueChanged?.Invoke(this, default); } }
        public bool Installed { get => _installed; set { _installed = value; ValueChanged?.Invoke(this, default); } }
        public long Size { get => _size; set { _size = value; ValueChanged?.Invoke(this, default); } }
        public string Hash { get => _hash; set { _hash = value; ValueChanged?.Invoke(this, default); } }

        private string _name;
        private string _title;
        private string _overview;
        private string _version;
        private string _publisher;
        private string _imageURL;
        private bool _installed;
        private long _size;
        private string _hash;

        public static PluginManagerViewItem PluginToPluginManagerViewItem(Client.NUMC.PluginManager.Plugin plugin, bool checkInstalled = false)
        {
            var item = new PluginManagerViewItem() {
                _name = plugin.Name, _title = plugin.Title, _overview = plugin.Overview, 
                _version = plugin.Version, _publisher = plugin.Publisher, 
                _imageURL = plugin.ImageURL, _size = plugin.Size, _hash = plugin.Hash
            };
            if(checkInstalled && !string.IsNullOrWhiteSpace(plugin.Hash))
                item._installed = PluginManagerUtils.IsInstalled(plugin.Hash) != null;
            return item;
        }
    }
}
