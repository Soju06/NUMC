using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using NUMC.Language;

namespace NUMC.Script
{
    [DataContract]
    public partial class ScriptObject
    {
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
        public JsonObject.RootObject Settings {
            get => _settings ?? (_settings = new JsonObject.RootObject());
            set => _settings = value;
        }
    }

    public partial class KeyObjects
    {
        private List<KeyObject> _keys = new List<KeyObject>();
    }

    [DataContract]
    public partial class KeyObject
    {
        public KeyObject() { }
        public KeyObject(Keys keys) { Key = keys; }
        public KeyObject(Keys keys, bool ignore, KeyScript script) {
            Key = keys; Ignore = ignore;
            if(script != null) Script = script;
        }

        [DataMember(Name = "k")]
        public Keys Key { get; set; }
        [DataMember(Name = "i")]
        public bool Ignore { get; set; }

        [DataMember(Name = "s")]
        public KeyScript Script {
            get => _script ?? (_script = new KeyScript());
            set => _script = value;
        }
    }

    [DataContract]
    public partial class KeyScript
    {
        public KeyScript() { }
        public KeyScript(params RuntimeScript[] scripts) { if (scripts != null) Scripts = scripts.ToList(); }
        public KeyScript(List<RuntimeScript> scripts) { if (scripts != null) Scripts = scripts; }

        [DataMember(Name = "s")]
        public List<RuntimeScript> Scripts {
            get => _scripts ?? (_scripts = new List<RuntimeScript>());
            set => _scripts = value;
        }
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