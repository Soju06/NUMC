using NUMC.Design.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Plugins.ScriptEditor
{
    public interface IScriptEditor
    {
        void RefreshView();
        IListViewItem GetSelectedItem();
    }
}
