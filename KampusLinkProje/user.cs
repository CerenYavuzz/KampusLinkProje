using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KampusLinkProje;

namespace KampusLinkProje
{
    public class User
   {
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Fakulte { get; set; }

        public List<string> VerdigiDersler { get; set; } = new List<string>();
        public List<string> OgrendigiDersler { get; set; } = new List<string>();

        public int Puan { get; set; } = 100; // başlangıç puanı
    }
}
