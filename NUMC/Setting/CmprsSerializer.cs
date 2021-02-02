using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace NUMC.Setting
{
    public static class CmprsSerializer
    {
        public static byte[] SerializeJsonObject(object obj)
        {
            var json = Json.Convert(obj);
            Debug.WriteLine("json object compres serializing");
            return Serialize(Encoding.UTF8.GetBytes(json));
        }

        public static byte[] Serialize(byte[] bytes)
        {
            Debug.WriteLine($"cmprs after: {bytes.Length}");
            using (MemoryStream stream = new MemoryStream())
            using (DeflateStream ds = new DeflateStream(stream, CompressionMode.Compress))
            {
                ds.Write(bytes, 0, bytes.Length);
                ds.Flush();
                ds.Close();

                var a = stream.ToArray();

                stream.Close();

                Debug.WriteLine($"cmprs before: {a.Length}");

                return a;
            }
        }

        public static object DeserializeJsonObject(byte[] bytes, Type type) =>
            Json.Convert(Encoding.UTF8.GetString(Deserialize(bytes)), type);

        public static T DeserializeJsonObject<T>(byte[] bytes) => 
            Json.Convert<T>(Encoding.UTF8.GetString(Deserialize(bytes)));

        public static byte[] Deserialize(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            using (MemoryStream output = new MemoryStream())
            using (DeflateStream ds = new DeflateStream(stream, CompressionMode.Decompress))
            {
                ds.CopyTo(output);
                return output.ToArray();
            }
        }
    }
}
