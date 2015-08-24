namespace PictureScanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DuplicationOwner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DuplicationOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataFiles", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            AddColumn("dbo.DataFiles", "Confirmed", c => c.Boolean());
            AddColumn("dbo.DataFiles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.DataFiles", "DuplicationOwner_Id", c => c.Int());
            CreateIndex("dbo.DataFiles", "DuplicationOwner_Id");
            AddForeignKey("dbo.DataFiles", "DuplicationOwner_Id", "dbo.DuplicationOwners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuplicationOwners", "Owner_Id", "dbo.DataFiles");
            DropForeignKey("dbo.DataFiles", "DuplicationOwner_Id", "dbo.DuplicationOwners");
            DropIndex("dbo.DataFiles", new[] { "DuplicationOwner_Id" });
            DropIndex("dbo.DuplicationOwners", new[] { "Owner_Id" });
            DropColumn("dbo.DataFiles", "DuplicationOwner_Id");
            DropColumn("dbo.DataFiles", "Discriminator");
            DropColumn("dbo.DataFiles", "Confirmed");
            DropTable("dbo.DuplicationOwners");
        }
    }
}
