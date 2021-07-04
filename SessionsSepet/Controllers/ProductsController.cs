using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        MyDbContext db;
        public ProductsController()
        {
            db = new MyDbContext();
        }

        public ActionResult Index(int? KategoriID, string KategoriAdi)
        {
            if (!KategoriID.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            // Qyery stringi yakalama
            //int id = int.Parse(Request.QueryString["KategoriID"]);
            //string kategoriAdi = Request.QueryString["KategoriAdi"];

            Kategori kat = db.Category.FirstOrDefault(c => c.Adi == KategoriAdi);

            var result = db.Product.Where(c => c.KategoriID ==KategoriID).ToList();
            return View(result);
        }

        public ActionResult Detail(int? ProductID,string ProductName)
        {

            if (!ProductID.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            // Kullanıcının gezdiği ürünlerin idsini kukide saklayalım...

            List<string> Ids = new List<string>();

            HttpCookie kuk;
            if (Request.Cookies["songezilenurunIds"] != null)
            {
                kuk = Request.Cookies["songezilenurunIds"];

                // stringi , e göre diziye çevir..
                Ids = kuk.Value.Split(',').ToList();
            }
            else
            {
                kuk = new HttpCookie("songezilenurunIds");
                kuk.Expires = DateTime.Now.AddDays(10);
            }


            // ürün daha önce bu diziye eklenmiş mi ?
            if (!Ids.Contains(ProductID.ToString()))
            {
                Ids.Add(ProductID.ToString());
            }

            // string arrayi , ile ayırarak stringe çevir...
            string newVal = String.Join(",", Ids);
            kuk.Value = newVal;


            Response.Cookies.Add(kuk);
            var result = db.Product.FirstOrDefault(c => c.ID == ProductID);
            return View(result);
        }

    }
}