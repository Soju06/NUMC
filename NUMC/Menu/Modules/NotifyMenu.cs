using NUMC.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NUMC.Menu.Modules
{
    public class NotifyMenu : INotifyMenuModule
    {
        public ToolStripItem[] Menus
        {
            get
            {
                var items = new List<ToolStripItem>();

                AddItem(items, Language.Language.Program_Open, "Open");
                AddItem(items, Language.Language.Main_StartProgram, "StartProgram");
                AddItem(items, Language.Language.Program_Info, "Info");
                AddSeparator(items);
                InitializeLanguageMenu(AddItem(items, "Language", "Language"));
                AddSeparator(items);
                AddItem(items, Language.Language.Program_Exit, "Exit");

                MenuStripSupport.AddClickEvent(items, MenuItem_Click);

                return items.ToArray();
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
                    Handler.Handler.Showing();
                    break;

                case "Exit":
                    Application.Exit();
                    break;

                case "Info":
                    if (InfoShowed)
                        return;

                    InfoShowed = true;
                    using (ProgramInformation dialog = new ProgramInformation())
                    {
                        dialog.ShowDialog();
                    }
                    InfoShowed = false;
                    break;

                case "StartProgram":
                    menu.Checked = Setting.Setting.StartProgram;
                    break;
            }
        }

        #region Initialize_Language_Menu

        private void InitializeLanguageMenu(ToolStripMenuItem item)
        {
            var items = Language.Languages.GetToolStripItems();

            item.DropDownItems.Clear();
            MenuStripSupport.AddClickEventAdding(item, items, Language_MenuItem_Click);
        }

        #endregion Initialize_Language_Menu

        #region Language_MenuItem_Click

        private void Language_MenuItem_Click(object sender, EventArgs e)
        {
            string code = (string)((ToolStripMenuItem)sender).Tag;
            Language.Languages.Change(code);
            Handler.Handler.GetScript().Object.Language = code;

            Handler.Handler.Setting.Saving();
            Handler.Handler.Setting.Loading();
        }

        #endregion Language_MenuItem_Click

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