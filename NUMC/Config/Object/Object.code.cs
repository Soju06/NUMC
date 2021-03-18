using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Config.Object
{
    public partial class KeyObjects
    {
        /// <summary>
        /// Copy of List KeyObject
        /// </summary>
        public List<KeyObject> Keys
        {
            get => this;
            set {
                if (value == null)
                    return;

                Clear();
                AddRange(value);
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
            for (int i = 0; i < Count; i++)
                if (this[i].Key == keys)
                    return this[i];

            if (!readOnly) {
                var obj = new KeyObject(keys); Add(obj); 
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

            for (int i = 0; i < Count; i++)
                if (this[i].Key == obj.Key) {
                    this[i] = obj;
                    return;
                }
            //_wKeys.Add(obj.Key);
            Add(obj);
        }

        #endregion

    }

    public partial class KeyObject
    {
        private KeyScript _script;


        public KeyObject Clone() => new KeyObject(Key, Ignore, Scripts?.Clone());

        #region Paste

        public void Paste(KeyObject keyObject)
        {
            if (keyObject == null)
                return;

            Key = keyObject.Key;
            Ignore = keyObject.Ignore;
            Scripts = keyObject.Scripts == null ? new KeyScript() : keyObject.Scripts.Clone();
        }

        #endregion
    }

    public partial class KeyScript
    {
        #region ScriptsByRuntimeName

        public IList<RuntimeScript> ScriptsByRuntimeName(string runtimeName)
        {
            if (this == null)
                return null;

            var scripts = new List<RuntimeScript>();

            for (int i = 0; i < Count; i++)
                if (this[i].RuntimeName == runtimeName)
                    scripts.Add(this[i]);

            return scripts;
        }

        #endregion

        #region ScriptsByRuntimeNames

        public IList<RuntimeScript> ScriptsByRuntimeNames(string[] runtimeNames)
        {
            if (this == null)
                return null;

            var scripts = new List<RuntimeScript>();

            for (int i = 0; i < Count; i++)
                if (runtimeNames.Contains(this[i].RuntimeName))
                    scripts.Add(this[i]);

            return scripts;
        }

        #endregion

        #region ScriptByRuntimeName

        public RuntimeScript ScriptByRuntimeName(string runtimeName)
        {
            if (this == null)
                return null;

            for (int i = 0; i < Count; i++)
                if (this[i].RuntimeName == runtimeName)
                    return this[i];

            return null;
        }

        #endregion

        #region ScriptByRuntimeNames

        public RuntimeScript ScriptByRuntimeNames(string[] runtimeNames)
        {
            if (this == null)
                return null;

            for (int i = 0; i < Count; i++)
                if (runtimeNames.Contains(this[i].RuntimeName))
                    return this[i];

            return null;
        }

        #endregion

        #region RemoveScriptsByRuntimeName

        public int RemoveScriptsByRuntimeName(string runtimeName)
        {
            if (this == null)
                return 0;

            int count = 0;

            for (int i = 0; i < Count; i++)
                if (this[i].RuntimeName == runtimeName) {
                    RemoveAt(i);
                    count++;
                }

            return count;
        }

        #endregion

        #region RemoveScriptByRuntimeScript

        public bool RemoveScriptByRuntimeScript(RuntimeScript runtimeScript)
        {
            if (runtimeScript == null || this == null)
                return false;

            return Remove(runtimeScript);
        }

        #endregion

        #region AddRuntimeScript

        public void AddRuntimeScript(RuntimeScript runtimeScript)
        {
            if (runtimeScript == null || this == null)
                return;

            Add(runtimeScript);
        }

        #endregion

        #region CreateAddRuntimeScript

        public void CreateAddRuntimeScript(string runtimeName, string data)
        {
            if (this == null)
                return;

            Add(new RuntimeScript(runtimeName, data));
        }

        #endregion

        #region Clone

        public KeyScript Clone()
        {
            if (this == null)
                return new KeyScript();

            var scripts = new KeyScript();

            for (int i = 0; i < Count; i++)
                scripts.Add(this[i].Clone());

            return scripts;
        }

        #endregion

        #region Equals

        public static bool Equals(KeyScript script1, KeyScript script2)
        {
            if (script1 == script2)
                return true;

            if (!(script1 != null && script2 != null)
                || !(script1 != null && script2 != null)
                || script1.Count != script2.Count)
                return false;

            for (int i = 0; i < script1.Count; i++)
                if (!script1[i].Equals(script2[i]))
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
