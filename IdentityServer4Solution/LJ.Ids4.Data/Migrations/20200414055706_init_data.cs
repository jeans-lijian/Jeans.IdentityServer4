using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LJ.Ids4.Data.Migrations
{
    public partial class init_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apiresources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiresources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(maxLength: 100, nullable: true),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "identityresources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityresources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "apiresourceclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiresourceclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apiresourceclaims_apiresources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "apiresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apiresourcepropertys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiresourcepropertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apiresourcepropertys_apiresources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "apiresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apiscopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiscopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apiscopes_apiresources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "apiresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apisecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apisecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apisecrets_apiresources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "apiresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientclaims_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientcorsorigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientcorsorigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientcorsorigins_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientgranttypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientgranttypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientgranttypes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientidprestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientidprestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientidprestrictions_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientpostlogoutredirecturis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientpostlogoutredirecturis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientpostlogoutredirecturis_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientpropertys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientpropertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientpropertys_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientredirecturis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientredirecturis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientredirecturis_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientscopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Scope = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientscopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientscopes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientsecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientsecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientsecrets_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_identityclaims_identityresources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "identityresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityresourcepropertys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityresourcepropertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_identityresourcepropertys_identityresources_IdentityResource~",
                        column: x => x.IdentityResourceId,
                        principalTable: "identityresources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apiscopeclaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiScopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiscopeclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apiscopeclaims_apiscopes_ApiScopeId",
                        column: x => x.ApiScopeId,
                        principalTable: "apiscopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "identityresources",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(4135), null, "OpenId", false, true, "openid", false, false, true, null },
                    { 2, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(6826), null, "Profile", false, true, "profile", false, false, true, null },
                    { 3, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(6849), null, "Email", false, true, "email", false, false, true, null },
                    { 4, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(6849), null, "Address", false, true, "address", false, false, true, null },
                    { 5, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(6855), null, "Phone", false, true, "phone", false, false, true, null },
                    { 6, new DateTime(2020, 4, 14, 5, 57, 6, 226, DateTimeKind.Utc).AddTicks(6855), null, "OfflineAccess", false, true, "offline_access", false, false, true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_apiresourceclaims_ApiResourceId",
                table: "apiresourceclaims",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_apiresourcepropertys_ApiResourceId",
                table: "apiresourcepropertys",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_apiresources_Name",
                table: "apiresources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_apiscopeclaims_ApiScopeId",
                table: "apiscopeclaims",
                column: "ApiScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_apiscopes_ApiResourceId",
                table: "apiscopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_apiscopes_Name",
                table: "apiscopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_apisecrets_ApiResourceId",
                table: "apisecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_clientclaims_ClientId",
                table: "clientclaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientcorsorigins_ClientId",
                table: "clientcorsorigins",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientgranttypes_ClientId",
                table: "clientgranttypes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientidprestrictions_ClientId",
                table: "clientidprestrictions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientpostlogoutredirecturis_ClientId",
                table: "clientpostlogoutredirecturis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientpropertys_ClientId",
                table: "clientpropertys",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientredirecturis_ClientId",
                table: "clientredirecturis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_ClientId",
                table: "clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientscopes_ClientId",
                table: "clientscopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_clientsecrets_ClientId",
                table: "clientsecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_identityclaims_IdentityResourceId",
                table: "identityclaims",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_identityresourcepropertys_IdentityResourceId",
                table: "identityresourcepropertys",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_identityresources_Name",
                table: "identityresources",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apiresourceclaims");

            migrationBuilder.DropTable(
                name: "apiresourcepropertys");

            migrationBuilder.DropTable(
                name: "apiscopeclaims");

            migrationBuilder.DropTable(
                name: "apisecrets");

            migrationBuilder.DropTable(
                name: "clientclaims");

            migrationBuilder.DropTable(
                name: "clientcorsorigins");

            migrationBuilder.DropTable(
                name: "clientgranttypes");

            migrationBuilder.DropTable(
                name: "clientidprestrictions");

            migrationBuilder.DropTable(
                name: "clientpostlogoutredirecturis");

            migrationBuilder.DropTable(
                name: "clientpropertys");

            migrationBuilder.DropTable(
                name: "clientredirecturis");

            migrationBuilder.DropTable(
                name: "clientscopes");

            migrationBuilder.DropTable(
                name: "clientsecrets");

            migrationBuilder.DropTable(
                name: "identityclaims");

            migrationBuilder.DropTable(
                name: "identityresourcepropertys");

            migrationBuilder.DropTable(
                name: "apiscopes");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "identityresources");

            migrationBuilder.DropTable(
                name: "apiresources");
        }
    }
}
