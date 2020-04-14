using System;
using System.Collections.Generic;
using System.Text;

namespace LJ.Ids4.Data
{
    /// <summary>
    /// 应用仓库
    /// </summary>
    public interface IAppRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}