using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class kek4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
           name: "FK_Details_Configurations_ConfigurationId",
           table: "Details");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigurationId",
                table: "Details",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsString",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Configurations_ConfigurationId",
                table: "Details",
                column: "ConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
             name: "FK_Details_Configurations_ConfigurationId",
             table: "Details");

            migrationBuilder.DropColumn(
                name: "DetailsString",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigurationId",
                table: "Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
