using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{
    public class DersController : Controller
    {

        // GET: Ders
        public ActionResult Index()
        {
            OgrenciIslemleri operation = new OgrenciIslemleri();
            operation.OgrenciListesi();

            return View(operation.OgrenciListesi());
        }



        // GÖnderilen parametreye Kategori döner...
        public ActionResult KategoriGetir(int KategoriID)
        {
            MyDbContext db = new MyDbContext();

            var kategori = db.Category.FirstOrDefault(c => c.ID == KategoriID);
            db.Category.Where(c => c.ID == 1).Include(c => c.Uruns);
            //db.Category.Include("Uruns")
            //db.Category.Include(c => c.Uruns);



            return View(kategori);
        }

    }
    public class Ogrenciler
    {
        public string Adi { get; set; }

        public string SoyAdi { get; set; }
    }

    public class OgrenciIslemleri
    {
        public List<Ogrenciler> OgrenciListesi()
        {
            List<Ogrenciler> ogrList = new List<Ogrenciler>();
            ogrList.Add(new Ogrenciler { Adi = "Kenan", SoyAdi = "Ekber" });
            ogrList.Add(new Ogrenciler { Adi = "Hülya", SoyAdi = "Batırsoy" });
            ogrList.Add(new Ogrenciler { Adi = "Esra", SoyAdi = "Orhan" });

            return ogrList;
        }
    }
}