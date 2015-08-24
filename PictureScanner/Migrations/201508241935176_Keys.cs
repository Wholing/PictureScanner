namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuplicateFiles", "DataFile_Id", "dbo.DataFiles");
            DropForeignKey("dbo.DuplicationOwners", "Owner_Id", "dbo.DataFiles");
            DropIndex("dbo.DuplicateFiles", new[] { "DataFile_Id" });
            DropIndex("dbo.DuplicationOwners", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.DuplicateFiles", name: "DataFile_Id", newName: "DataFileId");
            RenameColumn(table: "dbo.DuplicationOwners", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.DuplicateFiles", "DataFileId", c => c.Int(nullable: false));
            AlterColumn("dbo.DuplicationOwners", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.DuplicateFiles", "DataFileId");
            CreateIndex("dbo.DuplicationOwners", "OwnerId");
            AddForeignKey("dbo.DuplicateFiles", "DataFileId", "dbo.DataFiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DuplicationOwners", "OwnerId", "dbo.DataFiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuplicationOwners", "OwnerId", "dbo.DataFiles");
            DropForeignKey("dbo.DuplicateFiles", "DataFileId", "dbo.DataFiles");
            DropIndex("dbo.DuplicationOwners", new[] { "OwnerId" });
            DropIndex("dbo.DuplicateFiles", new[] { "DataFileId" });
            AlterColumn("dbo.DuplicationOwners", "OwnerId", c => c.Int());
            AlterColumn("dbo.DuplicateFiles", "DataFileId", c => c.Int());
            RenameColumn(table: "dbo.DuplicationOwners", name: "OwnerId", newName: "Owner_Id");
            RenameColumn(table: "dbo.DuplicateFiles", name: "DataFileId", newName: "DataFile_Id");
            CreateIndex("dbo.DuplicationOwners", "Owner_Id");
            CreateIndex("dbo.DuplicateFiles", "DataFile_Id");
            AddForeignKey("dbo.DuplicationOwners", "Owner_Id", "dbo.DataFiles", "Id");
            AddForeignKey("dbo.DuplicateFiles", "DataFile_Id", "dbo.DataFiles", "Id");
        }
    }
}
