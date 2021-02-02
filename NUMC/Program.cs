using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NUMC
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += Application_ApplicationExit;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var service = new Service();

            Application.Run(service?.GetMain());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Keyboard.KeyboardHook.HookEnd();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e?.Exception == null)
                return;

            Trace.WriteLine($"unhandled exception\t{e.Exception}");
        }

        public static void Start()
        {
            string[] args = Environment.GetCommandLineArgs();
            int MaxTryCount = 20;
#if !DEBUG
            bool PS = false;
#endif
            if (args != null && args.Length >= 1)
            {
                int CPP = -1;
                int removePlugin = -1;

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-CP" || args[i] == "-c")
                        CPP = i + 1;
                    else if (args[i] == "--removePlugin")
                        removePlugin = i + 1;
#if !DEBUG
                    else if (args[i] == "-PS" || args[i] == "-f")
                        PS = true;
#endif
                    else if (CPP == i) {
                        try {
                            int tc = 0;
                            while (tc++ <= MaxTryCount) {
                                try {
                                    File.Copy(Application.ExecutablePath, args[i], true);
                                    Process.Start(args[i], "-f");
                                    break;
                                } catch { }
                                Thread.Sleep(500);
                            }
                        }
                        catch { }
                        Environment.Exit(0);
                    } else if (removePlugin == i) {
                        var tc = 0;
                        var file = Path.Combine(Plugin.Extract.PluginDirectory.FullName, args[i]);
                        while (tc++ <= MaxTryCount) {
                            try {
                                if (File.Exists(file))
                                    File.Delete(file);
                                else if (Directory.Exists(file))
                                    Directory.Delete(file, true);
                                break;
                            } catch { }
                            Thread.Sleep(500);
                        }
                    }
                }
            }

#if !DEBUG
            if (!PS && Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                Environment.Exit(0);
#endif
        }
    }
}