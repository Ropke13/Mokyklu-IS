using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class PastabaUpdateLentele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zinutes",
                columns: table => new
                {
                    Id_Zinutes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekstas = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    fk_Tevas = table.Column<string>(nullable: true),
                    fk_Mokytojas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zinutes", x => x.Id_Zinutes);
                    table.ForeignKey(
                        name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zinutes_Tevas_fk_Tevas",
                        column: x => x.fk_Tevas,
                        principalTable: "Tevas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zinutes_fk_Mokytojas",
                table: "Zinutes",
                column: "fk_Mokytojas");

            migrationBuilder.CreateIndex(
                name: "IX_Zinutes_fk_Tevas",
                table: "Zinutes",
                column: "fk_Tevas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zinutes");
        }
    }
}
