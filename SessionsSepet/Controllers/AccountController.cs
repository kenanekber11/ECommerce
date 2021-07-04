using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SessionsSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsSepet.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        // Profil...
        public ActionResult Index()
        {
            // giriş yapan kullanıcının diğer bilgilerine erişme..


            MyDbContext db = new MyDbContext();

            var loginUser = db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);


            // Veya 

            UserStore<AppUser> userStore = new UserStore<AppUser>(db);
            UserManager<AppUser> appUser = new UserManager<AppUser>(userStore);
            AppUser app = appUser.FindByName(User.Identity.Name);

            return View();
        }


        [AllowAnonymous]
        public ActionResult RegisterAndLogin(string ReturnUrl)
        {
            // ReturnUrl verisini buran view'a taşıyoruz..
            ViewBag.ReturnUrl = ReturnUrl;
            /*ViewData["ReturnUrl"] = ReturnUrl*/


            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterAndLogin(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                MyDbContext dbContext = new MyDbContext();

                UserStore<AppUser> dbStore = new UserStore<AppUser>(dbContext);

                UserManager<AppUser> userManager = new UserManager<AppUser>(dbStore);

                AppUser user = new AppUser();
                user.UserName = vm.KullaniciAdi;
                user.Email = vm.Email;
                user.Adi = vm.Ad;
                user.SoyAdi = vm.SoyAd;

                IdentityResult result = userManager.Create(user, vm.Sifre);


                RoleStore<AppRole> roleStore = new RoleStore<AppRole>(dbContext);

                RoleManager<AppRole> roles = new RoleManager<AppRole>(roleStore);

                if (!roles.RoleExists("Uye")) // üye rolü var mı?
                {
                    AppRole role = new AppRole();
                    role.Name = "Uye";

                    roles.Create(role);
                }

                if (!roles.RoleExists("Admin")) // üye rolü var mı?
                {
                    AppRole role = new AppRole();
                    role.Name = "Admin";

                    roles.Create(role);
                }

                userManager.AddToRole(user.Id, "Uye"); // kullanıcıya role ata...

                if (result.Succeeded)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }

            return Json(false);
        }

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl, string userName, string password)
        {
            MyDbContext dbContext = new MyDbContext();

            UserStore<AppUser> userStore = new UserStore<AppUser>(dbContext);
            UserManager<AppUser> userManager = new UserManager<AppUser>(userStore);

            AppUser appUser = userManager.Find(userName, password);

            if (appUser == null)
            {
                return RedirectToAction("RegisterAndLogin", "Account");
            }
            else
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                var calims = userManager.CreateIdentity(appUser, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(calims);

                if (ReturnUrl != "" || ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);

                    //return RedirectToAction(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }


        [AllowAnonymous]
        public ActionResult LogOff()
        {

            if (User.Identity.IsAuthenticated)
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut();
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult AddAddress()
        {


            MyDbContext db = new MyDbContext();
            var result = new SelectList(db.City.ToList(), "Id", "Adi");
            ViewBag.Cities = result;

            return View();
        }

        public JsonResult GetDistricts(int CityID)
        {
            MyDbContext db = new MyDbContext();

            // yöntem2
            //db.Configuration.ProxyCreationEnabled = false;
            //var result = db.District.Where(c => c.IlID == CityID).ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);

            // yöntem 1
            var result1 = db.District.Where(c => c.IlID == CityID).Select(c => new
            {
                c.Adi,
                c.ID
            }).ToList();
            return Json(result1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAddress(Adres vm)
        {

            MyDbContext db = new MyDbContext();

            db.Adress.Add(vm);
        
            try
            {
                vm.UserID = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index", "Shop");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }
    }
}