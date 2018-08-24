using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MemoryGame.Models
{
    public class UserStore : IUserStore<ApplicationUser>
    {
        public UserStore(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; set; }

        public Task CreateAsync(ApplicationUser user)
        {
            return Task.Factory.StartNew(() => DbContext.Users.Add(user));
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task<ApplicationUser>.Factory.StartNew(() => (ApplicationUser)DbContext.Users.FirstOrDefault(u => u.UserName == userName));
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}