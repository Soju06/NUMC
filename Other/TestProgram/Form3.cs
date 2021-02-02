using NUMC.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgram
{
    public partial class Form3 : NUMC.Design.Form
    {
        private WebBrowser webBrowser1;
        public Form3()
        {
            InitializeComponent();
            //webBrowser1 = new WebBrowser();
            //webBrowser1.Navigate("http://numc-proxy.p-e.kr/");
            //webBrowser1.Visible = false;
            //Controls.Add(webBrowser1);
        }

        private void UserControl11_CloseButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("close");
        }

        private void UserControl11_MaximizeButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("max");
        }

        private void UserControl11_MinimizeButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("mini");
        }

        private void UserControl11_TitleBarDrag(object sender, EventArgs e)
        {
            WinUtils.FormUtils.DragWindow(Handle);
        }

        private void UserControl11_TitleBarClick(object sender, EventArgs e)
        {
            MessageBox.Show("sdf");
        }

        private void UserControl11_TitleBarMouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"{e.Location} {e.Button}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NUMC.Client.AsyncImage image = new NUMC.Client.AsyncImage("https://cdn.trinets.xyz/d/JiZnzdj~iN.png", asd);
        }

        private void asd(AsyncImage asyncImage)
        {
            MessageBox.Show("!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
