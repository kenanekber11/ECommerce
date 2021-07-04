using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Adres
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Adres Başlığı Giriniz")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Açık Adres Giriniz")]
        public string AcikAdress { get; set; }

        [Required(ErrorMessage = "İl Seçiniz")]
        public int IlID { get; set; }

        public virtual Il Il { get; set; }

        [Required(ErrorMessage = "İlçe Seçiniz")]
        public int IlceID { get; set; }

        public virtual Ilce Ilce { get; set; }

        public string UserID { get; set; }

        public virtual AppUser User { get; set; }
    }
}