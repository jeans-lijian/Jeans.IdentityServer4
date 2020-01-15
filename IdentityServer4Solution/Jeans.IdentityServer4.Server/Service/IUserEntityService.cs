using Jeans.IdentityServer4.Server.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public interface IUserEntityService
    {
        Task<UserEntity> ValidateAsync(string userName, string password);

        Task<UserEntity> GetUserEntityByNameAsync(string userName);
    }
}
