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

            // Taxi
            dataGridView1.Columns[0].HeaderText = Program.lang.GetLang().Taxi.deep;
            dataGridView1.Columns[1].HeaderText = Program.lang.GetLang().Taxi.date;
            label2.Text = Program.lang.GetLang().Taxi.deep_r;
            label1.Text = Program.lang.GetLang().Taxi.time_deep;
            button1.Text = Program.lang.GetLang().Taxi.booking;
        }

        private readonly int m_nID;
        private bool closing = true;

        public Bron(int ID)
        {
            m_nID = ID;
            InitializeComponent();
            langInit();

            loadTaxiDate();
            loadBronDate();

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

        private void loadBronDate()
        {
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
            }
            using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
            {
                connection.Open();
                Tuple<string, string>[] dict = {
                    new Tuple<string, string>("eko", "Первый этаж, эконом"),
                    new Tuple<string, string>("stad", "Первый этаж, стандарт"),
                    new Tuple<string, string>("komf", "Второй этаж, комфорт"),
                    new Tuple<string, string>("prem", "Второй этаж, премиум"),
                    new Tuple<string, string>("lux", "Третий этаж, люкс"),
                };
                foreach (var row in dict)
                {
                    SqliteCommand cmd = new SqliteCommand($"select n, count from {row.Item1} where f_id=\"{m_nID}\" and busy=\"1\"", connection);
                    using (var ex = cmd.ExecuteReader())
                    {
                        while (ex.Read())
                        {
                            string[] rw = { $"{row.Item2}. Номер: {ex.GetString(0)}", $"{ex.GetInt32(1)}" };
                            dataGridView2.Rows.Add(rw);
                        }
                    }
                }
            }
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
                    MessageBox.Show(Program.lang.GetLang().Taxi.msg_success, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTaxiDate();
                }
            }
            else
            {
                MessageBox.Show(Program.lang.GetLang().Taxi.msg_empty, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new infoEko(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); loadBronDate(); };
            form4.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new infoStandart(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); loadBronDate(); };
            form4.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new infoKomfo(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); loadBronDate(); };
            form4.Show();
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new infoPrem(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); loadBronDate(); };
            form4.Show();
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new infoLux(m_nID);
            this.Hide();
            form4.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); loadBronDate(); };
            form4.Show();
        }
    }
}
