#if DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins._Debug
{
    public static class DebugLogger
    {
        static DebugLogger()
        {
            try {
                var stream = new FileStream(Path.Combine(Application.StartupPath,
                    Path.GetFileNameWithoutExtension(Application.ExecutablePath)
                    + "-live-logger.log"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read, 64);
                Trace.Listeners.Add(new TextWriterTraceListener(new StreamWriter(stream, Encoding.UTF8)));
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;

                Task.Run(async () => {
                    while (!token.IsCancellationRequested && stream != null) {
                        try {
                            stream.Flush();
                        } catch (Exception ex) {
                            Debug.Assert(true, "debug logger flush failed", ex.ToString());
                        }
                        await Task.Delay(2000);
                    }
                }, token);

                Application.ApplicationExit += a;
                void a(object sender, EventArgs e) {
                    try {
                        tokenSource?.Cancel();
                        stream.Flush();
                        stream.Close();
                    } catch { }
                };
            } catch (Exception ex) {
                Debug.Assert(true, "debug logger failed", ex.ToString());
            }
        }

        public static void Run() { }
    }
}

#endif