using NUMC.Menu;
using NUMC.Plugin.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NUMC.Plugins.Default {
    public class ApplicationMenu : IApplicationMenu {
        public ApplicationMenu() {
            _settingMenu = new ToolStripMenuItem();
            var items = new List<ToolStripItem> { _settingMenu };
            MenuStripSupport.AddSeparator(items);
            _releaseAllKeysMenus = MenuStripSupport.AddMenuItem(items, Language.Language.ApplicationMenu_ReleaseAllKeys, "releaseAllKeys");
            MenuStripSupport.AddSeparator(items);
            _exitMenu = MenuStripSupport.AddMenuItem(items, Language.Language.Program_Exit, "exit");
            MenuStripSupport.AddClickEvent(items, MenuItem_Click);
            _menus = items.ToArray();
        }

        private void SetSettingName(string path) =>
            _settingMenu.Text = string.Format(Language.Language.ApplicationMenu_CurrentSettings, Path.GetFileNameWithoutExtension(path));

        private readonly ToolStripItem _settingMenu;
        private readonly ToolStripItem _releaseAllKeysMenus;
        private readonly ToolStripItem _exitMenu;
        private readonly ToolStripItem[] _menus;
        private Service Service;

        public ToolStripItem[] Menus  {
            get {
                _releaseAllKeysMenus.Text = Language.Language.ApplicationMenu_ReleaseAllKeys;
                _exitMenu.Text = Language.Language.Program_Exit;
                SetSettingName(Service.GetConfig().ConfigPath);
                return _menus;
            }
        }

        public void MenuClicking() => SetSettingName(Service.GetConfig().ConfigPath);

        public int Index => 30;

        private void MenuItem_Click(object sender, EventArgs e) {
            if (sender.GetType() != typeof(ToolStripMenuItem)) return;
            if (sender == _settingMenu) {
                using var dialog = new OpenFileDialog();
                dialog.Filter = $"{Constant.Config.FileFilter}|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                    Service.GetService()?.Load(dialog.FileName);
            } else {
                var menu = (ToolStripMenuItem)sender;
                switch (menu.Tag) {
                    case "releaseAllKeys":
                        if (Service != null)
                            Service.GetScript().ReleaseKeys();
                        break;

                    case "exit":
                        Application.Exit();
                        break;
                }
            }
        }

        public void Dispose() => MenuStripSupport.DisposeItems(Menus);

        public void Initialize(Service service) {
            Service = service; SetSettingName(service.GetConfig().ConfigPath);
        }

    }
}