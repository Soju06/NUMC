using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgram
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Application_ApplicationExit;

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var asd = new asd() { fffffffffffffffffffff = "sasssssssssssssssss" };
            asd.Add(new dasd() { asd = "sans1" });
            asd.Add(new dasd() { asd = "sans2" });
            asd.Add(new dasd() { asd = "sans3" });
            asd.Add(new dasd() { asd = "sans4" });
            asd.Add(new dasd() { asd = "sans5" });
            asd.Add(new dasd() { asd = "sans6" });
            var rr = new asedf()
            {
                asd = asd   
            };
            Console.WriteLine(NUMC.Json.Json.Convert(rr));
            Console.Read();
            Console.WriteLine(NUMC.Json.Json.Convert(NUMC.Json.Json.Convert<asedf>(NUMC.Json.Json.Convert(rr))));

            //var r = NUMC.Setting.Json.Convert(new Test1());
            //Console.WriteLine(r);
            //var f = NUMC.Setting.Json.Convert<Test1>(r);
            //Console.WriteLine(NUMC.Setting.Json.Convert(f));

            //var l = Enum.GetValues(typeof(Keys));
            //var min = 1;
            //var max = 0;

            //for (int i = 0; i < l.Length; i++)
            //{
            //    var v = (int)((Keys)l.GetValue(i));
            //    if (min > v) min = v;
            //    if (max < v) max = v;
            //}

            //Console.WriteLine(min);
            //Console.WriteLine(max);

            //Console.WriteLine(Encoding.UTF8.GetString(NUMC.Setting.CmprsSerializer.Deserialize(Convert.FromBase64String(NUMC.Plugins.KeyboardLayouts.KeyboardLayoutResource.KeyBoard))));
            //Console.WriteLine(Convert.ToBase64String(NUMC.Setting.CmprsSerializer.Serialize(Encoding.UTF8.GetBytes(File.ReadAllText(@"D:\Users\soju_\Downloads\asdasdasdasdasd.txt")))));
            //var d = new NUMC.Plugins.KeyboardLayouts.Asdasdas();
            //var e = NUMC.Setting.CmprsSerializer.SerializeJsonObject(d.GAK());
            //Console.WriteLine(Convert.ToBase64String(e));
            //Console.WriteLine(e.Length);
            //var es = NUMC.Setting.CmprsSerializer.Serialize(Encoding.UTF8.GetBytes(Resource1.sad));
            //Console.WriteLine(Convert.ToBase64String(es));

            Console.Read();

            #region asd

            //new Form4().ShowDialog();

            //var t = Task.Run(async () =>
            //{
            //    var r = await NUMC.Client.Update.GetLatestReleaseAsync();
            //    await NUMC.Client.Update.DownloadDialogShow(r.Object);
            //});
            //t.Wait();
            //Console.Read();

            //var t = NUMC.Client.NUMC.PluginStore.GetProxyStoreAsync();
            //t.Wait();
            //var r = t.Result.ResponseObject;

            //Debug.WriteLine(r.Archive_URL);
            //foreach (var item in r.Plugins)
            //{
            //    Debug.WriteLine(item.Title);
            //    Debug.WriteLine(item.Overview);
            //    Debug.WriteLine(item.Image_URL);
            //    Debug.WriteLine(item.Publisher);
            //    Debug.WriteLine(item.Name);
            //    Debug.WriteLine(item.Size);
            //    Debug.WriteLine(item.Hash);
            //}
            //Console.Read();

            //var d = new Hash(Assembly.GetExecutingAssembly());
            //Debug.WriteLine(Convert.ToBase64String(d.MD5));
            //Console.ReadLine();
            //JsonObject.RootObject obj = new JsonObject.RootObject();

            //for (int i = 0; i < 5; i++)
            //{
            //    var k = new JsonObject.Keys();

            //    for (int l = 0; l < 3; l++)
            //    {
            //        var r = new JsonObject.Key();

            //        add(r, 1, $"root keys key #{l}");

            //        k.Add($"root keys key #{l}", r);
            //    }

            //    obj.Add($"root keys #{i}", k);
            //}

            //Console.WriteLine(NUMC.Setting.Json.Convert(obj));
            //Console.ReadLine();

            //void add(JsonObject.Key key, int r, string d)
            //{
            //    r -= 1;

            //    for (int h = 0; h < 5; h++)
            //    {
            //        var v = new JsonObject.Value();

            //        v.SetString(d + $" value #{h}");

            //        key.Values.Add(d + $" value #{h}", v);
            //    }

            //    if(r >= 0)
            //        for (int i = 0; i < 1; i++)
            //        {
            //            var k = new JsonObject.Key();

            //            add(k, r, d + $" subkeys key{i}");

            //            key.SubKeys.Add(d + $" subkeys key{i}", k);
            //        }
            //}

            // {/looooooooooooooooooooooooooooong string}

            //var s = "{/looooooooooooooooooooooooooooong string}";

            //Console.WriteLine(s.Length);

            //Console.ReadLine();
            //{
            //    long size = 0;
            //    object o = new object();
            //    using (Stream asdf = new MemoryStream())
            //    {
            //        BinaryFormatter formatter = new BinaryFormatter();
            //        formatter.Serialize(asdf, o);
            //        size = asdf.Length;
            //    }
            //    Console.WriteLine(size);
            //}

            //Console.ReadLine();

            //var sd = (CmprsString)s;

            //Console.WriteLine(Marshal.SizeOf(sd));

            //Console.ReadLine();

            //var ls = new List<NUMC.Script.JsonObject.Keys>();

            //Console.ReadLine();
            //for (int i = 0; i < 500000; i++)
            //{
            //    var d = new NUMC.Script.JsonObject.Keys();

            //    {
            //        var dgf = new Key();
            //        dgf.Values.Add("value1", new Value() { Data = "wa sans!" });
            //        dgf.Values.Add("value2", new Value() { Data = "wa sans! 2" });

            //        {
            //            var sad = new Key();

            //            sad.Values.Add("sub key value 1", new Value() { Data = "asdasdfasdfsdfg" });

            //            dgf.SubKeys.Add("subKey", sad);
            //        }

            //        d.Add("key1 #1", dgf);
            //    }

            //    var sadasd = new Key();

            //    sadasd.Values.Add("dfssdfdfs", new Value() { Data = "ppppppppppp" });

            //    d.Add("key1", sadasd);

            //    var asd = NUMC.Setting.Json.Convert(d);

            //    //Console.WriteLine(asd);

            //    var w = NUMC.Setting.Json.Convert<NUMC.Script.JsonObject.Keys>(asd);

            //    //Console.WriteLine(NUMC.Setting.Json.Convertt(w));

            //    ls.Add(w);
            //}

            //Console.ReadLine();
            //ls.Clear();
            //GC.Collect();
            //Console.ReadLine();

            //var f = new Value(1);

            //var d = NUMC.Setting.Json.Convert(f);

            //Console.WriteLine(d);

            //while (true)
            //{
            //    var d = Console.ReadLine();

            //    var f = NUMC.Setting.Json.BeautifierJson(d.Replace("\\n", "\n"));
            //    Console.WriteLine("========================");
            //    Console.WriteLine(f);
            //}

            //Console.WriteLine(NUMC.Setting.Json.Convert(new double[] { 1.1234324D, 2312312D, 123213D, 3D, 432.49244234D }));


            //Console.ReadLine();

            //var f = new NUMC.Script.Ini("[wa]\nsans=!");

            //foreach (var item in f)
            //{
            //    Console.WriteLine(item.Value["sans"].Value);
            //}


            //Console.Read();

            #endregion

            #region asfd

            NUMC.Keyboard.KeyboardHook.HookStart();

            //var sad = new WebClient();

            //sad.DownloadFile("https://github.com/Soju06/NUMC/releases/download/v1.1.0-beta.0/NUMC.zip", "za.zip");

            //Console.Read();

            //while (true)
            //{
            //    Console.Write("1: ");
            //    string e = Console.ReadLine();
            //    Console.Write("2: ");
            //    string f = Console.ReadLine();

            //    if (!NUMC.Client.Version.TryParse(e, out NUMC.Client.Version version) || !NUMC.Client.Version.TryParse(f, out NUMC.Client.Version version1))
            //        Console.WriteLine("failed");
            //    else
            //    {
            //        Console.WriteLine($"{version.ToString()} > {version1.ToString()}");
            //        Console.WriteLine(version > version1);
            //    }
            //}

            //var ad = NUMC.Client.Update.GetLatestRelease();
            //ad.Wait();

            //var sd = ad.Result;

            //Console.WriteLine();

            //var r = NUMC.Client.GitHub.Releases.GetReleases(NUMC.Client.GitHub.GitHub.NUMCRepositoriesName);
            //r.Wait();
            //var rm = r.Result.ResponseObject;

            ////var r = NUMC.Client.Update.GetRelease();
            ////r.Wait();

            ////Console.WriteLine(NUMC.Client.Update.Compare(r.Result));

            ////NUMC.Forms.Dialogs.ReleaseDownloader.ShowDownloader(rm[1], new NUMCUpdateHandler(rm[1]));
            //var d = NUMC.Client.Update.DownloadDialogShow(rm[1]);
            //d.Wait();

            //foreach (var item in rm)
            //{
            //    //Console.WriteLine("Name: {0}", item.Name);
            //    Console.WriteLine("TagName: {0}", item.Tag_name);
            //    //Console.WriteLine("Published_at: {0}", item.Published_at);
            //    //Console.WriteLine("Login: {0}", item.Author.Login);
            //    //Console.WriteLine("Body: {0}", item.Body);
            //}

            //Console.Read();

            //Thread.Sleep(1000);

            //    Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();

            //    for (int i = 0; i < 100000; i++)
            //    {
            //        var a = new ScriptInfo(Keys.Control, new Asdsa() { a = 123 });

            //        Console.WriteLine(a.Keys);
            //        Console.WriteLine(a.Object.a);

            //        a.Keys = Keys.Shift;
            //        a.Object.a = 456;

            //        Console.WriteLine(a.Keys);
            //        Console.WriteLine(a.Object.a);
            //    }

            //stopwatch.Stop();

            //Stopwatch stopwatch1 = new Stopwatch();

            //stopwatch1.Start();

            //for (int i = 0; i < 100000; i++)
            //{
            //    var a = new ScriptInfo1(Keys.Control, new Asdsa() { a = 123 });

            //    Console.WriteLine(a.Keys);
            //    Console.WriteLine(a.Object.a);

            //    a.Keys = Keys.Shift;
            //    a.Object.a = 456;

            //    Console.WriteLine(a.Keys);
            //    Console.WriteLine(a.Object.a);
            //}
            //stopwatch1.Stop();

            //Console.WriteLine("{1} {0}", stopwatch.ElapsedTicks, stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("{1} {0}", stopwatch1.ElapsedTicks, stopwatch1.ElapsedMilliseconds);
            //Console.Read();

            #endregion

            Application.Run(new Form3());
            Console.Read();
        }

        [DataContract]
        private class asedf
        {
            [DataMember(Name = "asd")]
            public asd asd { get; set; }
        }

        [DataContract]
        private class asd : List<dasd>
        {

            [DataMember(Name = "ffffffffffffffffffffffff")]
            public string fffffffffffffffffffff { get; set; }
        }

        [DataContract]
        private class dasd {
            [DataMember(Name = "asd")]
            public string asd { get; set; }
        }

        #region adsda

        //[DataContract]
        //public class Test1
        //{
        //    [DataMember(Name = "v")]
        //    public string V { get; set; } = "1.0.0.0";
        //    [DataMember(Name = "vd")]
        //    public Version Vd { get; set; } = new Version(1, 3, 4, 6);
        //}

        //public struct ScriptInfo
        //{
        //    public ScriptInfo(Keys keys, Asdsa keyObject) { Index = 0; Keys = keys; Object = keyObject; }

        //    public int Index;
        //    public Keys Keys;
        //    public Asdsa Object;
        //}

        //public class ScriptInfo1
        //{
        //    public ScriptInfo1(Keys keys, Asdsa keyObject) { Index = 0; Keys = keys; Object = keyObject; }

        //    public int Index;
        //    public Keys Keys;
        //    public Asdsa Object;
        //}

        //public class Asdsa
        //{
        //    public int a;
        //}

        #endregion


        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            NUMC.Keyboard.KeyboardHook.HookEnd();
        }
    }
}
