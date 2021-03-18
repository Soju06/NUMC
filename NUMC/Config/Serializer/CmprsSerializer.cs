using System;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace NUMC.Config.Serializer {
    /// <summary>
    /// 압축 구성 직렬화
    /// </summary>
    public class CmprsSerializer : IConfigSerializer {
        public void Serialize(Stream instream, Stream outstream) {
            Debug.WriteLine($"cmprs after: {instream.Length}");
            using var ds = new DeflateStream(outstream, CompressionMode.Compress);
            int size;
            var buffer = new byte[8192];
            while ((size = instream.Read(buffer, 0, buffer.Length)) > 0)
                ds.Write(buffer, 0, size);
            ds.Flush(); ds.Close();
            Debug.WriteLine($"cmprs before: {outstream.Length}");
        }

        public void Serialize(TextReader inreader, Stream outstream, Encoding encoding = null) {
            using var ds = new DeflateStream(outstream, CompressionMode.Compress);
            int size;
            var buffer = new char[4096];
            while ((size = inreader.Read(buffer, 0, buffer.Length)) > 0)
                ds.Write((encoding ?? Encoding.UTF8).GetBytes(buffer), 0, size);
            ds.Flush(); ds.Close();
            Debug.WriteLine($"cmprs before: {outstream.Length}");
        }

        public void Serialize(string instring, out byte[] outbytes, Encoding encoding = null) =>
            Serialize((encoding ?? Encoding.UTF8).GetBytes(instring), out outbytes);

        public void Serialize(byte[] inbytes, out byte[] outbytes) {
            using var outstream = new MemoryStream();
            using var ds = new DeflateStream(outstream, CompressionMode.Compress);
            ds.Write(inbytes, 0, inbytes.Length);
            ds.Flush(); ds.Close();
            outbytes = outstream.ToArray();
        }

        public void SerializeJsonObject(object @object, Stream outstream) {
            using var stream = new MemoryStream(
                Encoding.UTF8.GetBytes(Json.JsonSerializer.Convert(@object)));
            Serialize(stream, outstream);
        }

        public void SerializeJsonObject(object @object, out byte[] outbytes) =>
            Serialize(Encoding.UTF8.GetBytes(Json.JsonSerializer.Convert(@object)), out outbytes);

        public void Deserialize(Stream instream, Stream outstream) {
            using var ds = new DeflateStream(instream, CompressionMode.Decompress);
            ds.CopyTo(outstream);
        }

        public void Deserialize(byte[] inbytes, Stream outstream) {
            using var instream = new MemoryStream(inbytes);
            using var ds = new DeflateStream(instream, CompressionMode.Decompress);
            ds.CopyTo(outstream);
        }

        public void Deserialize(byte[] inbytes, out byte[] outbytes)
        {
            using var instream = new MemoryStream(inbytes);
            using var outstream = new MemoryStream();
            using var ds = new DeflateStream(instream, CompressionMode.Decompress);
            ds.CopyTo(outstream); ds.Close();
            outbytes = outstream.ToArray();
        }

        public void Dispose() {

        }

        public void DeserializeJsonObject<Object>(byte[] inbytes, out Object outobject) {
            Deserialize(inbytes, out var outbytes);
            outobject = Json.JsonSerializer.Convert<Object>(Encoding.UTF8.GetString(outbytes));
        }

        public void DeserializeJsonObject<Object>(Stream instream, out Object outobject) {
            using var outstream = new MemoryStream();
            Deserialize(instream, outstream);
            outobject = Json.JsonSerializer.Convert<Object>(
                Encoding.UTF8.GetString(outstream.ToArray()));
        }

        public void DeserializeJsonObject(byte[] inbytes, out object outobject, Type objectType) {
            Deserialize(inbytes, out var outbytes);
            outobject = Json.JsonSerializer.Convert(Encoding.UTF8.GetString(outbytes), objectType);
        }

        public void DeserializeJsonObject(Stream instream, out object outobject, Type objectType) {
            using var outstream = new MemoryStream();
            Deserialize(instream, outstream);
            outobject = Json.JsonSerializer.Convert(
                Encoding.UTF8.GetString(outstream.ToArray()), objectType);
        }
    }
}
