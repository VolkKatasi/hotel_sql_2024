﻿using Microsoft.Data.Sqlite;
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
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();

            this.Text = Program.lang.GetLang().Notifications.wtitle;
            dataGridView1.Columns[0].HeaderText = Program.lang.GetLang().Notifications.msg;
            dataGridView1.Columns[1].HeaderText = Program.lang.GetLang().Notifications.date;

            using (var connection = new SqliteConnection("Data Source=db/hotel.db"))
            {
                connection.Open();
                SqliteCommand cmd = new SqliteCommand($"select msg, date from notifi;", connection);
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
    }
   
}
