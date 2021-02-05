#if DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
                    + "-live-logger.log"), FileMode.Create);
                Trace.Listeners.Add(new TextWriterTraceListener(new StreamWriter(stream, Encoding.UTF8)));

                Task.Run(async () => {
                    while (true) {
                        try {
                            stream.Flush();
                        } catch (Exception ex) {
                            Debug.Assert(true, "debug logger flush failed", ex.ToString());
                        }
                        await Task.Delay(2000);
                    }
                });

                Application.ApplicationExit += a;
                void a(object sender, EventArgs e) {
                    try {
                        stream.Flush();
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