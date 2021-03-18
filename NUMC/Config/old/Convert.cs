using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Config.old
{
    public static class Convert
    {
        public static Config ConvertObject(string version, string json)
        {
            var v = new Client.Version(2, 0, 0, Client.VersionType.alpha, 0);
            if(!string.IsNullOrWhiteSpace(version)) Client.Version.TryParse(version, out v);
            Debug.WriteLine($"Config version change: {v} => {Constant.Verison}");
            switch (v.ToString()) {
                case "2.0.0-alpha.0": { 
                        var o = Json.JsonSerializer.Convert<v200a1.ScriptObject>(json);
                        Object.KeyObjects keys = new Object.KeyObjects();
                        if(o?.Keys?.Keys != null) {
                            foreach (var item in o.Keys.Keys) {
                                if (item == null) continue;
                                keys.Add(new Object.KeyObject() {
                                    Ignore = item.Ignore,
                                    Key = item.Key,
                                    Scripts = new Object.KeyScript(item.Script?.Scripts)
                                });
                            }
                        }
                        return ConvertObject("2.0.0-alpha.1", Json.JsonSerializer.Convert(new v200a2.ScriptObject() {
                            Language = o.Language, Keys = keys, Settings = o.Settings
                        }));
                    }
                case "2.0.0-alpha.1": {
                        var o = Json.JsonSerializer.Convert<v200a2.ScriptObject>(json);
                        var settings = new Json.JsonObject();

                        if(o.Settings != null) {
                            foreach (var item in o.Settings)
                                settings.Add(item.Key, ConvertKeys(item.Value));

                            Json.Keys ConvertKeys(v200a2.JsonObject.Keys keys) {
                                var ks = new Json.Keys();
                                foreach (var item in keys)
                                    ks.Add(item.Key, ConvertKey(item.Value));
                                return ks;
                            }

                            Json.Key ConvertKey(v200a2.JsonObject.Key key) => new Json.Key {
                                SubKeys = ConvertKeys(key.SubKeys),
                                Values = ConvertValues(key.Values)
                            };

                            Json.Values ConvertValues(v200a2.JsonObject.Values values) {
                                var vs = new Json.Values();
                                foreach (var item in values)
                                    vs.Add(item.Key, new Json.Value(item.Value?.Data));
                                return vs;
                            }
                        }

                        
                        return ConvertObject("2.0.0-alpha.2", Json.JsonSerializer.Convert(new v200a3.ScriptObject() {
                            Language = o.Language,
                            Keys = o.Keys,
                            Settings = settings
                        }));
                    }
                case "2.0.0-alpha.2": {
                        var o = Json.JsonSerializer.Convert<v200a3.ScriptObject>(json);

                        return new Config() {
                            Keys = o.Keys,
                            Configs = o.Settings,
                            Language = o.Language
                        };
                    }
                default:
                    return Json.JsonSerializer.Convert<Config>(json);
            }
        }
    }
}
