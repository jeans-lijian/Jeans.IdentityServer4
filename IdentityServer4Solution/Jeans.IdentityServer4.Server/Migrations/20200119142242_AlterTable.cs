using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeans.IdentityServer4.Server.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserClaimRelation");

            migrationBuilder.DropTable(
                name: "T_UserClaim");

            migrationBuilder.DropTable(
                name: "T_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: false)
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
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserClaimRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserClaimId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserClaimRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserClaimRelation_T_UserClaim_UserClaimId",
                        column: x => x.UserClaimId,
                        principalTable: "T_UserClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_UserClaimRelation_T_User_UserId",
                        column: x => x.UserId,
                        principalTable: "T_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_UserClaimRelation_UserClaimId",
                table: "T_UserClaimRelation",
                column: "UserClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserClaimRelation_UserId",
                table: "T_UserClaimRelation",
                column: "UserId");
        }
    }
}
