using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class DONE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atsiskaitymas",
                columns: table => new
                {
                    Id_Atsiskaitymas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    laikas = table.Column<string>(nullable: false),
                    Tema = table.Column<string>(nullable: true),
                    fk_Mokytojas = table.Column<string>(nullable: true),
                    fk_Klase = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atsiskaitymas", x => x.Id_Atsiskaitymas);
                    table.ForeignKey(
                        name: "FK_Atsiskaitymas_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atsiskaitymas_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Destymas",
                columns: table => new
                {
                    fk_Klase = table.Column<int>(nullable: false),
                    fk_Mokytojas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Destymas_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Namu_Darbas",
                columns: table => new
                {
                    Id_Namu_darbas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(nullable: false),
                    Uzduotis = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    fk_Mokytojas = table.Column<string>(nullable: true),
                    fk_Klase = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namu_Darbas", x => x.Id_Namu_darbas);
                    table.ForeignKey(
                        name: "FK_Namu_Darbas_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Namu_Darbas_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pamoka",
                columns: table => new
                {
                    Id_Pamoka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    laikas = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Tema = table.Column<string>(nullable: false),
                    fk_Klase = table.Column<int>(nullable: false),
                    fk_Mokytojas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pamoka", x => x.Id_Pamoka);
                    table.ForeignKey(
                        name: "FK_Pamoka_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pamoka_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pazimys",
                columns: table => new
                {
                    Id_Pazimys = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ivertis = table.Column<int>(nullable: false),
                    Vertinimo_priezastis = table.Column<string>(nullable: true),
                    Komentaras = table.Column<string>(nullable: true),
                    fk_Mokytojas = table.Column<string>(nullable: true),
                    fk_Atsiskaitymas = table.Column<int>(nullable: true),
                    fk_Mokinys = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pazimys", x => x.Id_Pazimys);
                    table.ForeignKey(
                        name: "FK_Pazimys_Atsiskaitymas_fk_Atsiskaitymas",
                        column: x => x.fk_Atsiskaitymas,
                        principalTable: "Atsiskaitymas",
                        principalColumn: "Id_Atsiskaitymas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pazimys_Mokinys_fk_Mokinys",
                        column: x => x.fk_Mokinys,
                        principalTable: "Mokinys",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atsiskaitymas_fk_Klase",
                table: "Atsiskaitymas",
                column: "fk_Klase");

            migrationBuilder.CreateIndex(
                name: "IX_Atsiskaitymas_fk_Mokytojas",
                table: "Atsiskaitymas",
                column: "fk_Mokytojas");

            migrationBuilder.CreateIndex(
                name: "IX_Destymas_fk_Klase",
                table: "Destymas",
                column: "fk_Klase");

            migrationBuilder.CreateIndex(
                name: "IX_Destymas_fk_Mokytojas",
                table: "Destymas",
                column: "fk_Mokytojas");

            migrationBuilder.CreateIndex(
                name: "IX_Namu_Darbas_fk_Klase",
                table: "Namu_Darbas",
                column: "fk_Klase");

            migrationBuilder.CreateIndex(
                name: "IX_Namu_Darbas_fk_Mokytojas",
                table: "Namu_Darbas",
                column: "fk_Mokytojas");

            migrationBuilder.CreateIndex(
                name: "IX_Pamoka_fk_Klase",
                table: "Pamoka",
                column: "fk_Klase");

            migrationBuilder.CreateIndex(
                name: "IX_Pamoka_fk_Mokytojas",
                table: "Pamoka",
                column: "fk_Mokytojas");

            migrationBuilder.CreateIndex(
                name: "IX_Pazimys_fk_Atsiskaitymas",
                table: "Pazimys",
                column: "fk_Atsiskaitymas");

            migrationBuilder.CreateIndex(
                name: "IX_Pazimys_fk_Mokinys",
                table: "Pazimys",
                column: "fk_Mokinys");

            migrationBuilder.CreateIndex(
                name: "IX_Pazimys_fk_Mokytojas",
                table: "Pazimys",
                column: "fk_Mokytojas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destymas");

            migrationBuilder.DropTable(
                name: "Namu_Darbas");

            migrationBuilder.DropTable(
                name: "Pamoka");

            migrationBuilder.DropTable(
                name: "Pazimys");

            migrationBuilder.DropTable(
                name: "Atsiskaitymas");
        }
    }
}
