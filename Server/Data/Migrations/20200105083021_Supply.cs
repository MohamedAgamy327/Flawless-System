using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Supply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplysItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    SupplyId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplysItems", x => new { x.ItemId, x.SupplyId });
                    table.ForeignKey(
                        name: "FK_SupplysItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplysItems_Supplys_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplysItems_SupplyId",
                table: "SupplysItems",
                column: "SupplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplysItems");

            migrationBuilder.DropTable(
                name: "Supplys");
        }
    }
}
