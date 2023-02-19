using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
	   /// <inheritdoc />
	   protected override void Up(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.CreateTable(
			 name: "FizickaLica",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
				Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
				Prezime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_FizickaLica", x => x.ID);
			 });

		  migrationBuilder.CreateTable(
			 name: "KontaktOsobe",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
				Prezime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
				Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
				Funkcija = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_KontaktOsobe", x => x.ID);
			 });

		  migrationBuilder.CreateTable(
			 name: "Lica",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				FizickoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				PravnoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
				AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Telefon1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
				Telefon2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
				Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
				BrojRacuna = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_Lica", x => x.ID);
				table.ForeignKey(
				    name: "FK_Lica_FizickaLica_FizickoLiceID",
				    column: x => x.FizickoLiceID,
				    principalTable: "FizickaLica",
				    principalColumn: "ID",
				    onDelete: ReferentialAction.Cascade);
			 });

		  migrationBuilder.CreateTable(
			 name: "PravnaLica",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				KontaktOsobaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Naziv = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
				MaticniBroj = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_PravnaLica", x => x.ID);
				table.ForeignKey(
				    name: "FK_PravnaLica_KontaktOsobe_KontaktOsobaID",
				    column: x => x.KontaktOsobaID,
				    principalTable: "KontaktOsobe",
				    principalColumn: "ID",
				    onDelete: ReferentialAction.Cascade);
			 });

		  migrationBuilder.InsertData(
			 table: "FizickaLica",
			 columns: new[] { "ID", "Ime", "JMBG", "Prezime" },
			 values: new object[,]
			 {
				{ new Guid("08c019fa-a583-4ae2-bcd0-c1b56600b22c"), "Milasin", "9195579483423", "Misic" },
				{ new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), "Slavomir", "4058851174218", "Slavic" },
				{ new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), "Radomir", "0786741214886", "Radic" },
				{ new Guid("56ea3569-1897-4349-b79e-fccb5568231a"), "Radasin", "6675836696997", "Rakic" },
				{ new Guid("ef4cf6d4-48f9-4508-a91f-330261325403"), "Miladin", "0925639560129", "Milic" }
			 });

		  migrationBuilder.InsertData(
			 table: "KontaktOsobe",
			 columns: new[] { "ID", "Funkcija", "Ime", "Prezime", "Telefon" },
			 values: new object[,]
			 {
				{ new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"), "Tehnicka Podrska", "Svetlana", "Svetic", "9954225285" },
				{ new Guid("5a2f51f9-3f5d-420f-9e98-510a3a5296a1"), "Advokat", "Dusanka", "Dusic", "0023309832" }
			 });

		  migrationBuilder.InsertData(
			 table: "Lica",
			 columns: new[] { "ID", "AdresaID", "BrojRacuna", "Email", "FizickoLiceID", "PravnoLiceID", "Telefon1", "Telefon2" },
			 values: new object[,]
			 {
				{ new Guid("16e85d49-9cdd-41a6-85bc-180932f68999"), new Guid("878100df-6973-4292-acb1-0c25b7ac2260"), "854823918379735", "email4@net.org", new Guid("08c019fa-a583-4ae2-bcd0-c1b56600b22c"), new Guid("9c236b62-afcf-4902-aba8-c159536883fb"), "2481909941", "" },
				{ new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"), new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), "343658891760636", "email1@net.org", new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), new Guid("00000000-0000-0000-0000-000000000000"), "4211218533", "399461094" },
				{ new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"), new Guid("accad5a2-e5bc-4ff5-a5b7-fc38ab8a47fe"), "252614852215342", "email5@net.org", new Guid("56ea3569-1897-4349-b79e-fccb5568231a"), new Guid("5b4c99ef-49ae-4843-821b-488e968ca945"), "5528150968", "" },
				{ new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "788066876873835", "email2@net.org", new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), new Guid("00000000-0000-0000-0000-000000000000"), "377172253", "8048668952" },
				{ new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "801272932440773", "email3@net.org", new Guid("ef4cf6d4-48f9-4508-a91f-330261325403"), new Guid("006d992e-2109-4334-beff-3f5229129d14"), "4461663339", "4815540720" }
			 });

		  migrationBuilder.InsertData(
			 table: "PravnaLica",
			 columns: new[] { "ID", "KontaktOsobaID", "MaticniBroj", "Naziv" },
			 values: new object[,]
			 {
				{ new Guid("006d992e-2109-4334-beff-3f5229129d14"), new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"), "17818420", "ZLO DOO" },
				{ new Guid("5b4c99ef-49ae-4843-821b-488e968ca945"), new Guid("5a2f51f9-3f5d-420f-9e98-510a3a5296a1"), "88703765", "ZEMLJA DOO" },
				{ new Guid("9c236b62-afcf-4902-aba8-c159536883fb"), new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"), "52581514", "RAJ DOO" }
			 });

		  migrationBuilder.CreateIndex(
			 name: "IX_Lica_FizickoLiceID",
			 table: "Lica",
			 column: "FizickoLiceID");

		  migrationBuilder.CreateIndex(
			 name: "IX_PravnaLica_KontaktOsobaID",
			 table: "PravnaLica",
			 column: "KontaktOsobaID");
	   }

	   /// <inheritdoc />
	   protected override void Down(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.DropTable(
			 name: "Lica");

		  migrationBuilder.DropTable(
			 name: "PravnaLica");

		  migrationBuilder.DropTable(
			 name: "FizickaLica");

		  migrationBuilder.DropTable(
			 name: "KontaktOsobe");
	   }
    }
}
