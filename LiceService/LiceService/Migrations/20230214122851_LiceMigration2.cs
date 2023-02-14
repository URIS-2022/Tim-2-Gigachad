using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class LiceMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lica_FizickoLiceID",
                table: "Lica",
                column: "FizickoLiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lica_FizickaLica_FizickoLiceID",
                table: "Lica",
                column: "FizickoLiceID",
                principalTable: "FizickaLica",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lica_FizickaLica_FizickoLiceID",
                table: "Lica");

            migrationBuilder.DropIndex(
                name: "IX_Lica_FizickoLiceID",
                table: "Lica");
        }
    }
}
