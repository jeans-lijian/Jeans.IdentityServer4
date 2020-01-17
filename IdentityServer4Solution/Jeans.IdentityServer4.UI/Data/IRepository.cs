using Jeans.IdentityServer4.UI.Core;
using System.Collections.Generic;
using System.Linq;

namespace Jeans.IdentityServer4.UI.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetById(object key);

        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}
