namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScanId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataFiles", "ScanId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataFiles", "ScanId");
        }
    }
}
