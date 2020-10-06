using Microsoft.EntityFrameworkCore.Migrations;

namespace Pattengoods.Migrations
{
    public partial class AddAmountPerPurchaseToPurchaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountPerPurchase",
                table: "PurchaseHistories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPerPurchase",
                table: "PurchaseHistories");
        }
    }
}
