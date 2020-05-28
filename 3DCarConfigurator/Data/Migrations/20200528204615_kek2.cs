using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class kek2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
