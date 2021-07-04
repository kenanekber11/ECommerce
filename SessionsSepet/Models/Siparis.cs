using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Siparis
    {
        public int ID { get; set; }

        public DateTime Tarih { get; set; }

        public int KargoID { get; set; }

        public virtual Kargo Kargo { get; set; }

        //public int KullaniciID { get; set; }

        //public virtual Kullanici Kullanici { get; set; }

        public virtual List<SiparisDetay> SiparisDetay { get; set; }
    }
}