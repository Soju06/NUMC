using NUMC.Plugin.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WindowsInput;
using NUMC.Config.Object;

namespace NUMC.Script {
    public class Script {
        private readonly IList<IRuntime> _runtimes;
        private readonly Config.Config _config;
        private readonly Service _service;
        private readonly IInputSimulator _simulator;

        public Script(Config.Config config, Service service) {
            _config = config; _service = service; _simulator = service.GetInputSimulator();
            _runtimes = Plugin.Plugin.ExtractPlugin<IRuntime>();
        }

        internal void Initialize() {
            for (int i = 0; i < _runtimes.Count; i++)
                _runtimes[i].Initialize(_service);
        }

        public IInputSimulator GetSimulator() => _simulator;
        public Config.Config GetConfig() => _config;
        public Service GetService() => _service;
        public IList<IRuntime> GetRuntimes() => _runtimes;

        public void StopInput() => ReleaseKeys();

        public void ReleaseKeys() {
            if (_simulator == null) return;
            Debug.WriteLine("release keys");
            var keys = (Keys[])Enum.GetValues(typeof(Keys));
            for (int i = 0; i < keys.Length; i++)
                if (_simulator.InputDeviceState.IsKeyDown(keys[i])) {
                    Debug.WriteLine($"release key: {keys[i]}");
                    _simulator.Keyboard.KeyUp(keys[i]);
                }
        }

#if DEBUG
        private readonly List<long> ds = new();
#endif

        public bool Run(Keys keys, bool isDown) {
            if (_config == null) return true;
            var obj = _config.Keys.GetObject(keys);
            if (obj == null || obj.Scripts == null) return true;
            var scripts = obj.Scripts;
            var scriptInfo = new ScriptInfo(keys, obj, this);

#if DEBUG
            var stopwatch = new Stopwatch();
            stopwatch.Start();
#endif
            try {
                for (scriptInfo.Index = 0; scriptInfo.Index >= 0 && 
                    scriptInfo.Index < scripts.Count; scriptInfo.Index++) {
                    var runtimeScript = scripts[scriptInfo.Index];
                    if (runtimeScript == null) continue;
                    for (int l = 0; l < _runtimes.Count; l++) {
                        var runtime = _runtimes[l];
                        try {
                            string[] runtimeNames;
                            if (runtime == null || 
                                (runtimeNames = runtime.RuntimeNames) == null) continue;
                            if (runtimeNames.Contains(runtimeScript.RuntimeName))
                                runtime?.Run(scriptInfo, runtimeScript, isDown);
                        } catch (Exception ex) {
                            Plugin.Plugin.PluginException(ex, _runtimes[l].GetType(), "IRuntime Run invoke failed", "Script");
                        }
                    }
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }
#if DEBUG
            stopwatch.Stop();
            ds.Add(stopwatch.ElapsedTicks);
            Debug.WriteLine("key{0}\t{1}\t\twt:\tms:\t{2}\ttick:\t{3}\tavg:\t{4}", isDown ? "down:" : "up:\t", 
                keys, stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks, Enumerable.Average(ds));

            if (ds.Count >= ushort.MaxValue) {
                Debug.WriteLine("key wt avg clear"); ds.Clear();
            }
#endif
            return !obj.Ignore;
        }

        public string ScriptContent(RuntimeScript runtimeScript, KeyObject keyObject) {
            if (runtimeScript == null) return null;
            for (int i = 0; i < _runtimes.Count; i++) {
                var runtime = _runtimes[i];
                try {
                    string[] runtimeNames;
                    if (runtime == null || 
                        (runtimeNames = runtime.RuntimeNames) == null) continue;
                    if (runtimeNames.Contains(runtimeScript.RuntimeName))
                        return runtime.ScriptContent(runtimeScript, keyObject);
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, runtime.GetType(), "IRuntime ScriptContent invoke failed", "Script");
                }
            } return $"Unknown script ({runtimeScript.RuntimeName})";
        }
    }

    /// <summary>
    /// 스크립트 정보
    /// </summary>
    public class ScriptInfo {
        public ScriptInfo(Keys keys, KeyObject keyObject, Script script) {
            Keys = keys; Object = keyObject; Script = script; 
        }

        public int Index = 0;
        public Keys Keys;
        public KeyObject Object;
        public Script Script;
    }
}