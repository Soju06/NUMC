using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace NUMC.Script
{
    [DataContract]
    public partial class ScriptObject
    {
        public ScriptObject() {
            Version = Constant.Verison;
        }

        [DataMember(Name = "lng")]
        public string Language {
            get => _language ?? (_language = "auto");
            set => _language = value;
        }

        [DataMember(Name = "keys")]
        public KeyObjects Keys {
            get => _keys ?? (_keys = new KeyObjects());
            set => _keys = value;
        }

        [DataMember(Name = "settings")]
        public Json.JsonObject Settings {
            get => _settings ?? (_settings = new Json.JsonObject());
            set => _settings = value;
        }


        [DataMember(Name = "version")]
        public string Version { get; set; }
    }

    public partial class KeyObjects : List<KeyObject>
    {
        public KeyObjects() { }
        public KeyObjects(params KeyObject[] objects) { if (objects != null) AddRange(objects); }
        public KeyObjects(List<KeyObject> objects) { if (objects != null) AddRange(objects); }
    }


    [DataContract]
    public partial class KeyObject
    {
        public KeyObject() { }
        public KeyObject(Keys keys) { Key = keys; }
        public KeyObject(Keys keys, bool ignore, KeyScript script) {
            Key = keys; Ignore = ignore;
            if(script != null) Scripts = script;
        }

        [DataMember(Name = "k")]
        public Keys Key { get; set; }
        [DataMember(Name = "i")]
        public bool Ignore { get; set; }

        [DataMember(Name = "s")]
        public KeyScript Scripts {
            get => _script ?? (_script = new KeyScript());
            set => _script = value;
        }
    }

    public partial class KeyScript : List<RuntimeScript>
    {
        public KeyScript() { }
        public KeyScript(params RuntimeScript[] scripts) { if (scripts != null) AddRange(scripts); }
        public KeyScript(List<RuntimeScript> scripts) { if (scripts != null) AddRange(scripts); }
    }

    [DataContract]
    public partial class RuntimeScript
    {
        public RuntimeScript() { }
        public RuntimeScript(string runtimeName, string data) { RuntimeName = runtimeName; Data = data; }

        [DataMember(Name = "r")]
        public string RuntimeName { get; set; }
        [DataMember(Name = "d")]
        public string Data { get; set; }
    }
}