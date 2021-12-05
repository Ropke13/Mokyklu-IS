using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class PastabaLentele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pastaba",
                columns: table => new
                {
                    Id_Pastaba = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekstas = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    fk_Mokytojas = table.Column<string>(nullable: true),
                    fk_Mokinys = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastaba", x => x.Id_Pastaba);
                    table.ForeignKey(
                        name: "FK_Pastaba_Mokinys_fk_Mokinys",
                        column: x => x.fk_Mokinys,
                        principalTable: "Mokinys",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pastaba_fk_Mokinys",
                table: "Pastaba",
                column: "fk_Mokinys");

            migrationBuilder.CreateIndex(
                name: "IX_Pastaba_fk_Mokytojas",
                table: "Pastaba",
                column: "fk_Mokytojas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pastaba");
        }
    }
}
