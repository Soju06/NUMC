using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NUMC.Expansion;

namespace TestProgram
{
    public partial class Form2 : NUMC.Design.Form
    {
        public Form2()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            webBrowser1.Visible = false;

            NUMC.Keyboard.KeyboardHook.HookStart();
            //webBrowser1.ScrollBarsEnabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Asd();
        }

        private async void Asd()
        {
            var rs = await NUMC.Client.Update.GetLatestReleaseAsync();

            if (rs?.Object == null)
                Debug.WriteLine("rs is null");
            webBrowser1.SuspendLayout();
            f = rs.Object.HtmlUrl;
            webBrowser1.Navigate(f);
        }

        private string f;

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != f)
                return;

            webBrowser1.DocumentText = ToMarkdownDocument(GetMarkdownBody(webBrowser1.Document), GetFrameworksColorModeStylesheet(webBrowser1.Document), 
                _styles.Control.BackgroundColor, _styles.Control.Color);

            webBrowser1.Visible = true;
            webBrowser1.ResumeLayout();
        }

        private string GetMarkdownBody(HtmlDocument document)
        {
            var es = document.GetElementsByTagName("div");
            var sb = new StringBuilder();

            for (int i = 0; i < es.Count; i++)
                if (es[i].GetAttribute("className").Trim() == "markdown-body")
                    sb.Append(es[i].OuterHtml);

            return sb.ToString();
        }

        private string GetFrameworksColorModeStylesheet(HtmlDocument document)
        {
            var stylesheet = "https://github.githubassets.com/assets/frameworks-color-modes-669e418b5003d4ac3d2fd7ec0654ea55.css";
            var ls = document.GetElementsByTagName("link");

            for (int i = 0; i < ls.Count; i++)
            {
                var f = ls[i].GetAttribute("href");

                if (f.Contains("frameworks-color-modes"))
                {
                    stylesheet = f;
                    Debug.WriteLine(stylesheet);
                    break;
                }
            }

            return stylesheet;
        }

        private string ToMarkdownDocument(string markdownHtml, string stylesheet, Color backgroundColor, Color color) => 
            "<html><head><meta charset=\"utf-8\"><link rel=\"stylesheet\" href=\"" + stylesheet.ToString() + "\"><style>body" +
            "{overflow:auto;background-color:rgb(" + ToRGB(backgroundColor) + ");color:rgb(" + ToRGB(color) + ");margin:25px" +
            "}.markdown-body{margin-bottom:50px;}</style></head><body>" + markdownHtml + "</body></html>";

        private string ToRGB(Color color) => $"{color.R}, {color.G}, {color.B}";

        private void 
            Button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Dispose(true);
            GC.Collect();
        }
    }
    public class WebBrowserD : WebBrowser
    {
        public new void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }


    public class CustomTextBox : TextBox
    {

        public CustomTextBox()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x85) //WM_NCPAINT
            {
                IntPtr wDC = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(wDC))
                {

                }
                return;
            }
            base.WndProc(ref m);
        }
    }
}
