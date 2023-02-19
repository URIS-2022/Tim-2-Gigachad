using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KomisijaService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komisije",
                columns: table => new
                {
                    KomisijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clan1ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clan2ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clan3ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clan4ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Clan5ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PredsednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.KomisijaID);
                });

            migrationBuilder.InsertData(
                table: "Komisije",
                columns: new[] { "KomisijaID", "Clan1ID", "Clan2ID", "Clan3ID", "Clan4ID", "Clan5ID", "PredsednikID" },
                values: new object[,]
                {
                    { new Guid("9b49e647-2850-406f-9e97-6673dfeead19"), new Guid("11ab0865-2d07-4d36-8ed4-f0acb07125e2"), new Guid("beffaa0f-2933-46d3-b1bd-746e9cc4dd9e"), new Guid("b27d89c8-d41b-4357-bb59-65013d0ce874"), new Guid("fc3e799c-53e5-4f3d-b6f8-d4e53686b913"), new Guid("887414d4-c3d0-40f7-abdf-a24d41e4d6e5"), new Guid("dfbbec1a-0e37-49a1-bed0-47a5cbbb660f") },
                    { new Guid("bc3a0d53-1862-4fbc-bb4d-7892f4199e69"), new Guid("08f2f910-eb7a-4714-9ef5-0fd1a2d1e278"), new Guid("063fe8c0-8b16-4fd5-960b-b130310040b0"), new Guid("e5875a1b-e03f-4a46-b7c2-c6f09f696034"), new Guid("b9f30780-f2e6-4475-b66e-44c588a1a252"), new Guid("63a84cc9-0c15-4acd-b2ef-c3aa44a03f7e"), new Guid("c35086d8-62c0-4166-8457-463066c8c659") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisije");
        }
    }
}
