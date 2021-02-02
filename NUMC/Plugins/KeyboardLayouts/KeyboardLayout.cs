using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using NUMC.Plugin.KeyboardLayout;
using System.Threading;
using System.Diagnostics;

namespace NUMC.Plugins.KeyboardLayouts
{
    public partial class KeyboardLayout : Design.Controls.UserControl, IKeyboardLayout
    {
        public new string Name => "KeyboardLayout";
        public int Index => 0;

        public event LayoutMenuShowEventHandler LayoutMenuShow;
        public new event MouseClickEventHandler MouseClick;

        public KeyboardLayout()
        {
            FontSize = 9F;
            BackColor = Color.Transparent;
            RemoveKeyLayout();
        }

        void IKeyboardLayout.LayoutRemove()
        {
            Visible = false;
            SuspendLayout();
            RemoveKeyLayout();
            ResumeLayout();
            Visible = true;
        }

        void IKeyboardLayout.LayoutLoad()
        {
            Visible = false;
            SetKeyLayout(Setting.CmprsSerializer.DeserializeJsonObject<KeyLayout>
                (Convert.FromBase64String(KeyboardLayoutResource.KeyBoard)));
            Visible = true;
        }

        public KeyLayout GetKeyLayout()
        {
            var l = new KeyLayout() { MaximumSize = MaximumSize, MinimumSize = MinimumSize, Size = Size };
            var ls = new List<Key>();
            for (int i = 0; i < Controls.Count; i++) {
                var c = Controls[i];
                if (c.Tag?.GetType() != typeof(string))
                    continue;
                var r = int.Parse((string)c.Tag);
                var k = new Key() { Keys = (Keys)r, Rectangle = 
                    new Rectangle(c.Location, c.Size), Text = ((Keys)r).ToString() };
                ls.Add(k);
            }
            l.Keys = ls;
            return l;
        }

        public void SetKeyLayout(KeyLayout layout)
        {
            if (layout == null)
                return;
            SuspendLayout();
            RemoveKeyLayout();
            MinimumSize = layout.MinimumSize;
            MaximumSize = layout.MaximumSize;
            Size = layout.Size;
            var anchorStyle = AnchorStyles.None;
            var flatStyle = FlatStyle.Flat;
            var keys = layout.Keys;
            if (keys != null)
                for (int i = 0; i < keys.Count; i++) {
                    var k = keys[i];
                    var b = new Button() { Text = k.Text, Location = k.Rectangle.Location,
                        Size = k.Rectangle.Size, Anchor = anchorStyle, FlatStyle = flatStyle, Tag = k.Keys,
                        BackColor = BackColor, ForeColor = _styles.Control.Color, TabIndex = 1, AutoEllipsis = true
                    };
                    b.FlatAppearance.BorderSize = 2;
                    b.FlatAppearance.BorderColor = Color.FromArgb(60, 255, 255, 255);
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 255, 255, 255);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 255, 255, 255);
                    b.NotifyDefault(false);
                    b.MouseUp += Mouse_Up;
                    Controls.Add(b);
                }
            Select();
            ResumeLayout();
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            var parentForm = ParentForm;
            if (parentForm == null || new Rectangle(parentForm.Location, parentForm.Size).Contains(MousePosition)) {
                var k = GetSenderKeys(sender);
                if (e.Button == MouseButtons.Left) LayoutMenuShow?.Invoke(k, MousePosition);
                MouseClick?.Invoke(k, e.Button);
            }
        }

        private Keys GetSenderKeys(object sender)
        {
            var t = typeof(Button);
            if (sender?.GetType() != t) return Keys.None;
            if (!(sender is Button b) || b.Tag == null || b.Tag?.GetType() != typeof(Keys))
                return Keys.None;
            return (Keys)b.Tag;
        }

        private void RemoveKeyLayout()
        {
            foreach (Control item in Controls) {
                if (item.IsDisposed || item.Disposing)
                    continue;
                Controls.Remove(item);
                item.Dispose();
            }
            if (Controls.Count > 0)
                RemoveKeyLayout();
        }

        [DataContract]
        public class KeyLayout
        {
            [DataMember(Name = "maxSize")]
            public Size MaximumSize { get; set; }
            [DataMember(Name = "miniSize")]
            public Size MinimumSize { get; set; }
            [DataMember(Name = "size")]
            public Size Size { get; set; }
            [DataMember(Name = "keys")]
            public List<Key> Keys { get; set; }
        }

        [DataContract]
        public class Key
        {
            [DataMember(Name = "k")]
            public Keys Keys { get; set; }
            [DataMember(Name = "r")]
            public Rectangle Rectangle { get; set; }
            [DataMember(Name = "t")]
            public string Text { get; set; }
        }
    }
}
