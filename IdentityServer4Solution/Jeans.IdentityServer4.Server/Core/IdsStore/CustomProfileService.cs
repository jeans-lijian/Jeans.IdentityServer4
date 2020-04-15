using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using LJ.Ids4.Core.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.IdsStore
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var entity = await _userManager.FindByNameAsync(sub);
            if (entity == null)
            {
                context.IssuedClaims = new List<Claim>();
            }
            else
            {
                var userClaims = await _userManager.GetClaimsAsync(entity);
                context.IssuedClaims = userClaims.Where(w => context.RequestedClaimTypes.Contains(w.Type)).ToList();
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}