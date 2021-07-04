using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Il
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public virtual List<Ilce> Ilces { get; set; }

        public virtual List<Adres> Adress { get; set; } 
    }
}