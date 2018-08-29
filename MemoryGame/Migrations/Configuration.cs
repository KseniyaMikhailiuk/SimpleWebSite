namespace MemoryGame.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MemoryGame.Models.LookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MemoryGame.Models.LookContext";
        }

        protected override void Seed(MemoryGame.Models.LookContext context)
        {

        }
    }
}
