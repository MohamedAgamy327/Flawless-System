using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SpendingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Spendings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_UserId",
                table: "Spendings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_Users_UserId",
                table: "Spendings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_Users_UserId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_UserId",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Spendings");
        }
    }
}
