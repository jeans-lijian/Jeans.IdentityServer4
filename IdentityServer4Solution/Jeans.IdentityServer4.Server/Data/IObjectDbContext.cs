using Jeans.IdentityServer4.Server.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data
{
    public interface IObjectDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}