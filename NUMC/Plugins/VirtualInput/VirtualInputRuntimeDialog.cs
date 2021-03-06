﻿using NUMC.Script;
using NUMC.Plugin.Runtime;
using NUMC.Config.Object;

namespace NUMC.Plugins.VirtualInput
{
    public class VirtualInputRuntimeDialog : IRuntimeDialog
    {
        public bool ShowDialog(RuntimeScript runtimeScript, KeyObject obj) =>
            new VirtualInputDialog(runtimeScript, obj).ShowDialog() == System.Windows.Forms.DialogResult.OK;
    }
}