namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createAdressTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false),
                        AcikAdress = c.String(nullable: false),
                        IlID = c.Int(nullable: false),
                        IlceID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ils", t => t.IlID)
                .ForeignKey("dbo.Ilces", t => t.IlceID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.IlID)
                .Index(t => t.IlceID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Ils",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ilces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        IlID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ils", t => t.IlID, cascadeDelete: true)
                .Index(t => t.IlID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adres", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ilces", "IlID", "dbo.Ils");
            DropForeignKey("dbo.Adres", "IlceID", "dbo.Ilces");
            DropForeignKey("dbo.Adres", "IlID", "dbo.Ils");
            DropIndex("dbo.Ilces", new[] { "IlID" });
            DropIndex("dbo.Adres", new[] { "UserID" });
            DropIndex("dbo.Adres", new[] { "IlceID" });
            DropIndex("dbo.Adres", new[] { "IlID" });
            DropTable("dbo.Ilces");
            DropTable("dbo.Ils");
            DropTable("dbo.Adres");
        }
    }
}
