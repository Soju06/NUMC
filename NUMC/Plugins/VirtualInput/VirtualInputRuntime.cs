using NUMC.Config.Object;
using NUMC.Plugin.Runtime;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace NUMC.Plugins.VirtualInput {
    public class VirtualInputRuntime : IRuntime {
        public VirtualInputRuntime() {
            Dialog = new VirtualInputRuntimeDialog();
            Menu = new VirtualInputRuntimeMenu((VirtualInputRuntimeDialog)Dialog);
        }

        public int Index => 0;

        private IInputSimulator InputSimulator { get; set; }

        public IRuntimeDialog Dialog { get; private set; }

        public IRuntimeMenu Menu { get; private set; }

        public void Initialize(Service service) => InputSimulator = service.GetScript().GetSimulator();

        public void Run(ScriptInfo scriptInfo, RuntimeScript runtimeScript, bool isDown) {
            if (runtimeScript == null || InputSimulator == null) return;
            try {
                if (isDown) {
                    switch (runtimeScript.RuntimeName) {
                        case "NUMC.VirtualKey": {
                                var a = ConvertKeys(runtimeScript.Data);

                                for (int l = 0; l < a.Count; l++)
                                    InputSimulator.Keyboard.KeyDown(a[l]);
                            } break;

                        case "NUMC.VirtualSendKeys": {
                                var a = ConvertKeys(runtimeScript.Data);

                                for (int l = 0; l < a.Count; l++)
                                    InputSimulator.Keyboard.KeyPress(a[l]);
                            } break;

                        case "NUMC.TextEntry":    
                            InputSimulator.Keyboard.TextEntry(runtimeScript.Data);
                            break;
                    }
                } else {
                    switch (runtimeScript.RuntimeName) {
                        case "NUMC.VirtualKey": {
                                var a = ConvertKeys(runtimeScript.Data);
                                for (int l = 0; l < a.Count; l++)
                                    InputSimulator.Keyboard.KeyUp(a[l]);
                            } break;
                    }
                }
            } catch (Exception ex) {
                Task.Run(() => {
                    Plugin.Plugin.PluginException(ex, "Virtual Input Runtime", "Virtual Input Runtime");
                }).Start();
            }
        }


        public static IList<Keys> ConvertKeys(string data) {
            if (data == null) return Array.Empty<Keys>();
            var keys = new List<Keys>();
            var kds = data.Split(',');
            for (int i = 0; i < kds.Length; i++)
                if (int.TryParse(kds[i], out int key))
                    keys.Add((Keys)key);
            return keys;
        }

        public static string ConvertString(params Keys[] keys) => string.Join(",", keys.Cast<int>());

        string IRuntime.ScriptContent(RuntimeScript script, KeyObject obj) => ScriptContent(script);

        public void Dispose() { }

        public static string[] RuntimeNames { get; } = new [] { 
            "NUMC.VirtualKey", "NUMC.VirtualSendKeys", "NUMC.TextEntry" 
        };

        string[] IRuntime.RuntimeNames { get; } = RuntimeNames;

        public static string ScriptContent(RuntimeScript script) {
            string name;
            switch (script.RuntimeName) {
                case "NUMC.VirtualKey":
                    name = Language.Language.VirtualInputDialog_VirtualKey_Name;
                    break;

                case "NUMC.VirtualSendKeys":
                    name = Language.Language.VirtualInputDialog_VirtualSendKeys_Name;
                    break;

                case "NUMC.TextEntry":
                    name = Language.Language.VirtualInputDialog_TextEntry_Name;
                    break;

                default:
                    return null;
            }
            var content = script.RuntimeName switch {
                "NUMC.VirtualKey" or "NUMC.VirtualSendKeys" => string.Join(", ", ConvertKeys(script.Data)),
                "NUMC.TextEntry" => script.Data, _ => null,
            };
            if (content != null) {
                if (content.Length > 30)
                    content = content.Substring(0, 30) + " ...";
                content = $" ({content})";
            } return $"{name}{content}";
        }
    }
}
