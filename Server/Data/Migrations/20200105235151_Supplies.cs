using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Supplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplysItems_Items_ItemId",
                table: "SupplysItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplysItems_Supplys_SupplyId",
                table: "SupplysItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplysItems",
                table: "SupplysItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplys",
                table: "Supplys");

            migrationBuilder.RenameTable(
                name: "SupplysItems",
                newName: "SuppliesItems");

            migrationBuilder.RenameTable(
                name: "Supplys",
                newName: "Supplies");

            migrationBuilder.RenameIndex(
                name: "IX_SupplysItems_SupplyId",
                table: "SuppliesItems",
                newName: "IX_SuppliesItems_SupplyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuppliesItems",
                table: "SuppliesItems",
                columns: new[] { "ItemId", "SupplyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliesItems_Items_ItemId",
                table: "SuppliesItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliesItems_Supplies_SupplyId",
                table: "SuppliesItems",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuppliesItems_Items_ItemId",
                table: "SuppliesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SuppliesItems_Supplies_SupplyId",
                table: "SuppliesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuppliesItems",
                table: "SuppliesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies");

            migrationBuilder.RenameTable(
                name: "SuppliesItems",
                newName: "SupplysItems");

            migrationBuilder.RenameTable(
                name: "Supplies",
                newName: "Supplys");

            migrationBuilder.RenameIndex(
                name: "IX_SuppliesItems_SupplyId",
                table: "SupplysItems",
                newName: "IX_SupplysItems_SupplyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplysItems",
                table: "SupplysItems",
                columns: new[] { "ItemId", "SupplyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplys",
                table: "Supplys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplysItems_Items_ItemId",
                table: "SupplysItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplysItems_Supplys_SupplyId",
                table: "SupplysItems",
                column: "SupplyId",
                principalTable: "Supplys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
