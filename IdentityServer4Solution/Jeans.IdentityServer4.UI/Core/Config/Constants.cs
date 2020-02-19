#region 程序集 IdentityServer4, Version=2.5.4.0, Culture=neutral, PublicKeyToken=f294d0afe402bb2b
// C:\Users\lijian15\.nuget\packages\identityserver4\2.5.4\lib\netstandard2.0\IdentityServer4.dll
#endregion

namespace Jeans.IdentityServer4.UI.Core.Config
{
    public static class IdentityServerConstants
    {
        public const string LocalIdentityProvider = "local";
        public const string DefaultCookieAuthenticationScheme = "idsrv";
        public const string SignoutScheme = "idsrv";
        public const string ExternalCookieAuthenticationScheme = "idsrv.external";
        public const string DefaultCheckSessionCookieName = "idsrv.session";
        public const string AccessTokenAudience = "{0}resources";
        public const string JwtRequestClientKey = "idsrv.jwtrequesturi.client";

        public static class PersistedGrantTypes
        {
            public const string AuthorizationCode = "authorization_code";
            public const string ReferenceToken = "reference_token";
            public const string RefreshToken = "refresh_token";
            public const string UserConsent = "user_consent";
            public const string DeviceCode = "device_code";
            public const string UserCode = "user_code";
        }
        public static class StandardScopes
        {
            //
            // 摘要:
            //     REQUIRED. Informs the Authorization Server that the Client is making an OpenID
            //     Connect request. If the openid scope value is not present, the behavior is entirely
            //     unspecified.
            public const string OpenId = "openid";
            //
            // 摘要:
            //     OPTIONAL. This scope value requests access to the End-User's default profile
            //     Claims, which are: name, family_name, given_name, middle_name, nickname, preferred_username,
            //     profile, picture, website, gender, birthdate, zoneinfo, locale, and updated_at.
            public const string Profile = "profile";
            //
            // 摘要:
            //     OPTIONAL. This scope value requests access to the email and email_verified Claims.
            public const string Email = "email";
            //
            // 摘要:
            //     OPTIONAL. This scope value requests access to the address Claim.
            public const string Address = "address";
            //
            // 摘要:
            //     OPTIONAL. This scope value requests access to the phone_number and phone_number_verified
            //     Claims.
            public const string Phone = "phone";
            //
            // 摘要:
            //     This scope value MUST NOT be used with the OpenID Connect Implicit Client Implementer's
            //     Guide 1.0. See the OpenID Connect Basic Client Implementer's Guide 1.0 (http://openid.net/specs/openid-connect-implicit-1_0.html#OpenID.Basic)
            //     for its usage in that subset of OpenID Connect.
            public const string OfflineAccess = "offline_access";
        }
        public static class ProfileIsActiveCallers
        {
            public const string AuthorizeEndpoint = "AuthorizeEndpoint";
            public const string IdentityTokenValidation = "IdentityTokenValidation";
            public const string AccessTokenValidation = "AccessTokenValidation";
            public const string ResourceOwnerValidation = "ResourceOwnerValidation";
            public const string ExtensionGrantValidation = "ExtensionGrantValidation";
            public const string RefreshTokenValidation = "RefreshTokenValidation";
            public const string AuthorizationCodeValidation = "AuthorizationCodeValidation";
            public const string UserInfoRequestValidation = "UserInfoRequestValidation";
            public const string DeviceCodeValidation = "DeviceCodeValidation";
        }
        public static class ProfileDataCallers
        {
            public const string UserInfoEndpoint = "UserInfoEndpoint";
            public const string ClaimsProviderIdentityToken = "ClaimsProviderIdentityToken";
            public const string ClaimsProviderAccessToken = "ClaimsProviderAccessToken";
        }
        public static class SecretTypes
        {
            public const string SharedSecret = "SharedSecret";
            public const string X509CertificateThumbprint = "X509Thumbprint";
            public const string X509CertificateName = "X509Name";
            public const string X509CertificateBase64 = "X509CertificateBase64";
            public const string JsonWebKey = "JWK";
        }
        public static class TokenTypes
        {
            public const string IdentityToken = "id_token";
            public const string AccessToken = "access_token";
        }
        public static class ClaimValueTypes
        {
            public const string Json = "json";
        }
        public static class UserCodeTypes
        {
            public const string Numeric = "Numeric";
        }
        public static class ProtocolTypes
        {
            public const string OpenIdConnect = "oidc";
            public const string WsFederation = "wsfed";
            public const string Saml2p = "saml2p";
        }
        //
        // 摘要:
        //     Constants for local IdentityServer access token authentication.
        public static class LocalApi
        {
            //
            // 摘要:
            //     The authentication scheme when using the AddLocalApi helper.
            public const string AuthenticationScheme = "IdentityServerAccessToken";
            //
            // 摘要:
            //     The API scope name when using the AddLocalApiAuthentication helper.
            public const string ScopeName = "IdentityServerApi";
            //
            // 摘要:
            //     The authorization policy name when using the AddLocalApiAuthentication helper.
            public const string PolicyName = "IdentityServerAccessToken";
        }
        public static class ParsedSecretTypes
        {
            public const string NoSecret = "NoSecret";
            public const string SharedSecret = "SharedSecret";
            public const string X509Certificate = "X509Certificate";
            public const string JwtBearer = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";
        }
        public class MutualTls
        {
            public const string X509CertificateItemKey = "IdentityServer:MTLS:X509Certificate";

            public MutualTls() { }
        }
    }
}