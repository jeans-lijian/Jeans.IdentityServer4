using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Jeans.IdentityServer4.Server.Service;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.StoreImp
{
    public class JeansResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserEntityService _userEntityService;
        public JeansResourceOwnerValidator(IUserEntityService userEntityService)
        {
            _userEntityService = userEntityService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            Core.Entity.UserEntity entity = await _userEntityService.ValidateAsync(context.UserName, context.Password);
            if (entity != null)
            {
                context.Result = new GrantValidationResult(
                    subject: entity.UserName,
                    authenticationMethod: OidcConstants.AuthenticationMethods.Password,
                    claims: entity.UserEntityClaimRelations.Select(s => new Claim(s.UserEntityClaim.Type, s.UserEntityClaim.Value)).ToList());
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid username or password");
            }
        }

    }
}
