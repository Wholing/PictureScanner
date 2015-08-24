namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notduplicate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuplicateFiles", "NotDuplicate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DuplicateFiles", "NotDuplicate");
        }
    }
}
