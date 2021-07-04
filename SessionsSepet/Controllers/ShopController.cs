using Microsoft.AspNet.Identity;
using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SessionsSepet.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("RegisterAndLogin", "Account");
            //}


            MyDbContext db = new MyDbContext();

            ViewBag.Kargos = db.Cargo.ToList();

            string userID = User.Identity.GetUserId();
            var AdresList = db.Adress.Where(c => c.UserID == userID).ToList();

            return View(AdresList);
        }

        public ActionResult CreateOrder(int? teslimatAdres, int? faturaAdres, int cargo)
        {

            return View();
        }
    }
}