using NUMC.Plugin.Runtime;
using NUMC.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace NUMC.Script
{
    public class Script
    {
        private readonly IInputSimulator _simulator = new InputSimulator();
        private readonly IList<IRuntime> _runtimes;
        private ScriptObject _object = new ScriptObject();

        public Script()
        {
            _runtimes = Plugin.Plugin.ExtractPlugin<IRuntime>();

            for (int i = 0; i < _runtimes.Count; i++)
                _runtimes[i].Initialize(this);
        }

        public IInputSimulator GetSimulator() => _simulator;
        public ScriptObject GetObject() => _object;
        public IList<IRuntime> GetRuntimes() => _runtimes;

        public void StopInput() => ReleaseKeys();

        public void ReleaseKeys()
        {
            if (_simulator == null)
                return;

            Debug.WriteLine("release keys");

            Keys[] keys = (Keys[])Enum.GetValues(typeof(Keys));

            for (int i = 0; i < keys.Length; i++)
                if (_simulator.InputDeviceState.IsKeyDown(keys[i])) {
                    Debug.WriteLine($"release key: {keys[i]}");
                    _simulator.Keyboard.KeyUp(keys[i]);
                }
        }

#if DEBUG
        private readonly List<long> ds = new List<long>();
#endif

        public bool Run(Keys keys, bool isDown)
        {
            if (_object == null)
                return true;

            var obj = _object.Keys.GetObject(keys);

            if (obj == null || obj.Scripts == null)
                return true;

            var scripts = obj.Scripts;
            var scriptInfo = new ScriptInfo(keys, obj, this);

#if DEBUG
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
#endif
            try {
                for (scriptInfo.Index = 0; scriptInfo.Index >= 0 && scriptInfo.Index < scripts.Count; scriptInfo.Index++)
                {
                    var runtimeScript = scripts[scriptInfo.Index];

                    if (runtimeScript == null)
                        continue;

                    for (int l = 0; l < _runtimes.Count; l++)
                    {
                        var runtime = _runtimes[l];

                        try {
                            string[] runtimeNames;

                            if (runtime == null || (runtimeNames = runtime.RuntimeNames) == null)
                                continue;

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
            
            if (ds.Count >= int.MaxValue - byte.MaxValue) {
                Debug.WriteLine("key wt avg clear");
                ds.Clear();
            }
#endif

            return !obj.Ignore;
        }

        public string ScriptContent(RuntimeScript runtimeScript, KeyObject keyObject)
        {
            if (runtimeScript == null)
                return null;

            for (int i = 0; i < _runtimes.Count; i++) {
                var runtime = _runtimes[i];

                try {
                    string[] runtimeNames;

                    if (runtime == null || (runtimeNames = runtime.RuntimeNames) == null)
                        continue;

                    if (runtimeNames.Contains(runtimeScript.RuntimeName))
                        return runtime.ScriptContent(runtimeScript, keyObject);
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, runtime.GetType(), "IRuntime ScriptContent invoke failed", "Script");
                }
            }

            return $"Unknown script ({runtimeScript.RuntimeName})";
        }

        public void Save(string path)
        {
            try {
                Debug.WriteLine($"setting save {path}");
                File.WriteAllBytes(path, CmprsSerializer.SerializeJsonObject(_object));

                Saved?.Invoke(_object, path);
            } catch (Exception ex) {
                Debug.WriteLine($"setting save fail\n{ex}");

                var a = ex.Message;

                if (a.Length > 30)
                    a = $"{a.Substring(0, 30)}\n...";

                switch (MessageBox.Show($"{Language.Language.Message_Error_Save_Setting_Fail}\n{a}",
                    Setting.Setting.TitleName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
                {
                    case DialogResult.Retry:
                        Save(path);
                        break;
                }
            }
        }

        public void Load(string path, bool readOnly = true)
        {
            try {
                if(!File.Exists(path) && !readOnly) {
                    Debug.WriteLine($"setting createload {path}");
                    _object = new ScriptObject();

                    Save(path);
                }

                Debug.WriteLine($"setting load {path}");
                var json = Encoding.UTF8.GetString(CmprsSerializer.Deserialize(File.ReadAllBytes(path)));
                var script = Json.Json.Convert<ScriptObject>(json);

                if(script != null && script.Version != Constant.Verison)
                {
                    try {
                        string bf = null;
                        for (int i = 0; i < 10000; i++)
                            if (!File.Exists(bf = (i == 0 ? path : 
                                $"{Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path))}.ns ({i})") + ".bak")) break;
                        File.Move(path, bf);
                    } catch (Exception ex) {
                        Debug.WriteLine($"setting backup failed!\n{ex}");
                    }
                    script = old.Convert.ConvertObject(script.Version, json);
                }

                if (script == null)
                    script = new ScriptObject();


                _object = script;

                Loaded?.Invoke(script, path);
            } catch (Exception ex) {
                Debug.WriteLine($"setting load fail\n{ex}");

                var a = ex.Message;

                if (a.Length > 150)
                    a = $"{a.Substring(0, 150)}\n...";

                switch (MessageBox.Show($"{Language.Language.Message_Error_Load_Setting_Fail}\n{a}",
                    Setting.Setting.TitleName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)) {
                    case DialogResult.Retry:
                        Load(path);
                        break;

                    case DialogResult.Cancel:
                        switch (MessageBox.Show(Language.Language.Message_Warning_Reset_Setting,
                            Setting.Setting.TitleName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) {
                            case DialogResult.Yes:
                                Save(path);
                                break;
                        }
                        break;
                }
            }
        }

        public event Saved Saved;
        public event Loaded Loaded;
    }

    public delegate void Saved(ScriptObject script, string path);
    public delegate void Loaded(ScriptObject script, string path);

    public class ScriptInfo
    {
        public ScriptInfo(Keys keys, KeyObject keyObject, Script script) { Keys = keys; Object = keyObject; Script = script; }

        public int Index = 0;
        public Keys Keys;
        public KeyObject Object;
        public readonly Script Script;
    }
}