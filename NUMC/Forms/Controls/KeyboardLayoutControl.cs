using NUMC.Plugin.KeyboardLayout;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Forms.Controls {
    public class KeyboardLayoutControl : Design.Controls.UserControl {
        public event LayoutMenuShowEventHandler LayoutMenuShow;
        new public event MouseClickEventHandler MouseClick;

        private Service _service;
        private IKeyboardLayout _keyboardLayout;

        public IKeyboardLayout KeyboardLayout {
            get => _keyboardLayout;
            set {
                if (SetLayout(value)) {
                    var v = _keyboardLayout == null;
                    _keyboardLayout = value;
                    var parentForm = ParentForm;
                    if (parentForm != null) CalcSize(parentForm);
                    if (v) SetFormLocationCenter();
                    var fn = value?.GetType().FullName;
                    if(fn != null) SetLayoutSettings(fn);
                }
            }
        }

        public KeyboardLayoutControl() {
            SuspendLayout();
            BackColor = Color.Transparent;
            Load += KeyboardLayoutControl_Load;
            SetStyle(ControlStyles.DoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            ResumeLayout();
        }

        public void Initialize(Service service) => _service = service;

        private void KeyboardLayoutControl_Load(object sender, EventArgs e) {
            var parentForm = ParentForm;
            if (parentForm != null) {
                SuspendLayout();
                CalcSize(parentForm);
                ResumeLayout();
            } InitializeLayout();
        }

        private void CalcSize(Form form) {
            Location = new Point(Constant.Form.Padding.Left, Constant.Form.Padding.Top);
            Size = new Size(form.ClientSize.Width - (Constant.Form.Padding.Left + Constant.Form.Padding.Right),
                form.ClientSize.Height - (Constant.Form.Padding.Top + Constant.Form.Padding.Bottom));
            if (_keyboardLayout == null) return;
            var control = (UserControl)_keyboardLayout;
            var miniSize = control.MinimumSize.IsEmpty ? control.Size : control.MinimumSize;
            var maxSize = control.MaximumSize.IsEmpty ? control.Size : control.MaximumSize;
            var size = control.Size;
            form.MaximumSize = CalcSize(maxSize);
            form.MinimumSize = CalcSize(miniSize);
            form.Size = CalcSize(size);
            control.Size = size;
        }

        private Size CalcSize(Size insize) {
            return new Size(insize.Width + Constant.Form.Padding.Left + Constant.Form.Padding.Right,
                insize.Height + Constant.Form.Padding.Top + Constant.Form.Padding.Bottom);
        }

        private bool SetLayout(IKeyboardLayout layout) {
            if (layout == null || !layout.GetType().IsSubclassOf(typeof(Control))) return false;
            Debug.WriteLine($"set layout {layout.GetType().FullName}");
            SuspendLayout();
            if(_keyboardLayout != null)
                try {
                    _keyboardLayout.MouseClick -= MouseClick;
                    _keyboardLayout.LayoutRemove();
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, _keyboardLayout?.GetType()?.Name, "LayoutRemove invoke failed");
                } 
            ClearControls();
            try {
                layout.LayoutLoad();
            } catch (Exception ex) {
                Plugin.Plugin.PluginException(ex, layout?.GetType()?.Name, "LayoutLoad invoke failed");
            }

            var control = (Control)layout;
            layout.LayoutMenuShow += MenuShow;
            layout.MouseClick += MouseClick;
            control.Location = new Point(0, 0);
            control.Dock = DockStyle.None;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            Controls.Add(control);
            ResumeLayout();
            return true;
        }

        private void MenuShow(Keys keys, Point loc) {
            var l = loc.IsEmpty ? MousePosition : loc;
            LayoutMenuShow?.Invoke(keys, l);
        }

        private void ClearControls() {
            for (int i = 0; i < Controls.Count; i++)
                Controls.Remove(Controls[i]);
        }

        private void InitializeLayout() {
            var layouts = Plugin.Plugin.ExtractPlugin<IKeyboardLayout>();
            var type = typeof(Control);
            if (layouts != null)
                for (int i = 0; i < layouts.Count; i++) {
                    var l = layouts[i]; var ts = l.GetType();
                    if (l != null && ts.IsSubclassOf(type) && ts.FullName == GetLayoutSettings()) {
                        KeyboardLayout = l; break;
                    }
                }

            if (_keyboardLayout != null) return;
            KeyboardLayout = new Plugins.KeyboardLayouts.KeyboardLayout();
        }

        public void SetFormLocationCenter() {
            var parentForm = ParentForm;
            if (parentForm != null) {
                var r = Screen.FromPoint(Location).Bounds;
                parentForm.Location = new Point(
                    r.X + (r.Width / 2) - (parentForm.Width / 2),
                    r.Y + (r.Height / 2)- (parentForm.Height / 2));
            }
        }

        private void SetLayoutSettings(string typeName) {
            var o = GetLayoutSettings(); GetLayoutSettingsValue()?.SetString(typeName); 
            if(o != typeName) Service.GetService()?.Save();
        }

        private string GetLayoutSettings() => GetLayoutSettingsValue()?.GetString();
        private Json.Value GetLayoutSettingsValue() => _service?.GetConfig()?
            .Configs?["+NUMC"]?["+Main"]?.SubKeys?["+KeyboardLayout"]?.Values?["+DefaultLayout"];
    }
}