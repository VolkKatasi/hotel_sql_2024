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
using static WindowsFormsApp1.Languages;
using Microsoft.Data.Sqlite;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private void langInit()
        {
            label1.Text = Program.lang.GetLang().Autorization.Autorizat;
            textBox1.Text = Program.lang.GetLang().Autorization.Login;
            textBox2.Text = Program.lang.GetLang().Autorization.Password;
            button1.Text = Program.lang.GetLang().Autorization.Voiti;
            linkLabel1.Text = Program.lang.GetLang().Autorization.Create;
            textBox2.PasswordChar = '\0';
        }
        public Form1()
        {
            InitializeComponent();
            langInit();
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
                textBox2.PasswordChar = '*';
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
            {
                connection.Open();
                SqliteCommand cmd = new SqliteCommand($"select Password, Id from Users where Login like \"{textBox1.Text}\";", connection);
                using (var ex = cmd.ExecuteReader())
                {
                    if (ex.HasRows && ex.GetString(0) == textBox2.Text)
                    {
                        this.Hide();
                        Bron bron = new Bron(ex.GetInt32(1));
                        bron.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
                        bron.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль или логин!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.FormClosed += (Object, FormClosedEventArgs) => { langInit(); this.Show(); };
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}