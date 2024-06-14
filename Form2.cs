using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text != string.Empty)
            {
                textBox2.Text = string.Empty;
            }
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                textBox3.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
