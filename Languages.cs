﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static WindowsFormsApp1.Languages;

namespace WindowsFormsApp1
{
    public class Languages
    {
        public class Lang
        {
            public Autorization Autorization { get; set; }
            public Registration Registations { get; set; }
            public Bron Bron { get; set; }
            public Notif Notifications {  get; set; }
            public Req Requents { get; set; }
            public Taxi Taxi { get; set; }
        }

        public class Registration
        {
            public string title { get; set; }
            public string pochta { get; set; }
            public string pass { get; set; }
            public string pass_two { get; set; }
            public string button { get; set; }
        }

        public class Autorization
        {
            public string Autorizat { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Voiti { get; set; }
            public string Create { get; set; }
        }
        public class Bron
        {
            public string title { get; set; }
            public string label2 { get; set; }
            public string label4 { get; set; }
            public string label5 { get; set; }
        }
        public class Notif
        {
            public string wtitle { get; set; }
            public string msg { get; set; }
            public string date { get; set; }
        }
        public class Req
        {
            public string wtitle { get; set; }
            public string req { get; set; }
            public string ans { get; set; }
            public string create_req { get; set; }
            public string send { get; set; }
        }
        public class Taxi
        {
            public string deep { get; set; }
            public string date { get; set; }
            public string deep_r { get; set; }
            public string time_deep { get; set; }
            public string booking { get; set; }
            public string msg_empty { get; set; }
            public string msg_success { get; set; }
        }
        
        public string curLang { get; set; } = "ru";
        public List<string> arrLang { get; set; } = new List<string>();
        private Dictionary<string, Lang> data { get; set; } = new Dictionary<string, Lang>();
        public Lang GetLang() { return this.data[curLang]; }

        public Languages()
        {
            var dir = new DirectoryInfo("Languages");
            foreach (var s in dir.GetFiles("*.json"))
            {
                string k = Path.GetFileNameWithoutExtension(s.FullName);
                arrLang.Add(k);
                using (FileStream file = new FileStream(s.FullName, FileMode.Open))
                {
                    data[k] = JsonSerializer.Deserialize<Lang>(file);
                }
            }
        }
    }


}
