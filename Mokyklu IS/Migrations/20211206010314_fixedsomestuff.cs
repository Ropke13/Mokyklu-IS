using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class fixedsomestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dalykas",
                columns: table => new
                {
                    Id_Dalykas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: false),
                    Ar_isplestinis = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dalykas", x => x.Id_Dalykas);
                });

            migrationBuilder.CreateTable(
                name: "Klase",
                columns: table => new
                {
                    Id_Klase = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: false),
                    Metai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klase", x => x.Id_Klase);
                });

            migrationBuilder.CreateTable(
                name: "Registracija",
                columns: table => new
                {
                    Id_Registracija = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prisijungimo_vardas = table.Column<string>(nullable: false),
                    Slaptazodis = table.Column<string>(nullable: false),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Ar_patvirtinta = table.Column<bool>(nullable: false),
                    Telefono_nr = table.Column<string>(nullable: false),
                    Asmens_kodas = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registracija", x => x.Id_Registracija);
                });

            migrationBuilder.CreateTable(
                name: "Susirinkimas",
                columns: table => new
                {
                    Id_Susirinkimas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priezastis = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Laikas = table.Column<string>(nullable: false),
                    Kabinetas = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Susirinkimas", x => x.Id_Susirinkimas);
                });

            migrationBuilder.CreateTable(
                name: "Tvarkarastis",
                columns: table => new
                {
                    Id_Tvarkarastis = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pamoka = table.Column<string>(nullable: false),
                    Sav_Diena = table.Column<string>(nullable: false),
                    Laikas = table.Column<string>(nullable: false),
                    Klase = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tvarkarastis", x => x.Id_Tvarkarastis);
                });

            migrationBuilder.CreateTable(
                name: "Administratorius",
                columns: table => new
                {
                    Tabelio_nr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Telefono_nr = table.Column<string>(nullable: false),
                    fk_Registracija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratorius", x => x.Tabelio_nr);
                    table.ForeignKey(
                        name: "FK_Administratorius_Registracija_fk_Registracija",
                        column: x => x.fk_Registracija,
                        principalTable: "Registracija",
                        principalColumn: "Id_Registracija",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mokytojas",
                columns: table => new
                {
                    Id_Mokytojas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asmens_kodas = table.Column<string>(nullable: false),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Ar_pilnu_etatu = table.Column<bool>(nullable: true),
                    Pamoku_sk = table.Column<int>(nullable: true),
                    Telefono_nr = table.Column<string>(nullable: false),
                    fk_Registracija = table.Column<int>(nullable: false),
                    fk_Dalykas = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mokytojas", x => x.Id_Mokytojas);
                    table.ForeignKey(
                        name: "FK_Mokytojas_Dalykas_fk_Dalykas",
                        column: x => x.fk_Dalykas,
                        principalTable: "Dalykas",
                        principalColumn: "Id_Dalykas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mokytojas_Registracija_fk_Registracija",
                        column: x => x.fk_Registracija,
                        principalTable: "Registracija",
                        principalColumn: "Id_Registracija",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tevas",
                columns: table => new
                {
                    Id_Tevas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asmens_kodas = table.Column<string>(nullable: false),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Telefono_nr = table.Column<string>(nullable: false),
                    Vaiku_sk = table.Column<int>(nullable: true),
                    fk_Registracija = table.Column<int>(nullable: false),
                    fk_Susirinkimas = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tevas", x => x.Id_Tevas);
                    table.ForeignKey(
                        name: "FK_Tevas_Registracija_fk_Registracija",
                        column: x => x.fk_Registracija,
                        principalTable: "Registracija",
                        principalColumn: "Id_Registracija",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tevas_Susirinkimas_fk_Susirinkimas",
                        column: x => x.fk_Susirinkimas,
                        principalTable: "Susirinkimas",
                        principalColumn: "Id_Susirinkimas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atsiskaitymas",
                columns: table => new
                {
                    Id_Atsiskaitymas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    laikas = table.Column<string>(nullable: false),
                    Tema = table.Column<string>(nullable: true),
                    fk_Mokytojas = table.Column<int>(nullable: false),
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
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destymas",
                columns: table => new
                {
                    fk_Klase = table.Column<int>(nullable: true),
                    fk_Mokytojas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Destymas_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Cascade);
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
                    fk_Mokytojas = table.Column<int>(nullable: false),
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
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Cascade);
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
                    fk_Mokytojas = table.Column<int>(nullable: false)
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
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mokinys",
                columns: table => new
                {
                    Id_Mokinys = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asmens_kodas = table.Column<string>(nullable: false),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Pamoku_sk = table.Column<int>(nullable: true),
                    Dalyku_sk = table.Column<int>(nullable: true),
                    GimimoData = table.Column<string>(nullable: true),
                    Telefono_nr = table.Column<string>(nullable: false),
                    fk_Tevas = table.Column<int>(nullable: true),
                    fk_Klase = table.Column<int>(nullable: true),
                    fk_Registracija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mokinys", x => x.Id_Mokinys);
                    table.ForeignKey(
                        name: "FK_Mokinys_Klase_fk_Klase",
                        column: x => x.fk_Klase,
                        principalTable: "Klase",
                        principalColumn: "Id_Klase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mokinys_Registracija_fk_Registracija",
                        column: x => x.fk_Registracija,
                        principalTable: "Registracija",
                        principalColumn: "Id_Registracija",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mokinys_Tevas_fk_Tevas",
                        column: x => x.fk_Tevas,
                        principalTable: "Tevas",
                        principalColumn: "Id_Tevas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zinutes",
                columns: table => new
                {
                    Id_Zinutes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekstas = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    fk_Tevas = table.Column<int>(nullable: true),
                    fk_Mokytojas = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zinutes", x => x.Id_Zinutes);
                    table.ForeignKey(
                        name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zinutes_Tevas_fk_Tevas",
                        column: x => x.fk_Tevas,
                        principalTable: "Tevas",
                        principalColumn: "Id_Tevas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pastaba",
                columns: table => new
                {
                    Id_Pastaba = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekstas = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    fk_Mokytojas = table.Column<int>(nullable: true),
                    fk_Mokinys = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastaba", x => x.Id_Pastaba);
                    table.ForeignKey(
                        name: "FK_Pastaba_Mokinys_fk_Mokinys",
                        column: x => x.fk_Mokinys,
                        principalTable: "Mokinys",
                        principalColumn: "Id_Mokinys",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Id_Mokytojas",
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
                    fk_Mokytojas = table.Column<int>(nullable: true),
                    fk_Atsiskaitymas = table.Column<int>(nullable: true),
                    fk_Mokinys = table.Column<int>(nullable: true)
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
                        principalColumn: "Id_Mokinys",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                        column: x => x.fk_Mokytojas,
                        principalTable: "Mokytojas",
                        principalColumn: "Id_Mokytojas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administratorius_fk_Registracija",
                table: "Administratorius",
                column: "fk_Registracija");

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
                name: "IX_Mokinys_fk_Klase",
                table: "Mokinys",
                column: "fk_Klase");

            migrationBuilder.CreateIndex(
                name: "IX_Mokinys_fk_Registracija",
                table: "Mokinys",
                column: "fk_Registracija");

            migrationBuilder.CreateIndex(
                name: "IX_Mokinys_fk_Tevas",
                table: "Mokinys",
                column: "fk_Tevas");

            migrationBuilder.CreateIndex(
                name: "IX_Mokytojas_fk_Dalykas",
                table: "Mokytojas",
                column: "fk_Dalykas");

            migrationBuilder.CreateIndex(
                name: "IX_Mokytojas_fk_Registracija",
                table: "Mokytojas",
                column: "fk_Registracija");

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
                name: "IX_Pastaba_fk_Mokinys",
                table: "Pastaba",
                column: "fk_Mokinys");

            migrationBuilder.CreateIndex(
                name: "IX_Pastaba_fk_Mokytojas",
                table: "Pastaba",
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

            migrationBuilder.CreateIndex(
                name: "IX_Tevas_fk_Registracija",
                table: "Tevas",
                column: "fk_Registracija");

            migrationBuilder.CreateIndex(
                name: "IX_Tevas_fk_Susirinkimas",
                table: "Tevas",
                column: "fk_Susirinkimas");

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
                name: "Administratorius");

            migrationBuilder.DropTable(
                name: "Destymas");

            migrationBuilder.DropTable(
                name: "Namu_Darbas");

            migrationBuilder.DropTable(
                name: "Pamoka");

            migrationBuilder.DropTable(
                name: "Pastaba");

            migrationBuilder.DropTable(
                name: "Pazimys");

            migrationBuilder.DropTable(
                name: "Tvarkarastis");

            migrationBuilder.DropTable(
                name: "Zinutes");

            migrationBuilder.DropTable(
                name: "Atsiskaitymas");

            migrationBuilder.DropTable(
                name: "Mokinys");

            migrationBuilder.DropTable(
                name: "Mokytojas");

            migrationBuilder.DropTable(
                name: "Klase");

            migrationBuilder.DropTable(
                name: "Tevas");

            migrationBuilder.DropTable(
                name: "Dalykas");

            migrationBuilder.DropTable(
                name: "Registracija");

            migrationBuilder.DropTable(
                name: "Susirinkimas");
        }
    }
}
