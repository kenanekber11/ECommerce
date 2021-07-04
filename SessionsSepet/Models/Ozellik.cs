using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class Ozellik
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public int OzellikMasterID { get; set; }

        public virtual OzellikMaster OzellikMaster { get; set; }

        public virtual List<UrunOzellik> UrunOzelliks { get; set; }
    }
}