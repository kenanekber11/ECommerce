using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Kargo
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public List<Siparis> Siparis { get; set; }
    }
}