using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SessionsSepet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            name: "UrunDetay",
            url: "Urun/{ProductID}/{ProductName}/Detay",
            defaults: new { controller = "Products", action = "Detail", ProductName = UrlParameter.Optional }
   );
            routes.MapRoute(
            name: "Urun",
          //url: "{controller}/{action}/{KategoriID}", // http://localhost:52291/Products/Index/2
          url: "Kategori/{KategoriID}/{KategoriAdi}", // http://localhost:52291/Products/2
         defaults: new { controller = "Products", action = "Index", KategoriID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}