using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Checking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagonsis = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    NextVisitDate = table.Column<DateTime>(nullable: false),
                    VisitType = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    CheckingId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingItems", x => new { x.ItemId, x.CheckingId });
                    table.ForeignKey(
                        name: "FK_CheckingItems_Checkings_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingMedicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false),
                    CheckingId = table.Column<int>(nullable: false),
                    FrequencyId = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingMedicines", x => new { x.MedicineId, x.CheckingId });
                    table.ForeignKey(
                        name: "FK_CheckingMedicines_Checkings_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingMedicines_Frequencys_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckingMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingTests",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false),
                    CheckingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingTests", x => new { x.TestId, x.CheckingId });
                    table.ForeignKey(
                        name: "FK_CheckingTests_Checkings_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingItems_CheckingId",
                table: "CheckingItems",
                column: "CheckingId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingMedicines_CheckingId",
                table: "CheckingMedicines",
                column: "CheckingId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingMedicines_FrequencyId",
                table: "CheckingMedicines",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_PatientId",
                table: "Checkings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingTests_CheckingId",
                table: "CheckingTests",
                column: "CheckingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingItems");

            migrationBuilder.DropTable(
                name: "CheckingMedicines");

            migrationBuilder.DropTable(
                name: "CheckingTests");

            migrationBuilder.DropTable(
                name: "Checkings");
        }
    }
}
