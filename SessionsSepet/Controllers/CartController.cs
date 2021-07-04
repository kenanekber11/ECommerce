using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        public ActionResult Index()
        {
            List<SepetSepetYumurta> sepetes = new List<SepetSepetYumurta>();

            if (Session["sepet"] != null)
            {
                sepetes = (List<SepetSepetYumurta>)Session["sepet"];
            }

            return View(sepetes);
        }


        // sessiondan ürün siler...
        public ActionResult SepetOperation(int ProductID, int adet, string operation)
        {
            List<SepetSepetYumurta> sepetes = new List<SepetSepetYumurta>();
            if (Session["sepet"] != null)
            {
                sepetes = (List<SepetSepetYumurta>)Session["sepet"];
            }

            SepetSepetYumurta sep = sepetes.FirstOrDefault(c => c.Item.ID == ProductID);

            if (operation == "sil")
            {
                if (sep != null)
                {
                    sepetes.Remove(sep);
                }
            }
            else if (operation == "adetGuncelle")
            {
                sep.Adet = adet;
            }


            Session["sepet"] = sepetes;

            return PartialView("_SepetList", sepetes);
        }

        
    }
}