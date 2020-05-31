using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class ShockContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.AddColumn<float>(
                name: "DetailPrice",
                table: "Details",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CarPrice",
                table: "Cars",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailPrice",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "CarPrice",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
