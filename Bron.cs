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
        private void langInit()
        {
            this.Text = Program.lang.GetLang().Bron.title;
            label1.Text = Program.lang.GetLang().Bron.label1;
            label2.Text = Program.lang.GetLang().Bron.label2;
            label3.Text = Program.lang.GetLang().Bron.label3;
            label4.Text = Program.lang.GetLang().Bron.label4;
            label5.Text = Program.lang.GetLang().Bron.label5;
        }

        public Bron()
        {
            InitializeComponent();
            langInit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Settings settings = new Settings();
            this.Hide();
            settings.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
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
