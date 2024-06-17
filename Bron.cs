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

            tabControl1.TabPages[0].Text = Program.lang.GetLang().Bron.label2;
            tabControl1.TabPages[1].Text = Program.lang.GetLang().Bron.label3;
            tabControl1.TabPages[2].Text = Program.lang.GetLang().Bron.label4;
            tabControl1.TabPages[3].Text = Program.lang.GetLang().Bron.label5;
        }

        private readonly int m_nID;
        public Bron(int ID)
        {
            m_nID = ID;
            InitializeComponent();
            langInit();

            //tabControl1.TabPages[2].
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

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
            form4.Show();
        }
    }
}
