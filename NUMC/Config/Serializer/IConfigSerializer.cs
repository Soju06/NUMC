using System;
using System.IO;
using System.Text;

namespace NUMC.Config.Serializer {
    /// <summary>
    /// 구성을 직렬화 시킵니다.
    /// </summary>
    public interface IConfigSerializer : IDisposable {
        public void Serialize(Stream instream, Stream outstream);
        public void Serialize(TextReader inreader, Stream outstream, Encoding encoding = null);
        public void Serialize(string instring, out byte[] outbytes, Encoding encoding = null);
        public void Serialize(byte[] inbytes, out byte[] outbytes);
        public void SerializeJsonObject(object @object, Stream outstream);
        public void SerializeJsonObject(object @object, out byte[] outbytes);
        public void Deserialize(Stream instream, Stream outstream);
        public void Deserialize(byte[] inbytes, Stream outstream);
        public void Deserialize(byte[] inbytes, out byte[] outbytes);
        public void DeserializeJsonObject<Object>(byte[] inbytes, out Object outobject);
        public void DeserializeJsonObject<Object>(Stream instream, out Object outobject);
        public void DeserializeJsonObject(byte[] inbytes, out object outobject, Type objectType);
        public void DeserializeJsonObject(Stream instream, out object outobject, Type objectType);
    }
}
