namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrunOzelliks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        OzellikID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ozelliks", t => t.OzellikID, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.OzellikID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Ozelliks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        OzellikMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OzellikMasters", t => t.OzellikMasterID, cascadeDelete: true)
                .Index(t => t.OzellikMasterID);
            
            CreateTable(
                "dbo.OzellikMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrunOzelliks", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.UrunOzelliks", "OzellikID", "dbo.Ozelliks");
            DropForeignKey("dbo.Ozelliks", "OzellikMasterID", "dbo.OzellikMasters");
            DropIndex("dbo.Ozelliks", new[] { "OzellikMasterID" });
            DropIndex("dbo.UrunOzelliks", new[] { "UrunID" });
            DropIndex("dbo.UrunOzelliks", new[] { "OzellikID" });
            DropTable("dbo.OzellikMasters");
            DropTable("dbo.Ozelliks");
            DropTable("dbo.UrunOzelliks");
        }
    }
}
