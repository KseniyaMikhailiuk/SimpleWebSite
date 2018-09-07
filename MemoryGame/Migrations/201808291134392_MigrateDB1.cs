namespace MemoryGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Looks", "Description", c => c.String());
            DropColumn("dbo.Looks", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Looks", "Brand", c => c.String());
            DropColumn("dbo.Looks", "Description");
        }
    }
}
