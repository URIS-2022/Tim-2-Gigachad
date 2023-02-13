﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UplataService.Entities;

#nullable disable

namespace UplataService.Migrations
{
    [DbContext(typeof(UplataContext))]
    [Migration("20230213174927_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UplataService.Entities.UplataEntity", b =>
                {
                    b.Property<Guid>("UplataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Iznos")
                        .HasColumnType("int");

                    b.Property<Guid>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KursnaLista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PozivNaBroj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SvrhaUplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uplatilac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UplataID");

                    b.ToTable("Uplate");

                    b.HasData(
                        new
                        {
                            UplataID = new Guid("460f3547-d626-49d7-92c4-6f96ae3714e0"),
                            BrojRacuna = "005-417672-67",
                            DatumUplate = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 45000,
                            JavnoNadmetanjeID = new Guid("03b0680e-35b6-4449-9150-019b817d7cef"),
                            KupacID = new Guid("96e691db-3fee-44af-a0db-e51660b53bb4"),
                            KursnaLista = "???????",
                            PozivNaBroj = "73609",
                            SvrhaUplate = "Uplata na racun",
                            Uplatilac = "Pera Peric"
                        },
                        new
                        {
                            UplataID = new Guid("167ef647-33c2-466c-b777-5271365bffbd"),
                            BrojRacuna = "214-826330-03",
                            DatumUplate = new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Iznos = 1550,
                            JavnoNadmetanjeID = new Guid("43d6bc15-a674-4552-abee-f3c3360db11e"),
                            KupacID = new Guid("47dc24c8-b4d4-49f2-a995-ba38d944a2b2"),
                            KursnaLista = "???????",
                            PozivNaBroj = "18096",
                            SvrhaUplate = "Racun za Telenor",
                            Uplatilac = "Sima Simic"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
