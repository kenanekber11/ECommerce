using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class UrunImages
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public int UrunID { get; set; }

        public virtual Urun Urun { get; set; }
    }
}