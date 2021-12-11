using Microsoft.EntityFrameworkCore.Migrations;

namespace Mokyklu_IS.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiskaitymas_Mokytojas_fk_Mokytojas",
                table: "Atsiskaitymas");

            migrationBuilder.DropForeignKey(
                name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                table: "Destymas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mokinys_Tevas_fk_Tevas",
                table: "Mokinys");

            migrationBuilder.DropForeignKey(
                name: "FK_Namu_Darbas_Mokytojas_fk_Mokytojas",
                table: "Namu_Darbas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pamoka_Mokytojas_fk_Mokytojas",
                table: "Pamoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastaba_Mokinys_fk_Mokinys",
                table: "Pastaba");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                table: "Pastaba");

            migrationBuilder.DropForeignKey(
                name: "FK_Pazimys_Mokinys_fk_Mokinys",
                table: "Pazimys");

            migrationBuilder.DropForeignKey(
                name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                table: "Pazimys");

            migrationBuilder.DropForeignKey(
                name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                table: "Zinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Zinutes_Tevas_fk_Tevas",
                table: "Zinutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tevas",
                table: "Tevas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mokytojas",
                table: "Mokytojas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mokinys",
                table: "Mokinys");

            migrationBuilder.DropColumn(
                name: "Id_Tevas",
                table: "Tevas");

            migrationBuilder.DropColumn(
                name: "Id_Mokytojas",
                table: "Mokytojas");

            migrationBuilder.DropColumn(
                name: "Id_Mokinys",
                table: "Mokinys");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Tevas",
                table: "Zinutes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Zinutes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Tevas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Pazimys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokinys",
                table: "Pazimys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Pastaba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokinys",
                table: "Pastaba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Pamoka",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Namu_Darbas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Mokytojas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Tevas",
                table: "Mokinys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Mokinys",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Destymas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "fk_Mokytojas",
                table: "Atsiskaitymas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tevas",
                table: "Tevas",
                column: "Asmens_kodas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mokytojas",
                table: "Mokytojas",
                column: "Asmens_kodas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mokinys",
                table: "Mokinys",
                column: "Asmens_kodas");

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiskaitymas_Mokytojas_fk_Mokytojas",
                table: "Atsiskaitymas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                table: "Destymas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mokinys_Tevas_fk_Tevas",
                table: "Mokinys",
                column: "fk_Tevas",
                principalTable: "Tevas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Namu_Darbas_Mokytojas_fk_Mokytojas",
                table: "Namu_Darbas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pamoka_Mokytojas_fk_Mokytojas",
                table: "Pamoka",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastaba_Mokinys_fk_Mokinys",
                table: "Pastaba",
                column: "fk_Mokinys",
                principalTable: "Mokinys",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                table: "Pastaba",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pazimys_Mokinys_fk_Mokinys",
                table: "Pazimys",
                column: "fk_Mokinys",
                principalTable: "Mokinys",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                table: "Pazimys",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                table: "Zinutes",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zinutes_Tevas_fk_Tevas",
                table: "Zinutes",
                column: "fk_Tevas",
                principalTable: "Tevas",
                principalColumn: "Asmens_kodas",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiskaitymas_Mokytojas_fk_Mokytojas",
                table: "Atsiskaitymas");

            migrationBuilder.DropForeignKey(
                name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                table: "Destymas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mokinys_Tevas_fk_Tevas",
                table: "Mokinys");

            migrationBuilder.DropForeignKey(
                name: "FK_Namu_Darbas_Mokytojas_fk_Mokytojas",
                table: "Namu_Darbas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pamoka_Mokytojas_fk_Mokytojas",
                table: "Pamoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastaba_Mokinys_fk_Mokinys",
                table: "Pastaba");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                table: "Pastaba");

            migrationBuilder.DropForeignKey(
                name: "FK_Pazimys_Mokinys_fk_Mokinys",
                table: "Pazimys");

            migrationBuilder.DropForeignKey(
                name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                table: "Pazimys");

            migrationBuilder.DropForeignKey(
                name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                table: "Zinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Zinutes_Tevas_fk_Tevas",
                table: "Zinutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tevas",
                table: "Tevas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mokytojas",
                table: "Mokytojas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mokinys",
                table: "Mokinys");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Tevas",
                table: "Zinutes",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Zinutes",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Tevas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id_Tevas",
                table: "Tevas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Pazimys",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokinys",
                table: "Pazimys",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Pastaba",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokinys",
                table: "Pastaba",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Pamoka",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Namu_Darbas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Mokytojas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id_Mokytojas",
                table: "Mokytojas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Tevas",
                table: "Mokinys",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Asmens_kodas",
                table: "Mokinys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id_Mokinys",
                table: "Mokinys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Destymas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_Mokytojas",
                table: "Atsiskaitymas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tevas",
                table: "Tevas",
                column: "Id_Tevas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mokytojas",
                table: "Mokytojas",
                column: "Id_Mokytojas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mokinys",
                table: "Mokinys",
                column: "Id_Mokinys");

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiskaitymas_Mokytojas_fk_Mokytojas",
                table: "Atsiskaitymas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Destymas_Mokytojas_fk_Mokytojas",
                table: "Destymas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mokinys_Tevas_fk_Tevas",
                table: "Mokinys",
                column: "fk_Tevas",
                principalTable: "Tevas",
                principalColumn: "Id_Tevas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Namu_Darbas_Mokytojas_fk_Mokytojas",
                table: "Namu_Darbas",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pamoka_Mokytojas_fk_Mokytojas",
                table: "Pamoka",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastaba_Mokinys_fk_Mokinys",
                table: "Pastaba",
                column: "fk_Mokinys",
                principalTable: "Mokinys",
                principalColumn: "Id_Mokinys",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastaba_Mokytojas_fk_Mokytojas",
                table: "Pastaba",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pazimys_Mokinys_fk_Mokinys",
                table: "Pazimys",
                column: "fk_Mokinys",
                principalTable: "Mokinys",
                principalColumn: "Id_Mokinys",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pazimys_Mokytojas_fk_Mokytojas",
                table: "Pazimys",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zinutes_Mokytojas_fk_Mokytojas",
                table: "Zinutes",
                column: "fk_Mokytojas",
                principalTable: "Mokytojas",
                principalColumn: "Id_Mokytojas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zinutes_Tevas_fk_Tevas",
                table: "Zinutes",
                column: "fk_Tevas",
                principalTable: "Tevas",
                principalColumn: "Id_Tevas",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
