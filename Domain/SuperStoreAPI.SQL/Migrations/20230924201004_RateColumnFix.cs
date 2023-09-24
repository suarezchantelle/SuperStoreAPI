using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperStoreAPI.SQL.Migrations
{
    public partial class RateColumnFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                schema: "dbo",
                table: "Products",
                type: "decimal(2,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(1,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                schema: "dbo",
                table: "Products",
                type: "decimal(1,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)");
        }
    }
}
