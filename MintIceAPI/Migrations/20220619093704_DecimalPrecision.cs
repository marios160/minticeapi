using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MintIceAPI.Migrations
{
    public partial class DecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(5,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(5,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)");
        }
    }
}
