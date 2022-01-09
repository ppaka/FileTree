using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Class1.Process(folderBrowserDialog1.SelectedPath, textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.ShowResult();
        }
    }
}
