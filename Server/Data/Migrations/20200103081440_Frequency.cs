using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Frequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicineTypeId",
                table: "Medicines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Frequencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(nullable: false),
                    EnglishName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_FrequencyId",
                table: "Medicines",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Frequencys_FrequencyId",
                table: "Medicines",
                column: "FrequencyId",
                principalTable: "Frequencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId",
                principalTable: "MedicineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Frequencys_FrequencyId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Frequencys");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_FrequencyId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicineTypeId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineTypeId",
                table: "Medicines");
        }
    }
}
