using SessionsSepet.Models;
using System.Linq;
using System.Web.Mvc;

namespace SessionsSepet.Areas.Yonetim.Controllers
{
    public class CategoriManageController : Controller
    {
        // GET: KategoriYonetim

        MyDbContext context;
        public CategoriManageController()
        {
            context = new MyDbContext();
        }


        // bütün kategorilerin listelendiği yer...
        public ActionResult Index()
        {
            // MVC Areas yapısı
            return View(context.Category.ToList());
        }

        public ActionResult Save()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Save(Kategori model)
        {
            bool durum = ModelState.IsValid;
            ////Kategori kat = context.Category.Find(kategori.ID);
            //Kategori kat = context.Category.FirstOrDefault(c => c.ID == model.ID);

            //if (kat == null)
            //{
            //    kat = new Kategori();
            //}


            if (durum)
            {
                Kategori kat = new Kategori();
                kat.Adi = model.Adi;
                context.Category.Add(kat);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}