using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MemoryGame.Models
{
    public class LookContext: DbContext
    {
        public DbSet<Look> Looks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}