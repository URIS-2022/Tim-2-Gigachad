using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeoParceleService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
	   /// <inheritdoc />
	   protected override void Up(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.CreateTable(
			 name: "Parcele",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Oznaka = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
				UkupnaPovrsina = table.Column<int>(type: "int", nullable: false),
				KatastarskaOpstina = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_Parcele", x => x.ID);
			 });

		  migrationBuilder.CreateTable(
			 name: "DeloviParcela",
			 columns: table => new
			 {
				ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				ParcelaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				RedniBroj = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
				Povrsina = table.Column<int>(type: "int", nullable: false),
				BrojNekretnina = table.Column<int>(type: "int", nullable: false),
				Obradivost = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
				Kultura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
				Klasa = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
				ZasticenaZona = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
				OblikSvojine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
				Odvodnjavanje = table.Column<bool>(type: "bit", nullable: false)
			 },
			 constraints: table =>
			 {
				table.PrimaryKey("PK_DeloviParcela", x => x.ID);
				table.ForeignKey(
				    name: "FK_DeloviParcela_Parcele_ParcelaID",
				    column: x => x.ParcelaID,
				    principalTable: "Parcele",
				    principalColumn: "ID",
				    onDelete: ReferentialAction.Cascade);
			 });

		  migrationBuilder.InsertData(
			 table: "Parcele",
			 columns: new[] { "ID", "KatastarskaOpstina", "KupacID", "Oznaka", "UkupnaPovrsina" },
			 values: new object[,]
			 {
				{ new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"), "STARI_GRAD", new Guid("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"), "91IZ1JDB21", 4774 },
				{ new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), "NOVI_GRAD", new Guid("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"), "I48QEJTUAW", 6054 }
			 });

		  migrationBuilder.InsertData(
			 table: "DeloviParcela",
			 columns: new[] { "ID", "BrojNekretnina", "Klasa", "Kultura", "KupacID", "OblikSvojine", "Obradivost", "Odvodnjavanje", "ParcelaID", "Povrsina", "RedniBroj", "ZasticenaZona" },
			 values: new object[,]
			 {
				{ new Guid("1c91f161-f4c2-4c58-ba74-ab143b0679ff"), 21, "VIII", "MOCVARE", new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"), "DRUSTVENA_SVOJINA", "OSTALO", false, new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), 685, "86657", "IV" },
				{ new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"), 15, "I", "NJIVE", new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "PRIVATNA_SVOJINA", "OBRADIVO", true, new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"), 923, "82075", "I" },
				{ new Guid("55fd9408-bf63-4113-89c7-8fa72bd1ed5e"), 29, "II", "VINOGRADI", new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"), "DRZAVNA_SVOJINA", "OBRADIVO", true, new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), 488, "85120", "I" },
				{ new Guid("5eb8c5d9-131f-4bba-a31b-b669bca69be3"), 26, "II", "VOCNJACI", new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"), "MESOVITA_SVOJINA", "OBRADIVO", true, new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), 564, "35683", "I" },
				{ new Guid("6c5fe5f2-5389-4022-ae48-6e905cca6c60"), 27, "II", "VOCNJACI", new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "PRIVATNA_SVOJINA", "OBRADIVO", true, new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), 440, "78398", "I" },
				{ new Guid("aaa2b53b-278d-4ceb-9992-f57bb8818773"), 24, "VIII", "MOCVARE", new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), "ZADRUZNA_SVOJINA", "OSTALO", false, new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"), 528, "53891", "IV" },
				{ new Guid("dacea418-fdcc-4289-8a94-df82a7056c18"), 13, "I", "NJIVE", new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"), "MESOVITA_SVOJINA", "OBRADIVO", true, new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"), 975, "32477", "I" },
				{ new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"), 10, "I", "NJIVE", new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "PRIVATNA_SVOJINA", "OBRADIVO", true, new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"), 805, "55907", "I" }
			 });

		  migrationBuilder.CreateIndex(
			 name: "IX_DeloviParcela_ParcelaID",
			 table: "DeloviParcela",
			 column: "ParcelaID");
	   }

	   /// <inheritdoc />
	   protected override void Down(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.DropTable(
			 name: "DeloviParcela");

		  migrationBuilder.DropTable(
			 name: "Parcele");
	   }
    }
}
