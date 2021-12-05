using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class TevasLentele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tevas",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_Tevas", x => x.Asmens_kodas);
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

            migrationBuilder.CreateIndex(
                name: "IX_Tevas_fk_Registracija",
                table: "Tevas",
                column: "fk_Registracija");

            migrationBuilder.CreateIndex(
                name: "IX_Tevas_fk_Susirinkimas",
                table: "Tevas",
                column: "fk_Susirinkimas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tevas");
        }
    }
}
