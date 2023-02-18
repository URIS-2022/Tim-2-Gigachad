using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigratio15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
                column: "AdresaID",
                value: new Guid("accad5a2-e5bc-4ff5-a5b7-fc38ab8a47fe"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
                column: "AdresaID",
                value: new Guid("acba6d99-36a6-4688-af14-6b2bba85dcf1"));
        }
    }
}
