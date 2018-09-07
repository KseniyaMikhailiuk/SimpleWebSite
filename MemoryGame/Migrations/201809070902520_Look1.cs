namespace MemoryGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Look1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LookAttachmentFiles", "FileType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LookAttachmentFiles", "FileType");
        }
    }
}
