using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JavnoNadmetanjeService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licitacija",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumLicitacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rok = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OgrnMaxPovrs = table.Column<int>(type: "int", nullable: false),
                    KorakCene = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanje",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitacijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeoParceleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipNadmetanja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opstina = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DatumNad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremePoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeKraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodZakupa = table.Column<int>(type: "int", nullable: false),
                    PocetnaCena = table.Column<int>(type: "int", nullable: false),
                    VisinaCene = table.Column<int>(type: "int", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    PrijavljeniKupci = table.Column<int>(type: "int", nullable: false),
                    Licitanti = table.Column<int>(type: "int", nullable: false),
                    Krug = table.Column<int>(type: "int", nullable: false),
                    StatusNadmetanja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_Licitacija_LicitacijaID",
                        column: x => x.LicitacijaID,
                        principalTable: "Licitacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Licitacija",
                columns: new[] { "ID", "DatumLicitacije", "KorakCene", "OgrnMaxPovrs", "Rok" },
                values: new object[,]
                {
                    { new Guid("01724de1-1281-4206-a9ee-a153ba559304"), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 17, new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 13, new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77eb8e4b-ede1-4825-8da2-72d14c2d7259"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 17, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "ID", "AdresaID", "BrojUcesnika", "DatumNad", "DeoParceleID", "IzlicitiranaCena", "Izuzeto", "Krug", "KupacID", "LicitacijaID", "Licitanti", "Opstina", "PeriodZakupa", "PocetnaCena", "PrijavljeniKupci", "StatusNadmetanja", "TipNadmetanja", "VisinaCene", "VremeKraj", "VremePoc" },
                values: new object[,]
                {
                    { new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"), new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), 95, new DateTime(2019, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"), 34000000, false, 5, new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"), new Guid("01724de1-1281-4206-a9ee-a153ba559304"), 39, "ZEDNIK", 28, 400000, 52, "DRUGI_KRUG_STARI", "OTVARANJE_ZATVORENIH_PONUDA", 45698, new DateTime(2019, 5, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), 95, new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"), 150000000, true, 7, new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), new Guid("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"), 32, "BIKOVO", 67, 1000000, 52, "PRVI_KRUG", "JAVNA_LICITACIJA", 92076, new DateTime(2022, 8, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 4, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"), new Guid("878100df-6973-4292-acb1-0c25b7ac2260"), 18, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dacea418-fdcc-4289-8a94-df82a7056c18"), 4900000, true, 3, new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"), new Guid("77eb8e4b-ede1-4825-8da2-72d14c2d7259"), 48, "DONJI_GRAD", 55, 45900, 71, "DRUGI_KRUG_NOVI", "JAVNA_LICITACIJA", 55942, new DateTime(2023, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 16, 7, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_LicitacijaID",
                table: "JavnoNadmetanje",
                column: "LicitacijaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnoNadmetanje");

            migrationBuilder.DropTable(
                name: "Licitacija");
        }
    }
}
