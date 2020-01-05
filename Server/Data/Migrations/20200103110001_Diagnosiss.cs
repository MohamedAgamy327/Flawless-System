using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Diagnosiss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosess",
                table: "Diagnosess");

            migrationBuilder.RenameTable(
                name: "Diagnosess",
                newName: "Diagnosiss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss");

            migrationBuilder.RenameTable(
                name: "Diagnosiss",
                newName: "Diagnosess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosess",
                table: "Diagnosess",
                column: "Id");
        }
    }
}
