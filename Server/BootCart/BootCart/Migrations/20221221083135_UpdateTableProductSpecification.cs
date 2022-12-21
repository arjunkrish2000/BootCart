using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCart.Migrations
{
    public partial class UpdateTableProductSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemQty",
                table: "ProductSpecifications",
                newName: "ItemQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemQuantity",
                table: "ProductSpecifications",
                newName: "ItemQty");
        }
    }
}
