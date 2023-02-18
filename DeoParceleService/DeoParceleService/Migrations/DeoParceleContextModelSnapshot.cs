﻿// <auto-generated />
using System;
using DeoParceleService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeoParceleService.Migrations
{
    [DbContext(typeof(DeoParceleContext))]
    partial class DeoParceleContextModelSnapshot : ModelSnapshot
    {
	   protected override void BuildModel(ModelBuilder modelBuilder)
	   {
#pragma warning disable 612, 618
		  modelBuilder
			 .HasAnnotation("ProductVersion", "7.0.3")
			 .HasAnnotation("Relational:MaxIdentifierLength", 128);

		  SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

		  modelBuilder.Entity("DeoParceleService.Entities.DeoParceleEntity", b =>
			 {
				b.Property<Guid>("ID")
				    .ValueGeneratedOnAdd()
				    .HasColumnType("uniqueidentifier");

				b.Property<int>("BrojNekretnina")
				    .HasColumnType("int");

				b.Property<string>("Klasa")
				    .IsRequired()
				    .HasMaxLength(4)
				    .HasColumnType("nvarchar(4)");

				b.Property<string>("Kultura")
				    .IsRequired()
				    .HasMaxLength(10)
				    .HasColumnType("nvarchar(10)");

				b.Property<Guid>("KupacID")
				    .HasColumnType("uniqueidentifier");

				b.Property<string>("OblikSvojine")
				    .IsRequired()
				    .HasMaxLength(20)
				    .HasColumnType("nvarchar(20)");

				b.Property<string>("Obradivost")
				    .IsRequired()
				    .HasMaxLength(8)
				    .HasColumnType("nvarchar(8)");

				b.Property<bool>("Odvodnjavanje")
				    .HasColumnType("bit");

				b.Property<Guid>("ParcelaID")
				    .HasColumnType("uniqueidentifier");

				b.Property<int>("Povrsina")
				    .HasColumnType("int");

				b.Property<string>("RedniBroj")
				    .IsRequired()
				    .HasMaxLength(5)
				    .HasColumnType("nvarchar(5)");

				b.Property<string>("ZasticenaZona")
				    .IsRequired()
				    .HasMaxLength(3)
				    .HasColumnType("nvarchar(3)");

				b.HasKey("ID");

				b.HasIndex("ParcelaID");

				b.ToTable("DeloviParcela");

				b.HasData(
				    new
				    {
					   ID = new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"),
					   BrojNekretnina = 10,
					   Klasa = "I",
					   Kultura = "NJIVE",
					   KupacID = new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
					   OblikSvojine = "PRIVATNA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"),
					   Povrsina = 805,
					   RedniBroj = "55907",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"),
					   BrojNekretnina = 15,
					   Klasa = "I",
					   Kultura = "NJIVE",
					   KupacID = new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
					   OblikSvojine = "PRIVATNA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"),
					   Povrsina = 923,
					   RedniBroj = "82075",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("dacea418-fdcc-4289-8a94-df82a7056c18"),
					   BrojNekretnina = 13,
					   Klasa = "I",
					   Kultura = "NJIVE",
					   KupacID = new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
					   OblikSvojine = "MESOVITA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"),
					   Povrsina = 975,
					   RedniBroj = "32477",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("6c5fe5f2-5389-4022-ae48-6e905cca6c60"),
					   BrojNekretnina = 27,
					   Klasa = "II",
					   Kultura = "VOCNJACI",
					   KupacID = new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
					   OblikSvojine = "PRIVATNA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   Povrsina = 440,
					   RedniBroj = "78398",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("5eb8c5d9-131f-4bba-a31b-b669bca69be3"),
					   BrojNekretnina = 26,
					   Klasa = "II",
					   Kultura = "VOCNJACI",
					   KupacID = new Guid("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
					   OblikSvojine = "MESOVITA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   Povrsina = 564,
					   RedniBroj = "35683",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("1c91f161-f4c2-4c58-ba74-ab143b0679ff"),
					   BrojNekretnina = 21,
					   Klasa = "VIII",
					   Kultura = "MOCVARE",
					   KupacID = new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"),
					   OblikSvojine = "DRUSTVENA_SVOJINA",
					   Obradivost = "OSTALO",
					   Odvodnjavanje = false,
					   ParcelaID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   Povrsina = 685,
					   RedniBroj = "86657",
					   ZasticenaZona = "IV"
				    },
				    new
				    {
					   ID = new Guid("55fd9408-bf63-4113-89c7-8fa72bd1ed5e"),
					   BrojNekretnina = 29,
					   Klasa = "II",
					   Kultura = "VINOGRADI",
					   KupacID = new Guid("93d92981-a754-41d8-8d1f-b5462a9e0386"),
					   OblikSvojine = "DRZAVNA_SVOJINA",
					   Obradivost = "OBRADIVO",
					   Odvodnjavanje = true,
					   ParcelaID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   Povrsina = 488,
					   RedniBroj = "85120",
					   ZasticenaZona = "I"
				    },
				    new
				    {
					   ID = new Guid("aaa2b53b-278d-4ceb-9992-f57bb8818773"),
					   BrojNekretnina = 24,
					   Klasa = "VIII",
					   Kultura = "MOCVARE",
					   KupacID = new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"),
					   OblikSvojine = "ZADRUZNA_SVOJINA",
					   Obradivost = "OSTALO",
					   Odvodnjavanje = false,
					   ParcelaID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   Povrsina = 528,
					   RedniBroj = "53891",
					   ZasticenaZona = "IV"
				    });
			 });

		  modelBuilder.Entity("DeoParceleService.Entities.ParcelaEntity", b =>
			 {
				b.Property<Guid>("ID")
				    .ValueGeneratedOnAdd()
				    .HasColumnType("uniqueidentifier");

				b.Property<string>("KatastarskaOpstina")
				    .IsRequired()
				    .HasMaxLength(20)
				    .HasColumnType("nvarchar(20)");

				b.Property<Guid>("KupacID")
				    .HasColumnType("uniqueidentifier");

				b.Property<string>("Oznaka")
				    .IsRequired()
				    .HasMaxLength(10)
				    .HasColumnType("nvarchar(10)");

				b.Property<int>("UkupnaPovrsina")
				    .HasColumnType("int");

				b.HasKey("ID");

				b.ToTable("Parcele");

				b.HasData(
				    new
				    {
					   ID = new Guid("06f51688-c60a-4dbf-8955-f1713fa47e28"),
					   KatastarskaOpstina = "STARI_GRAD",
					   KupacID = new Guid("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"),
					   Oznaka = "91IZ1JDB21",
					   UkupnaPovrsina = 4774
				    },
				    new
				    {
					   ID = new Guid("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
					   KatastarskaOpstina = "NOVI_GRAD",
					   KupacID = new Guid("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"),
					   Oznaka = "I48QEJTUAW",
					   UkupnaPovrsina = 6054
				    });
			 });

		  modelBuilder.Entity("DeoParceleService.Entities.DeoParceleEntity", b =>
			 {
				b.HasOne("DeoParceleService.Entities.ParcelaEntity", "Parcela")
				    .WithMany()
				    .HasForeignKey("ParcelaID")
				    .OnDelete(DeleteBehavior.Cascade)
				    .IsRequired();

				b.Navigation("Parcela");
			 });
#pragma warning restore 612, 618
	   }
    }
}