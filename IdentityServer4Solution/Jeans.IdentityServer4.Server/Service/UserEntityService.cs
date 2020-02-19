using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public class UserEntityService : IUserEntityService
    {
        private readonly IObjectRepository<UserEntity> _userRepository;
        public UserEntityService(IObjectRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserEntity> ValidateAsync(string userName, string password)
        {
            return await _userRepository.TableNoTracking
                                                        .Include(x => x.UserEntityClaims)
                                                        .SingleOrDefaultAsync(w => w.UserName == userName && w.Password == password);
        }

        public async Task<UserEntity> GetUserEntityByNameAsync(string userName)
        {
            return await _userRepository.TableNoTracking
                                                        .Include(x => x.UserEntityClaims)
                                                        .SingleOrDefaultAsync(w => w.UserName == userName);
        }

    }
}
