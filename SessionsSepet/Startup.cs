using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

[assembly: OwinStartup(typeof(SessionsSepet.Startup))]

namespace SessionsSepet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/RegisterAndLogin"),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
