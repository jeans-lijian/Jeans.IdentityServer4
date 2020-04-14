using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.IdsStore
{
    public class CustomResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        //private readonly IUserEntityService _userEntityService;

        //public JeansResourceOwnerValidator(IUserEntityService userEntityService)
        //{
        //    _userEntityService = userEntityService;
        //}

        //public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        //{
        //    Core.Entity.UserEntity entity = await _userEntityService.ValidateAsync(context.UserName, context.Password);
        //    if (entity != null)
        //    {
        //        context.Result = new GrantValidationResult(
        //            subject: entity.UserName,
        //            authenticationMethod: OidcConstants.AuthenticationMethods.Password,
        //            claims: entity.UserEntityClaims.Select(s => new Claim(s.Type, s.Value)).ToList());
        //    }
        //    else
        //    {
        //        context.Result = new GrantValidationResult(
        //            TokenRequestErrors.InvalidGrant,
        //            "invalid username or password!");
        //    }
        //}
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}