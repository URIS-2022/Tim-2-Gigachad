﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UgovorOZakupuService.Entities;

#nullable disable

namespace UgovorOZakupuService.Migrations
{
    [DbContext(typeof(UgovorOZakupuContext))]
    [Migration("20230218204035_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UgovorOZakupuService.Entities.UgovorOZakupuEntity", b =>
                {
                    b.Property<Guid>("UgovorOZakupuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatumUgovora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeoParceleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DokumentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipGarancije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrajanjeUgovora")
                        .HasColumnType("int");

                    b.HasKey("UgovorOZakupuID");

                    b.ToTable("Ugovori");

                    b.HasData(
                        new
                        {
                            UgovorOZakupuID = new Guid("dc662e18-1bb0-4f43-bb36-b20eab32a292"),
                            DatumUgovora = new DateTime(2007, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeoParceleID = new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"),
                            DokumentID = new Guid("378ffff9-f997-4b7f-8c6e-c674918ef2e9"),
                            JavnoNadmetanjeID = new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                            KupacID = new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"),
                            TipGarancije = "JEMSTVO",
                            TrajanjeUgovora = 8
                        },
                        new
                        {
                            UgovorOZakupuID = new Guid("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"),
                            DatumUgovora = new DateTime(2007, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeoParceleID = new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"),
                            DokumentID = new Guid("c9c1ccd3-e953-490e-b69c-cf903d8758f9"),
                            JavnoNadmetanjeID = new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                            KupacID = new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
                            TipGarancije = "BANKARSKAGARANCIJA",
                            TrajanjeUgovora = 8
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
