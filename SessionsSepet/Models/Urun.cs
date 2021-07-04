using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Urun
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public decimal Fiyat { get; set; }

        public int Stok { get; set; }

        public int KategoriID { get; set; }

        public int GoruntulenmeSayisi { get; set; }

        public bool VitrindGorunsunmu { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        public string Aciklama { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual List<SiparisDetay> SiparisDetay { get; set; }

        public virtual List<UrunImages> UrunImages { get; set; }

        public virtual List<UrunOzellik> UrunOzelliks { get; set; }
    }
}