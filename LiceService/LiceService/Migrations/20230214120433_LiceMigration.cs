﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class LiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KontaktOsobe",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
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
                    Tel1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OvlascenoLice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lica", x => x.ID);
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
                });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "ID", "BrojRacuna", "Email", "FizickoLiceID", "OvlascenoLice", "Tel1", "Tel2" },
                values: new object[,]
                {
                    { new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"), "123134132", "email1@net.org", new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), true, "4211218533", "399461094" },
                    { new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"), "132423425", "email2@net.org", new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), false, "377172253", "8048668952" },
                    { new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"), "123235243123", "email3@net.org", new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), false, "4461663339", "4815540720" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontaktOsobe");

            migrationBuilder.DropTable(
                name: "Lica");

            migrationBuilder.DropTable(
                name: "PravnaLica");
        }
    }
}
