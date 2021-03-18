using Microsoft.Win32;
using NUMC.Config.Serializer;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NUMC.Config {
    /// <summary>
    /// 설정 구성
    /// </summary>
    public partial class Config {
        /// <summary>
        /// 기본 구성 경로
        /// </summary>
        public static string DefaultConfigPath = Path.Combine(Application.StartupPath, 
            $"{Process.GetCurrentProcess().ProcessName}{Constant.Config.FileExtension}");

        public string ConfigPath { 
            get => _configPath; 
            set {
                try {
                    if (value.Contains(new(Path.GetInvalidPathChars()))) return;
                    if (File.Exists(value))
                        new FileStream(value, FileMode.Open, FileAccess.ReadWrite, 
                            FileShare.ReadWrite).Close();
                    else {
                        File.WriteAllBytes(value, new[] { (byte)0 });
                        File.Delete(value);
                    }
                    _configPath = value;
                } catch (Exception ex) {
                    Debug.WriteLine($"config path change failed!\n{ex}");
                }
            }
        }

        /// <summary>
        /// 구성 직렬화
        /// </summary>
        public IConfigSerializer ConfigSerializer { 
            get => _configSerializer ??= new CmprsSerializer();
            set => _configSerializer = value; 
        }

        private string _configPath = DefaultConfigPath;
        private IConfigSerializer _configSerializer;

        public Config() {
            Version = Constant.Verison;
        }

        private readonly object IOLock = new();

        /// <summary>
        /// 구성 저장
        /// </summary>
        public void Save() => Save(ConfigPath);

        /// <summary>
        /// 다른 이름으로 저장
        /// </summary>
        public void Save(string path) {
            lock (IOLock) {
                try {
                    Debug.WriteLine($"config save {path}");

                    ConfigSerializer.SerializeJsonObject(this, out var savefile);
                    File.WriteAllBytes(ConfigPath, savefile);
                    Saved?.Invoke(this, path);
                } catch (Exception ex) {
                    Debug.WriteLine($"config save fail\n{ex}");
                    var a = ex.Message;
                    if (a.Length > 200)
                        a = $"{a.Substring(0, 200)}\n...";
                    switch (MessageBox.Show($"{NUMC.Language.Language.Message_Error_Save_Setting_Fail}\n{a}",
                        Service.TitleName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)) {
                        case DialogResult.Retry:
                            Save(path);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 구성 불러오기
        /// </summary>
        public void Load() => Load(ConfigPath, false);

        /// <summary>
        /// 구성 불러오기
        /// </summary>
        /// <param name="path">경로</param>
        /// <param name="readOnly">구성을 생성하지 않음</param>
        public void Load(string path, bool readOnly = true) {
            try {
                if(!File.Exists(path) && !readOnly) Save(path);

                Debug.WriteLine($"config load {path}");
                ConfigSerializer.Deserialize(File.ReadAllBytes(path), out var configBytes);

                var configJson = Encoding.UTF8.GetString(configBytes);
                var config = Json.JsonSerializer.Convert<Config>(configJson);

                if (config != null && config.Version != Constant.Verison) {
                    try {
                        string bf = null;
                        for (int i = 0; i < 10000; i++)
                            if (!File.Exists(bf = (i == 0 ? path : 
                                $"{Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path))}.ns ({i})") + ".bak")) break;
                        File.Move(path, bf);
                    } catch (Exception ex) {
                        Debug.WriteLine($"config backup failed!\n{ex}");
                    } config = old.Convert.ConvertObject(config.Version, configJson);
                }

                if (config == null) config = new Config();
                Keys = config.Keys;
                Configs = config.Configs;
                Language = config.Language;

                _configPath = path;
                Loaded?.Invoke(this, path);
            } catch (Exception ex) {
                Debug.WriteLine($"Config load fail\n{ex}");

                var a = ex.Message;

                if (a.Length > 150)
                    a = $"{a.Substring(0, 150)}\n...";

                switch (MessageBox.Show($"{NUMC.Language.Language.Message_Error_Load_Setting_Fail}\n{a}",
                    Service.TitleName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)) {
                    case DialogResult.Retry:
                        Load(path);
                        break;

                    case DialogResult.Cancel:
                        switch (MessageBox.Show(NUMC.Language.Language.Message_Warning_Reset_Setting,
                            Service.TitleName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) {
                            case DialogResult.Yes:
                                Save(path);
                                break;
                        }
                        break;
                }
            }
        }

        public event Saved Saved;
        public event Loaded Loaded;
    }

    public delegate void Saved(Config config, string path);
    public delegate void Loaded(Config config, string path);
}