namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriAciklama : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "Aciklama", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategoris", "Aciklama");
        }
    }
}
