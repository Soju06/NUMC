using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NUMC.Script
{
    public class ScriptObject
    {
        public KeyObject[] KeyObject { get; set; } = new KeyObject[] { };

        public Keys[] WVKeys { get; set; } = new Keys[]
        {
            Keys.NumLock,
            Keys.Divide,
            Keys.Multiply,
            Keys.Subtract,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Add,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.Return,
            Keys.NumPad0,
            Keys.Decimal
        };

        public string Language { get; set; } = "auto";

        new public string ToString()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return Json.BeautifierJson(serializer.Serialize(this));
        }

        public void SetScript(string keyObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ScriptObject script = (ScriptObject)serializer.Deserialize(keyObject, typeof(ScriptObject));

            KeyObject = script.KeyObject;
            WVKeys = script.WVKeys;
            Language = script.Language;
        }

        public KeyObject GetKeyObject(Keys key, bool readOnly)
        {
            if (KeyObject != null)
                for (int i = 0; i < KeyObject.Length; i++)
                {
                    if (KeyObject[i] != null && KeyObject[i].Key == key)
                        return KeyObject[i];
                }
            // 없으면 생성
            if (!readOnly)
            {
                List<KeyObject> keyObjects = KeyObject.ToList();
                KeyObject keyObject = new KeyObject
                {
                    Key = key
                };
                keyObjects.Add(keyObject);
                KeyObject = keyObjects.ToArray();
                return keyObject;
            }
            return null;
        }

        public void Clear(Keys[] keys)
        {
            List<KeyObject> keyObjects = new List<KeyObject>();

            for (int i = 0; i < keys.Length; i++)
            {
                KeyObject keyObject = new KeyObject
                {
                    Key = keys[i]
                };
                keyObjects.Add(keyObject);
            }

            KeyObject = keyObjects.ToArray();
        }

        public void Reset()
        {
            ScriptObject script = new ScriptObject();
            script.Clear(script.WVKeys);

            //Enter Disable
            KeyObject enterKey = script.GetKeyObject(Keys.Return, false);
            enterKey.Ignore = false;
            enterKey.KeyScript = null;

            //Num Lock
            KeyObject NumLock = script.GetKeyObject(Keys.NumLock, false);
            NumLock.Ignore = false;
            NumLock.KeyScript = null;

            SetScript(script.ToString());
        }
    }

    public class KeyObject
    {
        public KeyObject()
        {
        }

        public KeyObject(Keys key, bool ignore, KeyScript[] keyScript)
        {
            Key = key;
            Ignore = ignore;
            KeyScript = keyScript;
        }

        public Keys Key { get; set; }
        public bool Ignore { get; set; } = true;
        public KeyScript[] KeyScript { get; set; }
    }

    public class KeyScript
    {
        public KeyScript()
        {
        }

        public KeyScript(string type, SendKeys sendKeys, VirtualKey virtualKey)
        {
            Type = type;
            SendKeys = sendKeys;
            VirtualKey = virtualKey;
        }

        public string Type { get; set; }
        public SendKeys SendKeys { get; set; }
        public VirtualKey VirtualKey { get; set; }
        public Macro Macro { get; set; }
    }

    public class SendKeys
    {
        public SendKeys()
        {
        }

        public SendKeys(string[] text)
        {
            Text = text;
        }

        public string[] Text { get; set; }
    }

    public class VirtualKey
    {
        public VirtualKey()
        {
        }

        public VirtualKey(Keys[] keys)
        {
            Keys = keys;
        }

        public Keys[] Keys { get; set; }
    }
}