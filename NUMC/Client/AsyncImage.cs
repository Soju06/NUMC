using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Client
{
    public class AsyncImage : IDisposable
    {
        public event AsyncImageCompletedEventHandler AsyncImageCompleted;

        private Bitmap _image;
        private Exception _exception;
        private CancellationTokenSource _token;
        private Task _task;
        private bool _isCompleted;

        public AsyncImage() { }
        public AsyncImage(string url) { Start(url); }
        public AsyncImage(string url, AsyncImageCompletedEventHandler asyncImageCompleted) { Start(url); AsyncImageCompleted = asyncImageCompleted; }

        private void Initialize()
        {
            IsCompleted = false;
            IsCompletedSuccessfully = false;
            _image?.Dispose();
            _task?.Dispose();
            _token?.Dispose();
        }

        public void Start(string url)
        {
            if (_task != null && !_task.IsCompleted) Cancel();
            Initialize();
            ImageURL = url;
            _token = new CancellationTokenSource();
            _task = Task.Run(async () => { await StartAsync(url); }, _token.Token);
        }

        public void Cancel()
        {
            _token?.Cancel();
            _task?.Dispose();
            _token?.Dispose();
        }

        public bool Join()
        {
            if (IsCompleted) return IsCompletedSuccessfully;
            if(_task.Status == TaskStatus.Running) _task.Wait();
            return IsCompletedSuccessfully;
        }

        private async Task StartAsync(string url)
        {
            try {
                if(url.Length > 8 && url.Substring(0, 7) == "base64:") { 
                    using (var ms = new MemoryStream(Convert.FromBase64String(url.Substring(7))))
                        _image = (Bitmap)Image.FromStream(ms);
                } else {
                    var uri = new Uri(url);
                    if(uri.Scheme == "file") {
                        _image = new Bitmap(uri.LocalPath);
                    } else using (var wr = await WebRequest.Create(uri).GetResponseAsync()) 
                        using (var r = wr.GetResponseStream()) {
                            _token?.Token.ThrowIfCancellationRequested(); _image = new Bitmap(r);
                        }
                }
                IsCompletedSuccessfully = true;
            } catch (Exception ex) {
                _exception = ex;
            } IsCompleted = true;
        }

        public bool IsCompleted { get => _isCompleted; set {
                _isCompleted = value; AsyncImageCompleted?.Invoke(this); } }
        public bool IsCompletedSuccessfully { get; private set; }
        public string ImageURL { get; private set; }

        public Bitmap GetImage() => _image;
        public Exception GetException() => _exception;

        public void Dispose()
        {
            Cancel();
            _image?.Dispose();
            _task?.Dispose();
            _token?.Dispose();
        }
    }

    public delegate void AsyncImageCompletedEventHandler(AsyncImage asyncImage);
}
