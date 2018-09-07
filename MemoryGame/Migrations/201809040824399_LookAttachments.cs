namespace MemoryGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LookAttachments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LookAttachmentFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        LookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Looks", t => t.LookId, cascadeDelete: true)
                .Index(t => t.LookId);
            
            DropColumn("dbo.Looks", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Looks", "Image", c => c.Binary());
            DropForeignKey("dbo.LookAttachmentFiles", "LookId", "dbo.Looks");
            DropIndex("dbo.LookAttachmentFiles", new[] { "LookId" });
            DropTable("dbo.LookAttachmentFiles");
        }
    }
}
