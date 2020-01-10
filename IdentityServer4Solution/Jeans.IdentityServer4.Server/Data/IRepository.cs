using Jeans.IdentityServer4.Server.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {

    }
}
