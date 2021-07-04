using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{
    using Models;
    using System.Data.Entity;

    public class HomeController : Controller
    {

        MyDbContext db;
        public HomeController()
        {
            db = new MyDbContext();
        }


        // GET: Home
        public ActionResult Index()
        {
            // eager loading => sadece belirtilen ilişkesel objeleri getir...
            // sorguya UrunImages sorgusunda dahil ediyorsun.. bu sayede product tablosundan bütün ilişkisel veriler değil include edilen veriler yüklenir...



            IndexViewModel vm = new IndexViewModel();

            var vitrinUruns = db.Product.Where(c => c.VitrindGorunsunmu == true)
                .Include(c => c.UrunImages)
                .ToList();

            var yeniEklenenler = db.Product.OrderByDescending(c => c.EklenmeTarihi)
                .Include(c => c.UrunImages)
                .ToList();

            var oneCikanlar = db.Product.Take(3).OrderByDescending(c => c.GoruntulenmeSayisi)
                .Include(c => c.UrunImages)
                .Include(c => c.Kategori)
                .ToList();

            vm.Vitrins = vitrinUruns;
            vm.Yenilers = yeniEklenenler;
            vm.OneCikanlars = oneCikanlar;


            HttpCookie kuk;
            List<string> Ids = new List<string>();
            if (Request.Cookies["songezilenurunIds"] != null)
            {
                kuk = Request.Cookies["songezilenurunIds"];
                // stringi , e göre diziye çevir..
                Ids = kuk.Value.Split(',').ToList();
            }

            List<int> newIds = new List<int>();
            for (int i = 0; i < Ids.Count; i++)
            {
                newIds.Add(Convert.ToInt32(Ids[i]));
            }

            // c nin ID'si Ids dizinde olanları liste olarak sonGezilenler listene ata...
            var sonGezilenler = db.Product.Where(c => newIds.Contains(c.ID)).ToList();
            vm.SonGezilenler = sonGezilenler;

            return View(vm);
        }


        public ActionResult GetCategories()
        {
            var result = db.Category.ToList();
            return PartialView("_KategoriList", result);
        }
        public ActionResult SepetInfo()
        {
            List<SepetSepetYumurta> sepetes = (List<SepetSepetYumurta>)Session["sepet"];
            if (sepetes == null) // session nullsa 
            {
                sepetes = new List<SepetSepetYumurta>(); // boş sepetes objesi oluştur
            }

            return PartialView("_SepetTop", sepetes);
        }

        public ActionResult SepetMiniInfo()
        {
            List<SepetSepetYumurta> sepetes = (List<SepetSepetYumurta>)Session["sepet"];
            if (sepetes == null) // session nullsa 
            {
                sepetes = new List<SepetSepetYumurta>(); // boş sepetes objesi oluştur
            }

            var adet = sepetes.Sum(c => c.Adet);
            return PartialView("_SepetMiniInfo", adet);
        }

        [HttpPost]
        public ActionResult SepeteEkle(int UrunID, int? Adet)
        {
            // sepet komutları

            List<SepetSepetYumurta> sepetes;
            if (Session["sepet"] != null) // session varsa sessiondan al
            {
                sepetes = (List<SepetSepetYumurta>)Session["sepet"];
            }
            else // session yoksa instance al...
            {
                sepetes = new List<SepetSepetYumurta>();
            }

            //List<int> sayilar = new List<int> { 1, 2, 3, 4, 5, 6, 7, 5 };
            //int arananSayi = sayilar.FirstOrDefault(c => c == 5);

            //List<string> isimler = new List<string> { "a","b","c"};
            //string arananIsim = isimler.FirstOrDefault(c => c == "d");


            // db'den ürünü bul...
            Urun urun = db.Product.FirstOrDefault(c => c.ID == UrunID);

            // ürün sepette var mı ????
            SepetSepetYumurta sepetUrun = sepetes.FirstOrDefault(c => c.Item.ID == UrunID);

            bool eklendiMi = true;
            if (sepetUrun != null) // ürün sepettedir
            {
                if (urun.Stok > sepetUrun.Adet)
                {
                    if (Adet.HasValue)
                    {
                        sepetUrun.Adet = (int)Adet;
                    }
                    else
                    {
                        sepetUrun.Adet++; // sepetteki ürünün adetini 1 arttır...k
                    }

                    eklendiMi = true;
                }
                else
                {
                    eklendiMi = false;
                }
            }
            else
            {
                sepetUrun = new SepetSepetYumurta();
                sepetUrun.Item = urun;

                if (Adet.HasValue)
                {
                    sepetUrun.Adet = (int)Adet;
                }
                else
                {
                    sepetUrun.Adet = 1;
                }

                sepetes.Add(sepetUrun);
            }

            Session["sepet"] = sepetes;

            // sepetes içerisinden Ürün Adeti ve Fiyatı anonim tip olarak çıkart..
            var obj = sepetes.Select(c => new
            {
                Eklendimi = eklendiMi,
                c.Adet,
                c.Item.Fiyat
            }
            ).ToList();

            // sepetes objesini geri dön..
            return Json(obj);
        }
    }
}