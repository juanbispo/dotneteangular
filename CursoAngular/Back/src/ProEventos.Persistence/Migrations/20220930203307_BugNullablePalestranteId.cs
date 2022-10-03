using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class BugNullablePalestranteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais");

            migrationBuilder.AlterColumn<int>(
                name: "PalestranteId",
                table: "RedesSociais",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais");

            migrationBuilder.AlterColumn<int>(
                name: "PalestranteId",
                table: "RedesSociais",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
