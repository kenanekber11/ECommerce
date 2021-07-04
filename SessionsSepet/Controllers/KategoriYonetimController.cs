using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{
    public class KategoriYonetimController : Controller
    {
        // GET: KategoriYonetim

        MyDbContext context;
        public KategoriYonetimController()
        {
            context = new MyDbContext();
        }


        // bütün kategorilerin listelendiği yer...
        public ActionResult Index()
        {
            // MVC Areas yapısı
            return View(context.Category.ToList());
        }


        [HttpGet]
        public ActionResult AddOrUpdate(int ID)
        {
            // Fİnd ve FirstOrDefault ve SingleOrDefault ve Singe ve First metotlarını araştırınız....

            return View(context.Category.Find(ID));
        }

        // seçilen kategorinin güncellendiği veya yeni bir kategorinin eklendiği yer...

        [HttpPost]
        public ActionResult AddOrUpdate(Kategori model)
        {

            //Kategori kat = context.Category.Find(kategori.ID);
            Kategori kat = context.Category.FirstOrDefault(c => c.ID == model.ID);

            if (kat == null)
            {
                kat = new Kategori();
            }

            kat.Adi = model.Adi;

            if (kat.ID == 0)
            {
                context.Category.Add(kat);
            }

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}