using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OvlascenoLice",
                table: "Lica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OvlascenoLice",
                table: "Lica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("16e85d49-9cdd-41a6-85bc-180932f68999"),
                column: "OvlascenoLice",
                value: false);

            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                column: "OvlascenoLice",
                value: false);

            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
                column: "OvlascenoLice",
                value: false);

            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"),
                column: "OvlascenoLice",
                value: false);

            migrationBuilder.UpdateData(
                table: "Lica",
                keyColumn: "ID",
                keyValue: new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"),
                column: "OvlascenoLice",
                value: false);
        }
    }
}
