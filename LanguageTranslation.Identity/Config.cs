﻿using Duende.IdentityServer.Models;

namespace LanguageTranslation.Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("LanguageTranslation.Web.fullaccess"),
            new ApiScope("LanguageTranslation.Api.fullaccess"),
        };

    public static IEnumerable<ApiResource> ApiResources =>
       new ApiResource[]
       {
            new ApiResource("LanguageTranslation.Api","Lanaguage Translation API")
            {
                Scopes = { "LanguageTranslation.Api.fullaccess"},
            },
            new ApiResource("LanguageTranslation.Web","Language Translation Web")
            {
                Scopes = { "LanguageTranslation.Web.fullaccess" }
            },
       };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "LanguageTranslation.Api.fullaccess" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7058/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7058/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7058/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "LanguageTranslation.Web.fullaccess" }
            },
        };
}
