using NUMC.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NUMC.Menu.Modules
{
    public class ApplicationMenu : IApplicationMenuModule
    {
        public ApplicationMenu()
        {
            SettingMenu = new ToolStripMenuItem();
            SettingMenu.Click += SettingMenu_Click;
            SetSettingName(Setting.Setting.KeySettingPath);

            Handler.Handler.LoadSetting += Handler_LoadSetting;
        }

        private void SettingMenu_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Json Files|*.json|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                    Handler.Handler.LoadSettings(dialog.FileName);
            }
        }

        private void Handler_LoadSetting(string path) => SetSettingName(path);

        private void SetSettingName(string path) =>
            SettingMenu.Text = string.Format(Language.Language.ApplicationMenu_CurrentSettings, Path.GetFileNameWithoutExtension(path));

        private readonly ToolStripItem SettingMenu;

        public ToolStripItem[] Menus
        {
            get
            {
                var items = new List<ToolStripItem>
                {
                    SettingMenu
                };
                AddSeparator(items);
                AddItem(items, Language.Language.Main_JsonEditor, "JsonEditor");
                AddSeparator(items);
                AddItem(items, Language.Language.Program_Exit, "Exit");

                MenuStripSupport.AddClickEvent(items, MenuItem_Click);

                return items.ToArray();
            }
        }

        public int Index => 0;

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;

            var menu = (ToolStripMenuItem)sender;

            switch (menu.Tag)
            {
                case "Exit":
                    Application.Exit();
                    break;

                case "JsonEditor":
                    using (JsonEditorDialog jsonDialog = new JsonEditorDialog(Handler.Handler.GetScript()))
                    {
                        if (jsonDialog.ShowDialog() == DialogResult.OK)
                            Handler.Handler.Setting.Loading();
                    }
                    break;
            }
        }

        private void AddSeparator(IList<ToolStripItem> items)
        {
            items.Add(new ToolStripSeparator());
        }

        private ToolStripMenuItem AddItem(IList<ToolStripItem> items, string text, object tag)
        {
            var item = new ToolStripMenuItem() { Text = text, Tag = tag };
            items.Add(item);
            return item;
        }
    }
}