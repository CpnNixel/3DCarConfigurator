using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model3dPath",
                table: "Configurations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Model3dPath",
                table: "Configurations");
        }
    }
}
