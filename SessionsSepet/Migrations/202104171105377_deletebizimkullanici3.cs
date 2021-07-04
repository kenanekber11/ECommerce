namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletebizimkullanici3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Siparis", "KullaniciID", "dbo.Kullanicis");
            DropIndex("dbo.Siparis", new[] { "KullaniciID" });
            DropColumn("dbo.Siparis", "KullaniciID");
            DropTable("dbo.Kullanicis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Siparis", "KullaniciID", c => c.Int(nullable: false));
            CreateIndex("dbo.Siparis", "KullaniciID");
            AddForeignKey("dbo.Siparis", "KullaniciID", "dbo.Kullanicis", "ID", cascadeDelete: true);
        }
    }
}
