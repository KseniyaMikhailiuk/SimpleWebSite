using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryGame.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public string Person { get; set; }

        public int LookId { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }
    }
}