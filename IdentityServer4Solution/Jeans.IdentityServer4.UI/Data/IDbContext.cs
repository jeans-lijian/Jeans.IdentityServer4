using Jeans.IdentityServer4.UI.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
