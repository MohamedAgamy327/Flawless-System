using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "statement",
                table: "Spendings",
                newName: "Statement");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Spendings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Spendings");

            migrationBuilder.RenameColumn(
                name: "Statement",
                table: "Spendings",
                newName: "statement");
        }
    }
}
