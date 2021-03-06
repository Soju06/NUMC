﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace NUMC.Config.old.v200a3
{
    [DataContract]
    public class ScriptObject {

        [DataMember(Name = "lng")]
        public string Language { get; set; }

        [DataMember(Name = "keys")]
        public Object.KeyObjects Keys { get; set; }

        [DataMember(Name = "settings")]
        public Json.JsonObject Settings { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }
    }

    //public class JsonObject
    //{
    //    protected const char ao = '+';
    //    protected static bool Checkao(string v, out string o) => 
    //        (o = (v != null && v.Length > 1 && v[0] == ao) ? v.Substring(1) : null) != null;
    //    protected static string Removeao(string v) => v?.Replace(ao.ToString(), "");

    //    public class RootObject : Dictionary<string, Keys>
    //    {
    //        public new Keys this[string v] { 
    //            get {
    //                if (TryGetValue(Removeao(v), out var r)) return r;
    //                if (Checkao(v, out var f)) {
    //                    var l = new Keys(); Add(f, l); return l;
    //                } else return null;
    //            }
    //            set => base[v] = value;
    //        }
    //    }

    //    public class Keys : Dictionary<string, Key>
    //    {
    //        public new Key this[string v] { 
    //            get {
    //                if (TryGetValue(Removeao(v), out var r)) return r;
    //                else if (Checkao(v, out var f)) {
    //                    var l = new Key(); Add(f, l); return l;
    //                } else return null;
    //            }
    //            set => base[v] = value;
    //        }
    //    }

    //    public class Key
    //    {
    //        private Values _values = null;
    //        private Keys _keys = null;

    //        public Values Values { get { return _values ?? (_values = new Values()); } set => _values = value; }
    //        public Keys SubKeys { get => _keys ?? (_keys = new Keys()); set => _keys = value; }
    //    }

    //    public class Values : Dictionary<string, Value>
    //    {
    //        public new Value this[string v] {
    //            get {
    //                if (TryGetValue(Removeao(v), out var r)) return r;
    //                else if (Checkao(v, out var f)) {
    //                    var l = new Value(); Add(f, l); return l;
    //                } else return null;
    //            }
    //            set { 
    //                if (value != null) base[v] = value;
    //            }
    //        }
    //    }

    //    [DataContract]
    //    public class Value
    //    {
    //        [DataMember(Name = "v")]
    //        public string Data { get; set; }

    //        #region Get, Set

    //        public string GetString() => Data;
    //        public bool? GetBool() { if (bool.TryParse(Data, out var f)) return f; else return null; }
    //        //public bool? GetBool() => bool.TryParse(Data, out var f) ? f : null;
    //        public int? GetInt() { if (int.TryParse(Data, out var f)) return f; else return null; }
    //        //public int? GetInt() => int.TryParse(Data, out var f) ? f : null;
    //        public double? GetDouble() { if (double.TryParse(Data, out var f)) return f; else return null; }
    //        //public double? GetDouble() => double.TryParse(Data, out var f) ? f : null;

    //        public void SetString(string value) => Data = value;
    //        public void SetBool(bool value) => Data = value.ToString().ToLowerInvariant();
    //        public void SetInt(int value) => Data = value.ToString(null, CultureInfo.InvariantCulture);
    //        public void SetDouble(double value) => Data = value.ToString(null, CultureInfo.InvariantCulture);

    //        #endregion
    //    }
    //}

    //public partial class KeyObjects : List<KeyObject> {

    //}


    //[DataContract]
    //public partial class KeyObject {
    //    [DataMember(Name = "k")]
    //    public Keys Key { get; set; }
    //    [DataMember(Name = "i")]
    //    public bool Ignore { get; set; }

    //    [DataMember(Name = "s")]
    //    public KeyScript Scripts { get; set; }
    //}

    //public partial class KeyScript : List<RuntimeScript> {
    //    public KeyScript(List<RuntimeScript> scripts) { if (scripts != null) AddRange(scripts); }
    //}

    //[DataContract]
    //public partial class RuntimeScript {
    //    [DataMember(Name = "r")]
    //    public string RuntimeName { get; set; }
    //    [DataMember(Name = "d")]
    //    public string Data { get; set; }
    //}
}