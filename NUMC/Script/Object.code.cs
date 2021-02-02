using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Script
{
    public partial class ScriptObject
    {
        private string _language;
        private KeyObjects _keys;
        private JsonObject.RootObject _settings;
    }

    public partial class KeyObjects
    {
        /// <summary>
        /// Copy of List KeyObject
        /// </summary>
        public List<KeyObject> Keys
        {
            get => _keys.ToList();
            set {
                if (value == null)
                    return;

                _keys = value;
                //Initialize();
            }
        }

        #region WKeys (Disabled)

        //private readonly List<Keys> _wKeys = new List<Keys>();

        //#region Initialize

        //private void Initialize()
        //{
        //    if(_wKeys.Count >= 1)
        //        _wKeys.Clear();

        //    for (int i = 0; i < _keys.Count; i++)
        //        if (!_wKeys.Contains(_keys[i].Key))
        //            _wKeys.Add(_keys[i].Key);
        //}

        //#endregion
        //public List<Keys> GetWKeys() => _wKeys;

        #endregion

        #region GetObject

        public KeyObject GetObject(Keys keys, bool readOnly = true)
        {
            for (int i = 0; i < _keys.Count; i++)
                if (_keys[i].Key == keys)
                    return _keys[i];

            if (!readOnly)
            {
                var obj = new KeyObject(keys);

                _keys.Add(obj);

                return obj;
            }

            return null;
        }

        #endregion

        #region SetObject

        public void SetObject(KeyObject obj)
        {
            if (obj == null)
                return;

            for (int i = 0; i < _keys.Count; i++)
                if (_keys[i].Key == obj.Key)
                {
                    _keys[i] = obj;
                    return;
                }
            //_wKeys.Add(obj.Key);
            _keys.Add(obj);
        }

        #endregion

    }

    public partial class KeyObject
    {
        private KeyScript _script;


        public KeyObject Clone() => new KeyObject(Key, Ignore, Script?.Clone());

        #region Paste

        public void Paste(KeyObject keyObject)
        {
            if (keyObject == null)
                return;

            Key = keyObject.Key;
            Ignore = keyObject.Ignore;
            Script = keyObject.Script == null ? new KeyScript() : keyObject.Script.Clone();
        }

        #endregion
    }

    public partial class KeyScript
    {
        private List<RuntimeScript> _scripts;

        #region ScriptsByRuntimeName

        public IList<RuntimeScript> ScriptsByRuntimeName(string runtimeName)
        {
            if (Scripts == null)
                return null;

            var scripts = new List<RuntimeScript>();

            for (int i = 0; i < Scripts.Count; i++)
                if (Scripts[i].RuntimeName == runtimeName)
                    scripts.Add(Scripts[i]);

            return scripts;
        }

        #endregion

        #region ScriptsByRuntimeNames

        public IList<RuntimeScript> ScriptsByRuntimeNames(string[] runtimeNames)
        {
            if (Scripts == null)
                return null;

            var scripts = new List<RuntimeScript>();

            for (int i = 0; i < Scripts.Count; i++)
                if (runtimeNames.Contains(Scripts[i].RuntimeName))
                    scripts.Add(Scripts[i]);

            return scripts;
        }

        #endregion

        #region ScriptByRuntimeName

        public RuntimeScript ScriptByRuntimeName(string runtimeName)
        {
            if (Scripts == null)
                return null;

            for (int i = 0; i < Scripts.Count; i++)
                if (Scripts[i].RuntimeName == runtimeName)
                    return Scripts[i];

            return null;
        }

        #endregion

        #region ScriptByRuntimeNames

        public RuntimeScript ScriptByRuntimeNames(string[] runtimeNames)
        {
            if (Scripts == null)
                return null;

            for (int i = 0; i < Scripts.Count; i++)
                if (runtimeNames.Contains(Scripts[i].RuntimeName))
                    return Scripts[i];

            return null;
        }

        #endregion

        #region RemoveScriptsByRuntimeName

        public int RemoveScriptsByRuntimeName(string runtimeName)
        {
            if (Scripts == null)
                return 0;

            int count = 0;

            for (int i = 0; i < Scripts.Count; i++)
                if (Scripts[i].RuntimeName == runtimeName)
                {
                    Scripts.RemoveAt(i);
                    count++;
                }

            return count;
        }

        #endregion

        #region RemoveScriptByRuntimeScript

        public bool RemoveScriptByRuntimeScript(RuntimeScript runtimeScript)
        {
            if (runtimeScript == null || Scripts == null)
                return false;

            return Scripts.Remove(runtimeScript);
        }

        #endregion

        #region AddRuntimeScript

        public void AddRuntimeScript(RuntimeScript runtimeScript)
        {
            if (runtimeScript == null || Scripts == null)
                return;

            Scripts.Add(runtimeScript);
        }

        #endregion

        #region CreateAddRuntimeScript

        public void CreateAddRuntimeScript(string runtimeName, string data)
        {
            if (Scripts == null)
                return;

            Scripts.Add(new RuntimeScript(runtimeName, data));
        }

        #endregion

        #region Clone

        public KeyScript Clone()
        {
            if (Scripts == null)
                return new KeyScript();

            var scripts = new List<RuntimeScript>();

            for (int i = 0; i < Scripts.Count; i++)
                scripts.Add(Scripts[i].Clone());

            return new KeyScript(scripts);
        }

        #endregion

        #region Equals

        public static bool Equals(KeyScript script1, KeyScript script2)
        {
            if (script1 == script2)
                return true;

            if (!(script1 != null && script2 != null)
                || !(script1.Scripts != null && script2.Scripts != null)
                || script1.Scripts.Count != script2.Scripts.Count)
                return false;

            for (int i = 0; i < script1.Scripts.Count; i++)
                if (!script1.Scripts[i].Equals(script2.Scripts[i]))
                    return false;

            return true;
        }

        #endregion
    }

    public partial class RuntimeScript
    {
        public RuntimeScript Clone() => new RuntimeScript(RuntimeName, Data);
        public bool Equals(RuntimeScript script) =>
            RuntimeName == script.RuntimeName && Data == script.Data;
    }
}
