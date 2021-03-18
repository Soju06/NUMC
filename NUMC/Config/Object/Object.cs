using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace NUMC.Config.Object {
    /// <summary>
    /// 키 오브젝트 리스트
    /// </summary>
    public partial class KeyObjects : List<KeyObject> {
        public KeyObjects() { }
        public KeyObjects(params KeyObject[] objects) { if (objects != null) AddRange(objects); }
        public KeyObjects(List<KeyObject> objects) { if (objects != null) AddRange(objects); }
    }

    /// <summary>
    /// 키 오브젝트
    /// </summary>
    [DataContract]
    public partial class KeyObject {
        public KeyObject() { }
        public KeyObject(Keys keys) { Key = keys; }
        public KeyObject(Keys keys, bool ignore, KeyScript script) {
            Key = keys; Ignore = ignore;
            if(script != null) Scripts = script;
        }

        /// <summary>
        /// 키
        /// </summary>
        [DataMember(Name = "k")]
        public Keys Key { get; set; }
        /// <summary>
        /// 키 무시 여부
        /// </summary>
        [DataMember(Name = "i")]
        public bool Ignore { get; set; }

        /// <summary>
        /// 스크립트
        /// </summary>
        [DataMember(Name = "s")]
        public KeyScript Scripts {
            get => _script ?? (_script = new KeyScript());
            set => _script = value;
        }
    }

    /// <summary>
    /// 키 스크립트 리스트
    /// </summary>
    public partial class KeyScript : List<RuntimeScript> {
        public KeyScript() { }
        public KeyScript(params RuntimeScript[] scripts) { if (scripts != null) AddRange(scripts); }
        public KeyScript(List<RuntimeScript> scripts) { if (scripts != null) AddRange(scripts); }
    }

    /// <summary>
    /// 런타임 스크립트
    /// </summary>
    [DataContract]
    public partial class RuntimeScript {
        public RuntimeScript() { }
        public RuntimeScript(string runtimeName, string data) { RuntimeName = runtimeName; Data = data; }

        /// <summary>
        /// 런타임 스크립트 이름
        /// </summary>
        [DataMember(Name = "r")]
        public string RuntimeName { get; set; }
        /// <summary>
        /// 런타임스크립트 데이터
        /// </summary>
        [DataMember(Name = "d")]
        public string Data { get; set; }
    }
}