using System;
using System.Collections.Generic;
using System.Text;

namespace LJ.Ids4.Data
{
    /// <summary>
    /// ids4 仓库
    /// </summary>
    public interface IIds4Repository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}