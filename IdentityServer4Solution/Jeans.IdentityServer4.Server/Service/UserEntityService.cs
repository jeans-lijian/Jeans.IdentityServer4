using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public class UserEntityService : IUserEntityService
    {
        private readonly IRepository<UserEntity> _userRepository;
        public UserEntityService(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ValidateAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
