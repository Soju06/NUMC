using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Script
{
    public class JsonObject
    {
        protected const char ao = '+';
        protected static bool Checkao(string v, out string o) => 
            (o = (v != null && v.Length > 1 && v[0] == ao) ? v.Substring(1) : null) != null;
        protected static string Removeao(string v) => v?.Replace(ao.ToString(), "");

        public class RootObject : Dictionary<string, Keys>
        {
            public new Keys this[string v] { 
                get {
                    if (TryGetValue(Removeao(v), out var r)) return r;
                    if (Checkao(v, out var f)) {
                        var l = new Keys(); Add(f, l); return l;
                    } else return null;
                }
                set => base[v] = value;
            }
        }

        public class Keys : Dictionary<string, Key>
        {
            public new Key this[string v] { 
                get {
                    if (TryGetValue(Removeao(v), out var r)) return r;
                    else if (Checkao(v, out var f)) {
                        var l = new Key(); Add(f, l); return l;
                    } else return null;
                }
                set => base[v] = value;
            }
        }

        public class Key
        {
            private Values _values = null;
            private Keys _keys = null;

            public Values Values { get { return _values ?? (_values = new Values()); } set => _values = value; }
            public Keys SubKeys { get => _keys ?? (_keys = new Keys()); set => _keys = value; }
        }

        public class Values : Dictionary<string, Value>
        {
            public new Value this[string v] {
                get {
                    if (TryGetValue(Removeao(v), out var r)) return r;
                    else if (Checkao(v, out var f)) {
                        var l = new Value(); Add(f, l); return l;
                    } else return null;
                }
                set { 
                    if (value != null) base[v] = value;
                }
            }
        }

        [DataContract]
        public class Value
        {
            [DataMember(Name = "v")]
            public string Data { get; set; }

            #region Get, Set

            public string GetString() => Data;
            public bool? GetBool() { if (bool.TryParse(Data, out var f)) return f; else return null; }
            //public bool? GetBool() => bool.TryParse(Data, out var f) ? f : null;
            public int? GetInt() { if (int.TryParse(Data, out var f)) return f; else return null; }
            //public int? GetInt() => int.TryParse(Data, out var f) ? f : null;
            public double? GetDouble() { if (double.TryParse(Data, out var f)) return f; else return null; }
            //public double? GetDouble() => double.TryParse(Data, out var f) ? f : null;

            public void SetString(string value) => Data = value;
            public void SetBool(bool value) => Data = value.ToString().ToLowerInvariant();
            public void SetInt(int value) => Data = value.ToString(null, CultureInfo.InvariantCulture);
            public void SetDouble(double value) => Data = value.ToString(null, CultureInfo.InvariantCulture);

            #endregion
        }
    }
}
