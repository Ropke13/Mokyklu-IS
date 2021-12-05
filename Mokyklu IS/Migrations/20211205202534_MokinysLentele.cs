using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class MokinysLentele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mokinys",
                columns: table => new
                {
                    Asmens_kodas = table.Column<string>(nullable: false),
                    Vardas = table.Column<string>(nullable: false),
                    Pavarde = table.Column<string>(nullable: false),
                    Pamoku_sk = table.Column<int>(nullable: true),
                    Dalyku_sk = table.Column<int>(nullable: true),
                    GimimoData = table.Column<string>(nullable: true),
                    Telefono_nr = table.Column<string>(nullable: false),
                    fk_Tevas = table.Column<string>(nullable: true),
                    fk_Klase = table.Column<int>(nullable: true),
                    fk_Registracija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mokinys", x => x.Asmens_kodas);
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
                        principalColumn: "Asmens_kodas",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mokinys");
        }
    }
}
