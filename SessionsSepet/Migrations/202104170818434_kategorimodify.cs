namespace SessionsSepet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategorimodify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kategoris", "Adi", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kategoris", "Adi", c => c.String());
        }
    }
}
