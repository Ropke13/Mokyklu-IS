using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class zinutetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ArPerskaityta",
                table: "Zinutes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArPerskaityta",
                table: "Zinutes");
        }
    }
}
