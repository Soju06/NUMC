using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    public struct CmprsString : IDisposable
    {
        private Stream _stream;

        public CmprsString(string data) { _stream = new MemoryStream(); SetValue(data); }

        public string String { get => GetValue(); set => SetValue(value); }

        public void SetValue(string data)
        {
            if (data == null)
            {
                _stream?.Close();
                return;
            }

            if (_stream == null || !_stream.CanRead) {
                _stream?.Close(); _stream = new MemoryStream();
            } else
                _stream.SetLength(0);

            var v = Encoding.UTF8.GetBytes(data);

            using(var ds = new DeflateStream(_stream, CompressionMode.Compress)) {
                ds.Write(v, 0, v.Length);
                ds.Flush();
            }
        }

        public string GetValue()
        {
            if (_stream == null || !_stream.CanRead) return null;

            _stream.Position = 0;

            using (MemoryStream output = new MemoryStream())
            using (DeflateStream ds = new DeflateStream(_stream, CompressionMode.Decompress)) {
                ds.CopyTo(output);
                return Encoding.UTF8.GetString(output.ToArray());
            }
        }

        public void Dispose()
        {
            _stream?.Close();
        }

        public static implicit operator string(CmprsString o) => o.GetValue();
        public static explicit operator CmprsString(string o) => new CmprsString(o);
    }
}
