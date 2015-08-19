namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataFiles", "Size", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataFiles", "Size");
        }
    }
}
