using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pattengoods.Migrations
{
    public partial class Wireframe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistories_AspNetUsers_UserProfileId1",
                table: "PurchaseHistories");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistories_UserProfileId1",
                table: "PurchaseHistories");

            migrationBuilder.DropColumn(
                name: "UserProfileId1",
                table: "PurchaseHistories");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PortfolioAmount",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PerpetuityBalance",
                table: "PurchaseHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PortfolioAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistories_UserProfileId",
                table: "PurchaseHistories",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistories_UserProfiles_UserProfileId",
                table: "PurchaseHistories",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistories_UserProfiles_UserProfileId",
                table: "PurchaseHistories");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistories_UserProfileId",
                table: "PurchaseHistories");

            migrationBuilder.DropColumn(
                name: "PerpetuityBalance",
                table: "PurchaseHistories");

            migrationBuilder.AddColumn<string>(
                name: "UserProfileId1",
                table: "PurchaseHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PortfolioAmount",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistories_UserProfileId1",
                table: "PurchaseHistories",
                column: "UserProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistories_AspNetUsers_UserProfileId1",
                table: "PurchaseHistories",
                column: "UserProfileId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
