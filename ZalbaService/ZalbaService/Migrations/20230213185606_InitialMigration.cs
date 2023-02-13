using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZalbaService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zalbe",
                columns: table => new
                {
                    ZalbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipZalbe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumPodnosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Razlog = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Obrazlozenje = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusZalbe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RadnjaZalbe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalbe", x => x.ZalbaID);
                });

            migrationBuilder.InsertData(
                table: "Zalbe",
                columns: new[] { "ZalbaID", "DatumPodnosenja", "KupacID", "Obrazlozenje", "RadnjaZalbe", "Razlog", "StatusZalbe", "TipZalbe" },
                values: new object[,]
                {
                    { new Guid("08635d18-5f72-4050-8e5e-c520562675b1"), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fb046e3b-a95c-4079-9898-9e16d653d9a3"), "Neko obrazlozenje", "JN ide u drugi krug sa novim uslovima", "Neki razlog", "Usvojena", "Zalba na tok javnog nadmetanaja" },
                    { new Guid("9014d78d-7b9b-4f63-b674-d83ed1d5356a"), new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f356c53-1dfb-48fa-93a1-18577d5db2b6"), "Neko drugo obrazlozenje", "JN ide u drugi krug sa starim uslovima", "Neki drugi razlog", "Otvorena", "Zalba na Odluku o davanju nakoriscenje" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalbe");
        }
    }
}
