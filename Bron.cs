using Microsoft.Data.Sqlite;
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
            tabControl1.TabPages[0].Text = Program.lang.GetLang().Bron.label2;
            tabControl1.TabPages[1].Text = Program.lang.GetLang().Bron.label4;
            tabControl1.TabPages[2].Text = Program.lang.GetLang().Bron.label5;
        }

        private readonly int m_nID;
        private bool closing = true;

        public Bron(int ID)
        {
            m_nID = ID;
            InitializeComponent();
            langInit();

            loadTaxiDate();

            FormClosed += (Object, FormClosedEventArgs) => { if (closing) Application.Exit(); };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Settings settings = new Settings();
            this.Hide();
            settings.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
            settings.Show();
        }

        private void Bron_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            closing = false;
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Notifications form4 = new Notifications();
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
            form4.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            requests form4 = new requests(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
            form4.Show();
        }

        private void loadTaxiDate()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.Clear();
            }
            using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
            {
                connection.Open();
                SqliteCommand cmd = new SqliteCommand($"select mesto, date from taxi where f_id like {m_nID}", connection);
                using (var ex = cmd.ExecuteReader())
                {
                    while (ex.Read())
                    {
                        string[] row = { ex.GetString(0), ex.GetString(1) };
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
                {
                    connection.Open();
                    SqliteCommand cmd = new SqliteCommand($"INSERT INTO taxi (f_id, mesto, date) Values (\"{m_nID}\", \"{textBox1.Text}\", \"{dateTaxi.Text}\");", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Такси приедет в назначенное место и довезёт вас до отеля!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTaxiDate();
                }
            }
            else
            {
                MessageBox.Show("Введите куда надо будет подъехать такси", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
