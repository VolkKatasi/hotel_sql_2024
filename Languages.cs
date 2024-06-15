using System;
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
        }

        public class Autorization
        {
            public string Autorizat { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Voiti { get; set; }
            public string Create { get; set; }
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
