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
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);

            Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static void Start()
        {
            string[] args = Environment.GetCommandLineArgs();
            bool PS = false;

            if (args != null && args.Length >= 1)
            {
                int CPP = -1;

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-CP")
                        CPP = i;
                    else if (args[i] == "-PS")
                        PS = true;
                    else if (CPP != -1)
                    {
                        try
                        {
                            int MaxTryCount = 20, tc = 0;
                            while (tc++ <= MaxTryCount)
                            {
                                try
                                {
                                    File.Copy(Application.ExecutablePath, args[i]);
                                    Process.Start(args[i], "-PS");
                                    break;
                                }
                                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                                Thread.Sleep(1000);
                            }
                        }
                        catch { }

                        Environment.Exit(0);
                    }
                }
            }

            if (!PS && Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                IntPtr hWnd = WinUtils.WinAPI.FindWindow(null, Assembly.GetExecutingAssembly().GetName().Name);
                if (!hWnd.Equals(IntPtr.Zero))
                    WinUtils.WinAPI.ShowWindowAsync(hWnd, WinUtils.WinAPI.SW_SHOWNORMAL);
                WinUtils.WinAPI.SetForegroundWindow(hWnd);

                Environment.Exit(0);
            }
        }

        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";

            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            if (resources.Count() > 0)
            {
                string resourceName = resources.First();
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        byte[] assembly = new byte[stream.Length];
                        stream.Read(assembly, 0, assembly.Length);
                        return Assembly.Load(assembly);
                    }
                }
            }
            return null;
        }
    }
}