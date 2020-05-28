using Microsoft.EntityFrameworkCore.Migrations;

namespace _3DCarConfigurator.Data.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ApplicationUserId",
                table: "Configurations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_AspNetUsers_ApplicationUserId",
                table: "Configurations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_AspNetUsers_ApplicationUserId",
                table: "Configurations");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_ApplicationUserId",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");
        }
    }
}
