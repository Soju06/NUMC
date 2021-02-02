using NUMC.Keyboard;
using NUMC.Menu;
using NUMC.Plugin;
using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WinUtils;

namespace NUMC
{
    public partial class Main : Design.Form
    {
        private readonly Service Service;

        public Main(Service service)
        {
            Service = service;
            
            InitializeComponent();
            InitializeLayout();
            InitializeForm();
            InitializeLanguage();
            InitializeMenu();
        }

        #region Form

        #region FormEvents

        #region Main_FormClosing

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                return;
            }
        }

        #endregion Main_FormClosing

        #region Main_KeyDown

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Apps)
                ApplicationMenuShow(Location);
        }

        #endregion Main_KeyDown

        #region Main_MouseClick

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ApplicationMenuShow(MousePosition);
        }

        #endregion Main_MouseDown

        #endregion FormEvents

        #region NotifyIcon

        #region NotifyIcon_MouseClick

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
            else
                NotifyIconContextMenu.Show(MousePosition);
        }

        #endregion NotifyIcon_MouseClick

        #endregion NotifyIcon

        new public void Show()
        {
            base.Show();
            WinAPI.SetForegroundWindow(Handle);
        }

        #endregion

        #region Initialize

        #region Initialize_Form

        private void InitializeForm()
        {
            MaximizeBox = false;
            MinimizeBox = false;

            MouseClick += Main_MouseClick;
            KeyDown += Main_KeyDown;

            NotifyIcon.Icon = System.Drawing.Icon.FromHandle(Design.Images.NUMC_SMALL_ICON.GetHicon());
            Icon = Design.Images.NUMC_PNG_ICON.ToBitmap();
        }

        #endregion Initialize_Form

        #region Initialize_Language

        private void InitializeLanguage()
        {
            Text = Setting.Setting.GetTitleName(Language.Language.Main_Title);
        }

        #endregion Initialize_Language

        #region Initialize_Layout

        private void InitializeLayout()
        {
            KeyboardLayout = new Forms.Controls.KeyboardLayoutControl();
            KeyboardLayout.Initialize(Service?.GetScript());

            SuspendLayout();

            KeyboardLayout.Anchor = AnchorStyles.Top |
                AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KeyboardLayout.BackColor = Color.Transparent;
            KeyboardLayout.FontSize = 10F;
            KeyboardLayout.TabIndex = 4;

            KeyboardLayout.LayoutMenuShow += LayoutMenuShow;
            KeyboardLayout.MouseClick += LayoutMouseClick;

            Controls.Add(KeyboardLayout);
            Controls.SetChildIndex(KeyboardLayout, 1);
            ResumeLayout(false);
        }

        #endregion

        #region Initialize_Menu

        private void InitializeMenu()
        {
            ApplicationContextMenu.Items.Clear();
            NotifyIconContextMenu.Items.Clear();
            NUMContextMenu.Items.Clear();

            ApplicationContextMenu.Items.AddRange(Plugin.Menu.Menu.GetMenusItems(Service?.GetApplicationMenus()));
            NotifyIconContextMenu.Items.AddRange(Plugin.Menu.Menu.GetMenusItems(Service?.GetNotifyMenus()));
            NUMContextMenu.Items.AddRange(Plugin.Menu.Menu.GetMenusItems(Service?.GetKeyMenus()));
        }

        #endregion

        #endregion Initialize

        #region ReloadLanguage

        public void ReloadLanguage()
        {
            InitializeLanguage();
            InitializeMenu();
            GC.Collect();
        }

        #endregion ReloadLanguage

        #region LayoutMenu_Events

        private void LayoutMenuShow(Keys keys, Point loc)
        {
            if (keys == Keys.None) return;
            var keyObject = Service?.GetScript()?.GetObject()?.Keys.GetObject(keys, false);
            var keyMenus = Service?.GetKeyMenus();
            Debug.WriteLine($"layout click ({keys})");
            if (keyMenus == null) return;

            for (int i = 0; i < keyMenus.Count; i++) {
                var plugin = keyMenus[i];
                if (plugin == null) continue;
                try {
                    plugin.MenuClicking(keyObject, keys);
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, plugin.GetType(), "IKeyMenu MenuClicking invoke failed", "Main");
                }
            }

            NUMContextMenu.Show(MousePosition);
        }

        private void LayoutMouseClick(Keys _, MouseButtons Button)
        {
            if(Button == MouseButtons.Right) {
                ApplicationMenuShow(MousePosition); return;
            }
        }

        #endregion LayoutMenu_Events

        #region ApplicationMenu_Show

        private void ApplicationMenuShow(Point p)
        {
            var menus = Service?.GetApplicationMenus();

            if (menus == null)
                return;

            for (int i = 0; i < menus.Count; i++)
            {
                var plugin = menus[i];

                if (plugin == null)
                    continue;

                try
                {
                    plugin.MenuClicking();
                }
                catch (Exception ex)
                {
                    Plugin.Plugin.PluginException(ex, plugin.GetType(), "IApplicationMenu MenuClicking invoke failed", "Main");
                }
            }

            ApplicationContextMenu.Show(p);
        }

        #endregion ApplicationMenu_Show

        #region Get

        public Forms.Controls.KeyboardLayoutControl GetKeyboardLayout() => KeyboardLayout;

        #endregion

        #region Design Member

        private Forms.Controls.KeyboardLayoutControl KeyboardLayout;

        #endregion
    }
}