using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MedicineTypeFrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Frequencys_FrequencyId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Drop",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Medicines");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineTypeId",
                table: "Medicines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyId",
                table: "Medicines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Frequencys_FrequencyId",
                table: "Medicines",
                column: "FrequencyId",
                principalTable: "Frequencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId",
                principalTable: "MedicineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Frequencys_FrequencyId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                table: "Medicines");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineTypeId",
                table: "Medicines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyId",
                table: "Medicines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Drop",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
