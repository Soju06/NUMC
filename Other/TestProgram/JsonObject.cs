using System;
using System.Collections;
using System.Collections.Generic;
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
        public class RootObject : Dictionary<string, Keys>
        {

        }

        public class Keys : Dictionary<string, Key>
        {

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

        }

        [DataContract]
        public struct Value
        {
            [DataMember(Name = "Value")]
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
