using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DokumentiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "InterniDokumenti",
                newName: "InterniDokumentID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "EksterniDokumenti",
                newName: "EksterniDokumentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterniDokumentID",
                table: "InterniDokumenti",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EksterniDokumentID",
                table: "EksterniDokumenti",
                newName: "ID");
        }
    }
}
