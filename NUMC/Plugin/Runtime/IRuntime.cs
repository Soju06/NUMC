using NUMC.Plugin;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Plugin.Runtime
{
    public interface IRuntime : IPlugin, IPluginExp
    {
        string[] RuntimeNames { get; }
        IRuntimeDialog Dialog { get; }
        IRuntimeMenu Menu { get; }

        void Run(ScriptInfo scriptInfo, RuntimeScript script, bool isDown);

        string ScriptContent(RuntimeScript script, KeyObject obj);
    }
}
