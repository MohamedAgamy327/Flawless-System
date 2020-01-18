using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Waiting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Waitings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CanceledDate = table.Column<DateTime>(nullable: true),
                    EnteredDate = table.Column<DateTime>(nullable: true),
                    FinishedDate = table.Column<DateTime>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waitings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waitings_PatientId",
                table: "Waitings",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waitings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Spendings",
                type: "int",
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
    }
}
