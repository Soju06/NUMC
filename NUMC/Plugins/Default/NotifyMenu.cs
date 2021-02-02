using NUMC.Forms.Dialogs;
using NUMC.Menu;
using NUMC.Plugin.Menu;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NUMC.Plugins.Default
{
    public class NotifyMenu : INotifyMenu
    {
        private List<ToolStripItem> Items;
        private Script.Script Script;

        public ToolStripItem[] Menus
        {
            get
            {
                MenuStripSupport.DisposeItems(Items);

                if(Items == null)
                    Items = new List<ToolStripItem>();
                MenuStripSupport.AddMenuItem(Items, Language.Language.Program_Open, "Open");
                MenuStripSupport.AddMenuItem(Items, Language.Language.Program_StartProgram, "StartProgram").Checked = Setting.Setting.StartProgram;
                MenuStripSupport.AddMenuItem(Items, Language.Language.Program_Info, "Info");
                MenuStripSupport.AddSeparator(Items);
                InitializeLanguageMenu(MenuStripSupport.AddMenuItem(Items, "Language", "Language"));
                MenuStripSupport.AddSeparator(Items);
                MenuStripSupport.AddMenuItem(Items, Language.Language.Program_Exit, "Exit");
                MenuStripSupport.AddClickEvent(Items, MenuItem_Click);
                return Items.ToArray();
            }
        }

        public int Index => 0;

        private bool InfoShowed = false;

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;

            var menu = (ToolStripMenuItem)sender;

            switch (menu.Tag)
            {
                case "Open":
                    Service.GetService().Show();
                    break;

                case "Exit":
                    Application.Exit();
                    break;

                case "Info":
                    if (InfoShowed)
                        return;

                    InfoShowed = true;
                    using (ProgramInformation dialog = new ProgramInformation())
                        dialog.ShowDialog();
                    InfoShowed = false;
                    break;

                case "StartProgram":
                    Setting.Setting.StartProgram = menu.Checked = !Setting.Setting.StartProgram;
                    break;
            }
        }

        #region Initialize_Language_Menu

        private void InitializeLanguageMenu(ToolStripMenuItem item)
        {
            var items = Language.Languages.GetToolStripItems();

            item.DropDownItems.Clear();
            MenuStripSupport.AddClickEventSubItemsAdding(item, items, Language_MenuItem_Click);
        }

        #endregion Initialize_Language_Menu

        #region Language_MenuItem_Click

        private void Language_MenuItem_Click(object sender, EventArgs e)
        {
            string code = (string)((ToolStripMenuItem)sender).Tag;
            Language.Languages.Change(code);
            Script.GetObject().Language = code;

            Service.GetService()?.Save();
            Service.GetService()?.Load();
        }

        #endregion Language_MenuItem_Click

        public void Dispose() => MenuStripSupport.DisposeItems(Items);

        public void Initialize(Script.Script script) { Script = script; }

        public void MenuClicking() { }
    }
}