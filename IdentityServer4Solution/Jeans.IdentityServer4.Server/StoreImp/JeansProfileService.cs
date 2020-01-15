using IdentityServer4.Models;
using IdentityServer4.Services;
using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.StoreImp
{
    public class JeansProfileService : IProfileService
    {
        private readonly IUserEntityService _userEntityService;
        public JeansProfileService(IUserEntityService userEntityService)
        {
            _userEntityService = userEntityService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            UserEntity entity = await _userEntityService.GetUserEntityByNameAsync(context.Subject.Identity.Name);
            if (entity == null)
            {
                context.IssuedClaims = new List<Claim>();
            }
            else
            {
                context.IssuedClaims = entity.UserEntityClaims.Where(w => context.RequestedClaimTypes.Contains(w.Type)).Select(s => new Claim(s.Type, s.Value)).ToList();
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}
