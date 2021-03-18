using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins.PluginManager {
    public partial class PluginManagerDialog : Design.Form {
        private Client.NUMC.PluginManager.Store _onlinePlugins = null;
        private int _oNode = -1;

        public PluginManagerDialog() {
            InitializeComponent();
            InitializeClassView();
        }

        private void InitializeClassView() {
            var installed = new Design.Controls.TreeNode(Language.Language._107, "installed");
            var online = new Design.Controls.TreeNode(Language.Language._108, "online");
            installed.Nodes.Add(new Design.Controls.TreeNode(Language.Language._109, "installed"));
            online.Nodes.Add(new Design.Controls.TreeNode(Language.Language._109, "online"));
            _classView.Nodes.Add(installed);
            _classView.Nodes.Add(online);
            _classView.SelectedNodesChanged += ClassView_NodesChanged;
        }

        private void ClassView_NodesChanged(object sender, EventArgs e) {
            if (_classView.SelectedNodes.Count <= 0)
                return;
            var item = _classView.SelectedNodes[0];
            for (int i = 0; i < _classView.Nodes.Count; i++) {
                if (_classView.Nodes[i] == item) { item.Expanded = true; break; }
            }
            var n = GetSelectedNode();
            if (n != -1) NodeChanged(n);
        }

        private int GetSelectedNode() {
            if (_classView.SelectedNodes.Count <= 0) return -1;
            var tag = _classView.SelectedNodes[0].Tag as string;
            return tag == "installed" ? 0 : tag == "online" ? 1 : -1;
        }

        private void NodeChanged(int node) {
            if (_oNode == node) return;
            _oNode = node;
            if (node == 1) SetOnline();
            else if (node == 0) SetInstalled();
        }

        private void SetInstalled() {
            _pluginsView.Items.Clear();
            SetLoading(true, Language.Language._110);
            _pluginsView.SuspendLayout();
            Task.Run(() => {
                var plugins = PluginManagerUtils.GetInstalledPlugins();
                Invoke(new MethodInvoker(delegate () {
                    for (int i = 0; i < plugins.Count; i++) {
                        var item = PluginManagerViewItem.PluginToPluginManagerViewItem(plugins[i]);
                        item.Installed = true;
                        _pluginsView.Items.Add(item);
                    }
                    SetLoading(false);
                    _pluginsView.ResumeLayout();
                }));
            });
        }

        private void SetOnline() {
            _pluginsView.Items.Clear();
            SetLoading(true, Language.Language._111);
            _pluginsView.SuspendLayout();
            Task.Run(async () => {
                if (_onlinePlugins == null)
                    _onlinePlugins = await GetPluginStoreItems();
                var items = PluginToPluginViewItem(_onlinePlugins?.Plugins);
                Invoke(new MethodInvoker(delegate () {
                    _pluginsView.Items.AddRange(items);
                    SetLoading(false);
                    _pluginsView.ResumeLayout();
                }));
            });
        }

        private void SetLoading(bool l, string text = null) {
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
            loadingPanel.Visible = l; _pluginsView.Enabled = _classView.Enabled = !l;
            if(text != null) loadingLabel.Text = text;
        }

        private async Task<Client.NUMC.PluginManager.Store> GetPluginStoreItems() {
            var r = await Client.NUMC.PluginManager.GetProxyStoreAsync();
            if (r == null) {
                MessageBox.Show("Failed to load plugin list",
                    ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            } else if (r.ResponseMessage.StatusCode != HttpStatusCode.OK) {
                MessageBox.Show($"Failed to load plugin list\n{r.ResponseMessage?.RequestMessage}",
                    ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            } return r.ResponseObject;
        }

        private List<PluginManagerViewItem> PluginToPluginViewItem(IList<Client.NUMC.PluginManager.Plugin> plugins) {
            var items = new List<PluginManagerViewItem>();
            if(plugins != null)
                for (int i = 0; i < plugins.Count; i++)
                    items.Add(PluginManagerViewItem.PluginToPluginManagerViewItem(plugins[i], true));
            return items;
        }

        private void PluginsView_ItemDoubleClick(PluginManagerViewItem item, MouseEventArgs e) =>
            InstallPluginItem(item);

        private void PluginsView_ItemButtonClick(PluginManagerViewItem item, MouseEventArgs e) =>
            InstallPluginItem(item);

        private void PluginManagerDialog_FormClosing(object sender, FormClosingEventArgs e) =>
            _pluginsView.Dispose();

        private void InstallPluginItem(PluginManagerViewItem item) {
            if (item == null || !(MessageBox.Show(item.Installed ? string.Format(Language.Language._112, item.Title) :
                string.Format(Language.Language._113, item.Title), "Plug-in Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) return;
            if(item.Installed) //uninstall
                Uninstall(item);
            else // install
                Install(item);
        }

        private void Install(PluginManagerViewItem item) {
            if (_onlinePlugins == null) return;
            SetLoading(true, Language.Language._114);
            Task.Run(install);
            void install() {
                try {
                    var src = PluginManagerUtils.GetArchiveURL(_onlinePlugins.Archive_URL, item.Name);
                    this?.Invoke(new MethodInvoker(delegate () {
                        SetLoading(true, string.Format(Language.Language._115, src));
                        loadingProgressBar.Style = ProgressBarStyle.Blocks;
                    }));
                    var client = new WebClient();
                    client.DownloadProgressChanged += Client_DownloadProgressChanged;
                    client.DownloadFileCompleted += Client_DownloadFileCompleted;
                    var path = Path.Combine(Plugin.Extract.PluginDirectory.FullName, Path.GetFileNameWithoutExtension(item.Name) + ".tmp");
                    if (File.Exists(path)) File.Delete(path);
                    else if (Directory.Exists(path)) Directory.Delete(path, true);
                    _tempFile = path;
                    Debug.WriteLine($"download plugin {src}");
                    client.DownloadFileTaskAsync(src, path);
                } catch (Exception ex) {
                    MessageBox.Show($"Download failed\n{ex}",
                        ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string _tempFile;

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            var t = false;
            try {
                if(!string.IsNullOrWhiteSpace(_tempFile) && File.Exists(_tempFile) && new FileInfo(_tempFile).Length > 0) {
                    Invoke(new MethodInvoker(delegate () {
                        SetLoading(true, Language.Language._116);
                    }));
                    var path = Path.Combine(Plugin.Extract.PluginDirectory.FullName, Path.GetFileNameWithoutExtension(_tempFile) + ".dll");
                    for (int i = 1; i < 10000; i++) {
                        if (!File.Exists(path = Path.Combine(Plugin.Extract.PluginDirectory.FullName, Path.GetFileNameWithoutExtension(_tempFile) + $" ({i}).dll")))
                            break;
                        Debug.WriteLine(File.Exists(path));
                    }
                    File.Move(_tempFile, path);
                    t = true;
                }
                Invoke(new MethodInvoker(delegate () {
                    SetLoading(true, Language.Language._117);
                }));
            } catch (Exception ex) {
                MessageBox.Show($"Finish failed\n{ex}",
                    ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try {
                if (File.Exists(_tempFile)) File.Delete(_tempFile);
                if (sender is WebClient r) r.Dispose();
                if (t) Application.Restart();
                Invoke(new MethodInvoker(delegate () {
                    SetLoading(false);
                }));
            } catch { 

            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            try {
                Invoke(new MethodInvoker(delegate () {
                    loadingProgressBar.Value = e.ProgressPercentage * 0.01d;
                }));
            } catch { 
            
            }
        }

        private void Uninstall(PluginManagerViewItem item) {
            if (_oNode != 0) {
                var a = PluginManagerUtils.IsInstalled(item.Hash);
                if (a == null) return;
                var f = new FileInfo(a.Location);
                var fn = Path.Combine(f.DirectoryName, Path.GetFileNameWithoutExtension(f.Name) + ".tmp");
                f.MoveTo(fn);
                Process.Start(Application.ExecutablePath, $"--removePlugin \"{Path.GetFileName(f.FullName)}\"");
                Application.Exit();
            }
        }

        private void PluginManagerDialog_Shown(object sender, EventArgs e) =>
            SetInstalled();
    }
}
