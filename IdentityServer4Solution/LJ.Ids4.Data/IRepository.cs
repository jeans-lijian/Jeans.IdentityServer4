using LJ.Ids4.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJ.Ids4.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<TEntity> GetById(object key);

        Task Insert(TEntity entity);

        Task Insert(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task Update(IEnumerable<TEntity> entities);

        Task Delete(TEntity entity);

        Task Delete(IEnumerable<TEntity> entities);
    }
}