using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
        }

        public Lang data { get; set; }
        public Languages()
        {
            string test = "{ \"Autorization\": { \"Autorizat\": \"АВТОРИЗАЦИЯ\", \"Login\": \"логин\", \"Password\": \"пароль\" } }";
            data = JsonSerializer.Deserialize<Lang>(test);
        }
    }


}
