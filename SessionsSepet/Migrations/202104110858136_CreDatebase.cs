namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreDatebase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kargoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        KargoID = c.Int(nullable: false),
                        KullaniciID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kargoes", t => t.KargoID, cascadeDelete: true)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciID, cascadeDelete: true)
                .Index(t => t.KargoID)
                .Index(t => t.KullaniciID);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SiparisDetays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SiparisID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Siparis", t => t.SiparisID, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.SiparisID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stok = c.Int(nullable: false),
                        KategoriID = c.Int(nullable: false),
                        GoruntulenmeSayisi = c.Int(nullable: false),
                        VitrindGorunsunmu = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategoris", t => t.KategoriID, cascadeDelete: true)
                .Index(t => t.KategoriID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UrunImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        UrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.UrunID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrunImages", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.SiparisDetays", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.SiparisDetays", "SiparisID", "dbo.Siparis");
            DropForeignKey("dbo.Siparis", "KullaniciID", "dbo.Kullanicis");
            DropForeignKey("dbo.Siparis", "KargoID", "dbo.Kargoes");
            DropIndex("dbo.UrunImages", new[] { "UrunID" });
            DropIndex("dbo.Uruns", new[] { "KategoriID" });
            DropIndex("dbo.SiparisDetays", new[] { "UrunID" });
            DropIndex("dbo.SiparisDetays", new[] { "SiparisID" });
            DropIndex("dbo.Siparis", new[] { "KullaniciID" });
            DropIndex("dbo.Siparis", new[] { "KargoID" });
            DropTable("dbo.UrunImages");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.SiparisDetays");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.Siparis");
            DropTable("dbo.Kargoes");
        }
    }
}
