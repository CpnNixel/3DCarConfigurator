using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class ConfigPathPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToPicture",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "PathToPicture",
                table: "Configurations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToPicture",
                table: "Configurations");

            migrationBuilder.AddColumn<string>(
                name: "PathToPicture",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
