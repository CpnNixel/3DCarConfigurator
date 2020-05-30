using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Details");

            migrationBuilder.AddColumn<int>(
                name: "DetailPrice",
                table: "Details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailPrice",
                table: "Details");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
