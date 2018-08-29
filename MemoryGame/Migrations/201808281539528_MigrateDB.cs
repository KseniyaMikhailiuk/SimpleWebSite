namespace MemoryGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Looks", "Image", c => c.Binary());
            DropColumn("dbo.Looks", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Looks", "Photo", c => c.String());
            DropColumn("dbo.Looks", "Image");
        }
    }
}
