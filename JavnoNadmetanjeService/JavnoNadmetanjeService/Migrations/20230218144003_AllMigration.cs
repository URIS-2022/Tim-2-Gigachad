using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JavnoNadmetanjeService.Migrations
{
    /// <inheritdoc />
    public partial class AllMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeoParceleID",
                table: "JavnoNadmetanje",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "KupacID",
                table: "JavnoNadmetanje",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                columns: new[] { "DatumNad", "DeoParceleID", "KupacID", "VremeKraj", "VremePoc" },
                values: new object[] { new DateTime(2019, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"), new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"), new DateTime(2019, 5, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                columns: new[] { "DeoParceleID", "KupacID", "VremeKraj", "VremePoc" },
                values: new object[] { new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"), new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), new DateTime(2022, 8, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 4, 8, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                columns: new[] { "DatumNad", "DeoParceleID", "KupacID", "VremeKraj", "VremePoc" },
                values: new object[] { new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dacea418-fdcc-4289-8a94-df82a7056c18"), new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"), new DateTime(2023, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 16, 7, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeoParceleID",
                table: "JavnoNadmetanje");

            migrationBuilder.DropColumn(
                name: "KupacID",
                table: "JavnoNadmetanje");

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                columns: new[] { "DatumNad", "VremeKraj", "VremePoc" },
                values: new object[] { new DateTime(2017, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                columns: new[] { "VremeKraj", "VremePoc" },
                values: new object[] { new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "JavnoNadmetanje",
                keyColumn: "ID",
                keyValue: new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                columns: new[] { "DatumNad", "VremeKraj", "VremePoc" },
                values: new object[] { new DateTime(2012, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
