﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    public class AppUserRole : IdentityUserRole
    {
    }

    public class AppUser: IdentityUser
    {
        public string Adi { get; set; }

        public string SoyAdi { get; set; }
    }
}