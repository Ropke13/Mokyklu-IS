using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class Tvarkarastis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tvarkarastis");
        }
    }
}
