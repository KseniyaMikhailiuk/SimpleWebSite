using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class RoleStore : IRoleStore<ApplicationRole>
    {
        public RoleStore(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; set; }

        public Task CreateAsync(ApplicationRole role)
        {
            return Task.Factory.StartNew(() => DbContext.Roles.Add(role));
        }

        public Task DeleteAsync(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            return Task<ApplicationRole>.Factory.StartNew(() => (ApplicationRole)DbContext.Roles.FirstOrDefault(r => r.Name == roleName));
        }

        public Task UpdateAsync(ApplicationRole role)
        {
            throw new NotImplementedException();
        }
    }
}