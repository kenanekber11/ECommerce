using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Maximum 50 Karakter")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "SoyAd zorunludur")]
        [StringLength(50, ErrorMessage = "Maximum 50 Karakter")]
        public string SoyAd { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı zorunludur")]
        [StringLength(50, ErrorMessage = "Maximum 50 Karakter")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [StringLength(50, ErrorMessage = "Maximum 50 Karakter")]
        [EmailAddress(ErrorMessage = "Lütfen email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifre zorunludur")]
        [StringLength(10, ErrorMessage = "Maximum 50 Karakter")]

        public string Sifre { get; set; }

        [Required(ErrorMessage = "Sifre Tekrar zorunludur")]
        [StringLength(10, ErrorMessage = "Maximum 50 Karakter")]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor")]
        public string SifreTekrar { get; set; }


        //[Range(18,50)]
        //public int Yas { get; set; }
    }
}