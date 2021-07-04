using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class SiparisDetay
    {
        public int ID { get; set; }

        public int SiparisID { get; set; }

        public virtual Siparis Siparis { get; set; }

        public int UrunID { get; set; }

        public virtual Urun Urun { get; set; }

        public int Adet { get; set; }

        public decimal Fiyat { get; set; }
    }
}