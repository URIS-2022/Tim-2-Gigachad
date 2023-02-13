using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Clan4ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clan5ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PredsednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.KomisijaID);
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
