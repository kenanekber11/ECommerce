using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class AppRole : IdentityRole
    {

    }

    public class AppUser : IdentityUser
    {
        public string Adi { get; set; }

        public string SoyAdi { get; set; }

        public virtual List<Adres> Address { get; set; }
    }

    public class AppUserRole : IdentityUserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }

    public class AppUserLogins : IdentityUserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}