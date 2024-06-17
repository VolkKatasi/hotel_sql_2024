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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class requests : Form
    {
        private readonly int m_nID;

        private void loadDate()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.Clear();
            }
            using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
            {
                connection.Open();
                SqliteCommand cmd = new SqliteCommand($"select id, msg, ans from req where f_id like {m_nID}", connection);
                using (var ex = cmd.ExecuteReader())
                {
                    while (ex.Read())
                    {
                        string[] row = { $"{ex.GetInt32(0)}", ex.GetString(1), ex.IsDBNull(2) ? "--- ожидает ответа ---" : ex.GetString(2) };
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }

        public requests(int ID)
        {
            m_nID = ID;
            InitializeComponent();
            loadDate();

            this.Text = Program.lang.GetLang().Requents.wtitle;
            dataGridView1.Columns[1].HeaderText = Program.lang.GetLang().Requents.req;
            dataGridView1.Columns[2].HeaderText = Program.lang.GetLang().Requents.ans;
            label1.Text = Program.lang.GetLang().Requents.create_req;
            button1.Text = Program.lang.GetLang().Requents.send;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
                {
                    connection.Open();
                    SqliteCommand cmd = new SqliteCommand($"INSERT INTO req (f_id, msg) Values (\"{m_nID}\", \"{textBox1.Text}\");", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запрос успешно отправлен. Ожидайте ответа.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDate();
                }
            } 
            else
            {
                MessageBox.Show("Пустое поле. Введите пожалуйста запрос", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
