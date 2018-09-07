using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoryGame.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(): base("IdentityDb"){ }

        public DbSet<Look> Looks { get; set; }
        public DbSet<LookAttachmentFile> LookAttachments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}