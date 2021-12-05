using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class MoreTables : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Administratorius_fk_Registracija",
                table: "Administratorius",
                column: "fk_Registracija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratorius");

            migrationBuilder.DropTable(
                name: "Dalykas");

            migrationBuilder.DropTable(
                name: "Klase");

            migrationBuilder.DropTable(
                name: "Susirinkimas");

            migrationBuilder.DropTable(
                name: "Registracija");
        }
    }
}
