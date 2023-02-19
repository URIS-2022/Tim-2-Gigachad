using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KupacService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prioritet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumZavrsetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BrojKupovina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
                });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacID", "BrojKupovina", "DatumPocetkaZabrane", "DatumZavrsetkaZabrane", "ImaZabranu", "LiceID", "OvlascenoLiceID", "Prioritet" },
                values: new object[,]
                {
                    { new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"), 20, null, null, false, new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"), new Guid("904bd8b6-e268-4ca8-89fb-ef2750a74e19"), "VLASNIKSISTEMAZANAVODNJAVANJE" },
                    { new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), 10, new DateTime(2005, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("16e85d49-9cdd-41a6-85bc-180932f68999"), new Guid("904bd8b6-e268-4ca8-89fb-ef2750a74e19"), "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR" },
                    { new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"), 50, null, null, false, new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"), new Guid("1e24bea9-7df2-4d14-b224-c76fd77536dd"), "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR" },
                    { new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"), new Guid("1e24bea9-7df2-4d14-b224-c76fd77536dd"), "VLASNIKSISTEMAZANAVODNJAVANJE" },
                    { new Guid("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"), 30, null, null, false, new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"), new Guid("faea6877-c81e-4829-987e-ea68d5aea752"), "VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupci");
        }
    }
}
