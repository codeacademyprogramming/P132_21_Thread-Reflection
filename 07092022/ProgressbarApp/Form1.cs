using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressbarApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(FillBar1);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(FillBar2);
            thread.Start();
        }

        private void FillBar1()
        {
            for (int i = 1; i <= 1000000000; i++)
            {
                progressBar1.Value = i / 10000000;
            }
        }

        private void FillBar2()
        {
            for (int i = 1; i <= 1000000000; i++)
            {
                progressBar2.Value = i / 10000000;
            }
        }
    }
}
