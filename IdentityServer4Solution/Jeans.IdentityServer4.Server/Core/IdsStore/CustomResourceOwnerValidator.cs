using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using LJ.Ids4.Core.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.IdsStore
{
    public class CustomResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomResourceOwnerValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var entity = await _userManager.FindByNameAsync(context.UserName);
            if (entity != null)
            {
                var userClaims = await _userManager.GetClaimsAsync(entity);

                context.Result = new GrantValidationResult(
                    subject: entity.UserName,
                    authenticationMethod: OidcConstants.AuthenticationMethods.Password,
                    claims: userClaims.ToList());
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid username or password!");
            }
        }
    }
}