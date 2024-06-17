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
    public partial class Bron : Form
    {
        public Bron()
        {
            InitializeComponent();
            label1.Text = Program.lang.GetLang().Bron.label1;
            this.Text = Program.lang.GetLang().Bron.title;
            label2.Text = Program.lang.GetLang().Bron.label2;
            this.Text = Program.lang.GetLang().Bron.title;
            label3.Text = Program.lang.GetLang().Bron.label3;
            this.Text = Program.lang.GetLang().Bron.title;
            label4.Text = Program.lang.GetLang().Bron.label4;
            this.Text = Program.lang.GetLang().Bron.title;
            label5.Text = Program.lang.GetLang().Bron.label5;
            this.Text = Program.lang.GetLang().Bron.title;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Settings settings = new Settings();
            settings.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bron_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
