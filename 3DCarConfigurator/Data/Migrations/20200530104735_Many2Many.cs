using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class Many2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Configurations_ConfigurationId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_ConfigurationId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "ConfigurationId",
                table: "Details");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Details",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Details",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Details",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Details",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationId",
                table: "Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_ConfigurationId",
                table: "Details",
                column: "ConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Configurations_ConfigurationId",
                table: "Details",
                column: "ConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
