using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCPos.Data.Migrations
{
    public partial class nota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NotaFiscalId",
                table: "Item",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<float>(type: "real", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_NotaFiscalId",
                table: "Item",
                column: "NotaFiscalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_NotaFiscal_NotaFiscalId",
                table: "Item",
                column: "NotaFiscalId",
                principalTable: "NotaFiscal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_NotaFiscal_NotaFiscalId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_Item_NotaFiscalId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Item");
        }
    }
}
