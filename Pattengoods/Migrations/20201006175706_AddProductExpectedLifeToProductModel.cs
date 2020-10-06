using Microsoft.EntityFrameworkCore.Migrations;

namespace Pattengoods.Migrations
{
    public partial class AddProductExpectedLifeToProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductExpectedLife",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductExpectedLife",
                table: "Products");
        }
    }
}
