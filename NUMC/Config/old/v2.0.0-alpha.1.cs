﻿using NUMC.Config.old.v200a3;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace NUMC.Config.old.v200a1 {
    [DataContract]
    public partial class ScriptObject {
        [DataMember(Name = "lng")]
        public string Language { get; set; }

        [DataMember(Name = "keys")]
        public KeyObjects Keys { get; set; }

        [DataMember(Name = "settings")]
        public v200a2.JsonObject.RootObject Settings { get; set; }
    }

    public partial class KeyObjects {
        public List<KeyObject> Keys { get; set; }
    }

    [DataContract]
    public partial class KeyObject {
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
        public KeyScript Script { get; set; }
    }

    [DataContract]
    public partial class KeyScript {
        [DataMember(Name = "s")]
        public List<Object.RuntimeScript> Scripts { get; set; }
    }
}