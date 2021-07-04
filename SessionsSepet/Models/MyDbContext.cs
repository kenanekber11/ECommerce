using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SessionsSepet.Models
{
    //public class MyDbContext : DbContext

    // MyDBContenxt sınını IdentityDbContext'ten türettiğimizde Identity tabloları otomatik veritanımızda oluşur

    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext() : base(@"Server=DESKTOP-NBVV3LT;database=ECOMMERCE;uid=ekenan; pwd=kenan1234")
        {
            // ilgili varlığın ilişkisel verilerilerin getirmesi(yüklemesi) için 
            // this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Kategori> Category { get; set; }

        public DbSet<Urun> Product { get; set; }

        public DbSet<Siparis> Order { get; set; }

        public DbSet<SiparisDetay> OrderDetails { get; set; }

        //public DbSet<Kullanici> Users { get; set; }

        public DbSet<Kargo> Cargo { get; set; }

        public DbSet<UrunImages> ProductImages { get; set; }

        public DbSet<OzellikMaster> MasterProperties { get; set; }

        public DbSet<Ozellik> Properties { get; set; }

        public DbSet<UrunOzellik> ProductProperties { get; set; }

        public DbSet<Il> City { get; set; }

        public DbSet<Ilce> District { get; set; }

        public DbSet<Adres> Adress { get; set; }
    }
}