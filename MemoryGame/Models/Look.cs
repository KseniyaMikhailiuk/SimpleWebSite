using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryGame.Models
{
    public class Look
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string Name { get; set; }

        public string Style { get; set; }

        public virtual ICollection<LookAttachmentFile> LookAttachmentFiles { get; set; }
    }
}