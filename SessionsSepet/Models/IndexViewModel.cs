using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{

    // index sayfası için bir model oluşturduk...

    // bu model view için oluşturuldu. veri tabanı ile ilgisi yok.... 
    public class IndexViewModel
    {
        public List<Urun> Yenilers { get; set; }

        public List<Urun> OneCikanlars { get; set; }

        public List<Urun> Vitrins { get; set; }

        public List<Urun> SonGezilenler { get; set; }
    }
}