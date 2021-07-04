using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Ilce
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public int IlID { get; set; }

        public virtual Il Il { get; set; }

        public virtual List<Adres> Adress { get; set; }
    }
}