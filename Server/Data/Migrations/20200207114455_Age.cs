using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Age : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");
        }
    }
}
