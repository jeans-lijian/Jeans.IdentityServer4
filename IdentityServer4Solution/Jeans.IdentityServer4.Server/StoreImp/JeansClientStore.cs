using IdentityServer4.Models;
using IdentityServer4.Stores;
using Jeans.IdentityServer4.Server.Service;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.StoreImp
{
    public class JeansClientStore : IClientStore
    {
        private readonly IClientService _clientService;
        public JeansClientStore(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            Core.Entity.Client entity = await _clientService.FindClientByIdAsync(clientId);
            if (entity == null)
            {
                return new Client();
            }

            Client client = new Client
            {
                AllowOfflineAccess = entity.AllowOfflineAccess,
                IdentityTokenLifetime = entity.IdentityTokenLifetime,
                AccessTokenLifetime = entity.AccessTokenLifetime,
                AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
                AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
                ConsentLifetime = entity.ConsentLifetime,
                RefreshTokenUsage = (TokenUsage)entity.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = (TokenExpiration)entity.RefreshTokenExpiration,
                AccessTokenType = (AccessTokenType)entity.AccessTokenType,
                EnableLocalLogin = entity.EnableLocalLogin,
                IncludeJwtId = entity.IncludeJwtId,
                AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
                ClientClaimsPrefix = entity.ClientClaimsPrefix,
                PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
                UserSsoLifetime = entity.UserSsoLifetime,
                UserCodeType = entity.UserCodeType,
                DeviceCodeLifetime = entity.DeviceCodeLifetime,
                AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
                BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
                Enabled = entity.Enabled,
                ClientId = entity.ClientId,
                ProtocolType = entity.ProtocolType,
                RequireClientSecret = entity.RequireClientSecret,
                ClientName = entity.ClientName,
                Description = entity.Description,
                ClientUri = entity.ClientUri,
                LogoUri = entity.LogoUri,
                RequireConsent = entity.RequireConsent,
                RequirePkce = entity.RequirePkce,
                AllowPlainTextPkce = entity.AllowPlainTextPkce,
                AllowAccessTokensViaBrowser = entity.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = entity.BackChannelLogoutUri,
                AllowRememberConsent = entity.AllowRememberConsent,
                ClientSecrets = entity.ClientSecrets.Select(s => new Secret
                {
                    Type = s.Type,
                    Value = s.Value.Sha256(),
                    Expiration = s.Expiration,
                    Description = s.Description
                }).ToList(),
                AllowedScopes = entity.ClientScopes.Select(s =>s.Scope).ToList(),
                Claims = entity.ClientClaims.Select(s => new Claim(s.Type, s.Value)).ToList(),
                IdentityProviderRestrictions = entity.ClientIdPRestrictions.Select(s => s.Provider).ToList(),
                Properties = entity.ClientProperties.ToDictionary(k => k.Key, v => v.Value),
                PostLogoutRedirectUris = entity.ClientPostLogoutRedirectUris.Select(s => s.PostLogoutRedirectUri).ToList(),
                RedirectUris = entity.ClientRedirectUris.Select(s => s.RedirectUri).ToList(),
                AllowedGrantTypes = entity.ClientGrantTypes.Select(s => s.GrantType).ToList(),
                AllowedCorsOrigins = entity.ClientCorsOrigins.Select(s => s.Origin).ToList()
            };

            return client;
        }

    }
}
