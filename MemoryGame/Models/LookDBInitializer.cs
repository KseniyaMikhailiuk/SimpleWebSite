using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MemoryGame.Models
{
    public class LookDBInitializer: DropCreateDatabaseAlways<LookContext>
    {
        protected override void Seed(LookContext database)
        {
            database.Looks.Add(new Look { Name = "Look1", Brand = "Zara", Price = 150, Style = "casual" });
            database.Looks.Add(new Look { Name = "Look2", Brand = "Zara", Price = 150, Style = "sport" });
            database.Looks.Add(new Look { Name = "Look3", Brand = "Zara", Price = 150, Style = "casual" });
            database.Looks.Add(new Look { Name = "Look4", Brand = "Zara", Price = 150, Style = "official" });
            database.Looks.Add(new Look { Name = "Look1", Brand = "Zara", Price = 150, Style = "official" });
            database.Looks.Add(new Look { Name = "Look5", Brand = "Zara", Price = 150, Style = "casual" });
            base.Seed(database);
        }
    }
}