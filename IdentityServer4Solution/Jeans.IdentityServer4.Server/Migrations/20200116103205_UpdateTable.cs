using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeans.IdentityServer4.Server.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_UserClaim_T_User_UserId",
                table: "T_UserClaim");

            migrationBuilder.DropIndex(
                name: "IX_T_UserClaim_UserId",
                table: "T_UserClaim");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "T_UserClaim");

            migrationBuilder.CreateTable(
                name: "T_UserClaimRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserClaimId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserClaimRelation");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "T_UserClaim",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_UserClaim_UserId",
                table: "T_UserClaim",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_UserClaim_T_User_UserId",
                table: "T_UserClaim",
                column: "UserId",
                principalTable: "T_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
