namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DuplicateFiles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DataFiles", newName: "DuplicateFiles");
            CreateTable(
                "dbo.DataFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScanId = c.Guid(nullable: false),
                        FileNameFull = c.String(),
                        Size = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DuplicationOwners", "ScanId", c => c.Guid(nullable: false));
            AddColumn("dbo.DuplicateFiles", "DataFile_Id", c => c.Int());
            AlterColumn("dbo.DuplicateFiles", "Confirmed", c => c.Boolean(nullable: false));
            CreateIndex("dbo.DuplicateFiles", "DataFile_Id");
            AddForeignKey("dbo.DuplicateFiles", "DataFile_Id", "dbo.DataFiles", "Id");
            DropColumn("dbo.DuplicateFiles", "FileNameFull");
            DropColumn("dbo.DuplicateFiles", "Size");
            DropColumn("dbo.DuplicateFiles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuplicateFiles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.DuplicateFiles", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.DuplicateFiles", "FileNameFull", c => c.String());
            DropForeignKey("dbo.DuplicateFiles", "DataFile_Id", "dbo.DataFiles");
            DropIndex("dbo.DuplicateFiles", new[] { "DataFile_Id" });
            AlterColumn("dbo.DuplicateFiles", "Confirmed", c => c.Boolean());
            DropColumn("dbo.DuplicateFiles", "DataFile_Id");
            DropColumn("dbo.DuplicationOwners", "ScanId");
            DropTable("dbo.DataFiles");
            RenameTable(name: "dbo.DuplicateFiles", newName: "DataFiles");
        }
    }
}
