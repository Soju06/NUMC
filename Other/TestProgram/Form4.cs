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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            webBrowser1.DocumentText = "<html><head></head><body style=\"background-color:rgb(40,40,40);font-family:-apple-system,BlinkMacSyst" +
                "emFont,Segoe UI,Helvetica,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji;box-sizing:border-" +
                "box;\"></body><h1 style=\"padding:20px 0px;text-align:center;background-color:#444444;\">Time Out!</h1></html>";
        }
    }
}
