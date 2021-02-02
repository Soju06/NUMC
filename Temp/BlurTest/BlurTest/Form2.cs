using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlurTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public List<Form1> ttlist = new List<Form1>();
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 tt = new Form1();
           // ttlist.Add(tt);
            tt.Show();

            GC.KeepAlive(tt);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
