using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class MokytojasLentele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mokytojas",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_Mokytojas", x => x.Asmens_kodas);
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

            migrationBuilder.CreateIndex(
                name: "IX_Mokytojas_fk_Dalykas",
                table: "Mokytojas",
                column: "fk_Dalykas");

            migrationBuilder.CreateIndex(
                name: "IX_Mokytojas_fk_Registracija",
                table: "Mokytojas",
                column: "fk_Registracija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mokytojas");
        }
    }
}
