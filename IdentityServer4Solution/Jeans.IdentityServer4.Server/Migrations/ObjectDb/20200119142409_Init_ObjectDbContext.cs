using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeans.IdentityServer4.Server.Migrations.ObjectDb
{
    public partial class Init_ObjectDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserClaim_T_User_UserId",
                        column: x => x.UserId,
                        principalTable: "T_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_UserRoleRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserRoleRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserRoleRelation_T_User_UserId",
                        column: x => x.UserId,
                        principalTable: "T_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_UserRoleRelation_T_Role_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "T_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_UserClaim_UserId",
                table: "T_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserRoleRelation_UserId",
                table: "T_UserRoleRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserRoleRelation_UserRoleId",
                table: "T_UserRoleRelation",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserClaim");

            migrationBuilder.DropTable(
                name: "T_UserRoleRelation");

            migrationBuilder.DropTable(
                name: "T_User");

            migrationBuilder.DropTable(
                name: "T_Role");
        }
    }
}
