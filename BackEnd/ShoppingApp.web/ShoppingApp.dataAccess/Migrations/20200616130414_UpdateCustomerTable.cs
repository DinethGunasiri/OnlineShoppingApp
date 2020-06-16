using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.dataAccess.Migrations
{
    public partial class UpdateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "zipCode",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "zipCode",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
