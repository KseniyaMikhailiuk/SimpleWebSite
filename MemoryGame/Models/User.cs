using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryGame.Models
{
    public class User
    {
        public int Id;
        public string Username;
        public string Email;
        public string Password;
        public DateTime CreationDate { get; set; }

        public int? RoleId;
        public Role Role;
    }
}