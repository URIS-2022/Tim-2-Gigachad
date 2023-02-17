using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JavnoNadmetanjeService.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NajboljaPonuda",
                table: "JavnoNadmetanje");

            migrationBuilder.RenameColumn(
                name: "PeriodZakupaM",
                table: "JavnoNadmetanje",
                newName: "PeriodZakupa");

            migrationBuilder.AlterColumn<int>(
                name: "VisinaCene",
                table: "JavnoNadmetanje",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PocetnaCena",
                table: "JavnoNadmetanje",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "IzlicitiranaCena",
                table: "JavnoNadmetanje",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                columns: new[] { "IzlicitiranaCena", "PocetnaCena", "VisinaCene" },
                values: new object[] { 34000000, 400000, 45698 });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                columns: new[] { "IzlicitiranaCena", "PocetnaCena", "VisinaCene" },
                values: new object[] { 150000000, 1000000, 92076 });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                columns: new[] { "IzlicitiranaCena", "PocetnaCena", "VisinaCene" },
                values: new object[] { 4900000, 45900, 55942 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodZakupa",
                table: "JavnoNadmetanje",
                newName: "PeriodZakupaM");

            migrationBuilder.AlterColumn<decimal>(
                name: "VisinaCene",
                table: "JavnoNadmetanje",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PocetnaCena",
                table: "JavnoNadmetanje",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "IzlicitiranaCena",
                table: "JavnoNadmetanje",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "NajboljaPonuda",
                table: "JavnoNadmetanje",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                columns: new[] { "IzlicitiranaCena", "NajboljaPonuda", "PocetnaCena", "VisinaCene" },
                values: new object[] { 340000m, 97930.99m, 400000m, 45698m });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                columns: new[] { "IzlicitiranaCena", "NajboljaPonuda", "PocetnaCena", "VisinaCene" },
                values: new object[] { 1500000m, 13330.99m, 1000000m, 92076m });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                columns: new[] { "IzlicitiranaCena", "NajboljaPonuda", "PocetnaCena", "VisinaCene" },
                values: new object[] { 49000m, 53.19m, 45900m, 55942m });
        }
    }
}
