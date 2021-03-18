using NUMC.Config.Object;
using System.Runtime.Serialization;

namespace NUMC.Config {
    [DataContract]
    public partial class Config {
        [DataMember(Name = "lng")]
        public string Language {
            get => _language ??= "auto";
            set => _language = value;
        }

        [DataMember(Name = "keys")]
        public KeyObjects Keys {
            get => _keys ??= new KeyObjects();
            set => _keys = value;
        }

        [DataMember(Name = "configs")]
        public Json.JsonObject Configs {
            get => _settings ??= new Json.JsonObject();
            set => _settings = value;
        }

        [DataMember(Name = "version")]
        protected string Version { get; set; }

        private string _language;
        private KeyObjects _keys;
        private Json.JsonObject _settings;
    }
}
