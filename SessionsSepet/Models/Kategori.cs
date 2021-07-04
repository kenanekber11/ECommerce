using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Kategori
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Adını alanını boş geçme...")] // DB'de not null, UI'da (html'de) zorunlu...
        [StringLength(100, ErrorMessage = "Maximum 100 karakter girilebilir...")]// Karakter sayısı (DB'de nvarchar(100), UI'da maximum 100 karakter....
        public string Adi { get; set; }

        public string Aciklama { get; set; }

        public virtual List<Urun> Uruns { get; set; }
    }


}