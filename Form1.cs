﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Languages;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = Program.lang.GetLang().Autorization.Autorizat;
            textBox1.Text = Program.lang.GetLang().Autorization.Login;
            textBox2.Text = Program.lang.GetLang().Autorization.Password;
            button1.Text = Program.lang.GetLang().Autorization.Voiti;
            linkLabel1.Text = Program.lang.GetLang().Autorization.Create;
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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.FormClosed += (Object, FormClosedEventArgs) => this.Show();
            frm.Show();
        }
    }
}