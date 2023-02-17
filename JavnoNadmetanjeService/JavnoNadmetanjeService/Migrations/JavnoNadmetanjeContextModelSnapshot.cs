﻿// <auto-generated />
using System;
using JavnoNadmetanjeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JavnoNadmetanjeService.Migrations
{
    [DbContext(typeof(JavnoNadmetanjeContext))]
    partial class JavnoNadmetanjeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BrojUcesnika")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumNad")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeoParceleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("IzlicitiranaCena")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<bool?>("Izuzeto")
                        .HasColumnType("bit");

                    b.Property<int?>("Krug")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid>("LicitacijaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Licitanti")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid>("NajbKupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("NajboljaPonuda")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("Opstina")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("PeriodZakupaM")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<float?>("PocetnaCena")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int?>("PrijavljeniKupci")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("StatusNadmetanja")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("TipNadmetanja")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("VisinaCene")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("VremeKraj")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("VremePoc")
                        .IsRequired()
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("LicitacijaID");

                    b.ToTable("JavnoNadmetanje");

                    b.HasData(
                        new
                        {
                            ID = new Guid("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                            AdresaID = new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                            BrojUcesnika = 95,
                            DatumNad = new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeoParceleID = new Guid("3c4a2c04-b462-437f-a292-18247c84813b"),
                            IzlicitiranaCena = 1500000.0,
                            Izuzeto = true,
                            Krug = 7,
                            LicitacijaID = new Guid("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                            Licitanti = 32,
                            NajbKupacID = new Guid("a363038b-6f1c-4e8d-b618-4ae682c2b4eb"),
                            NajboljaPonuda = 13330.99,
                            Opstina = "BIKOVO",
                            PeriodZakupaM = 67,
                            PocetnaCena = 1000000f,
                            PrijavljeniKupci = 52,
                            StatusNadmetanja = "PRVI_KRUG",
                            TipNadmetanja = "JAVNA_LICITACIJA",
                            VisinaCene = 92076,
                            VremeKraj = new TimeSpan(0, 9, 37, 0, 0),
                            VremePoc = new TimeSpan(0, 8, 53, 0, 0)
                        },
                        new
                        {
                            ID = new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                            AdresaID = new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                            BrojUcesnika = 95,
                            DatumNad = new DateTime(2017, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeoParceleID = new Guid("d2ce90fa-a922-4cdd-9829-d48dd0981102"),
                            IzlicitiranaCena = 340000.0,
                            Izuzeto = false,
                            Krug = 5,
                            LicitacijaID = new Guid("01724de1-1281-4206-a9ee-a153ba559304"),
                            Licitanti = 39,
                            NajbKupacID = new Guid("b3bd4a59-1300-4335-8e9c-dd2e12b67d2a"),
                            NajboljaPonuda = 97930.990000000005,
                            Opstina = "ZEDNIK",
                            PeriodZakupaM = 28,
                            PocetnaCena = 400000f,
                            PrijavljeniKupci = 52,
                            StatusNadmetanja = "DRUGI_KRUG_STARI",
                            TipNadmetanja = "OTVARANJE_ZATVORENIH_PONUDA",
                            VisinaCene = 45698,
                            VremeKraj = new TimeSpan(0, 18, 27, 0, 0),
                            VremePoc = new TimeSpan(0, 16, 29, 0, 0)
                        },
                        new
                        {
                            ID = new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"),
                            AdresaID = new Guid("878100df-6973-4292-acb1-0c25b7ac2260"),
                            BrojUcesnika = 18,
                            DatumNad = new DateTime(2012, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeoParceleID = new Guid("9c3cfe25-8edb-4281-a125-adb93a942f4c"),
                            IzlicitiranaCena = 49000.0,
                            Izuzeto = true,
                            Krug = 3,
                            LicitacijaID = new Guid("01724de1-1281-4206-a9ee-a153ba559309"),
                            Licitanti = 48,
                            NajbKupacID = new Guid("24472931-dbff-4951-bbed-19f63e7ae19b"),
                            NajboljaPonuda = 53.189999999999998,
                            Opstina = "DONJI_GRAD",
                            PeriodZakupaM = 55,
                            PocetnaCena = 45900f,
                            PrijavljeniKupci = 71,
                            StatusNadmetanja = "DRUGI_KRUG_NOVI",
                            TipNadmetanja = "JAVNA_LICITACIJA",
                            VisinaCene = 55942,
                            VremeKraj = new TimeSpan(0, 10, 23, 0, 0),
                            VremePoc = new TimeSpan(0, 8, 32, 0, 0)
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.LicitacijaEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DatumLicitacije")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("KorakCene")
                        .HasColumnType("int");

                    b.Property<int>("OgrnMaxPovrs")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Rok")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Licitacija");

                    b.HasData(
                        new
                        {
                            ID = new Guid("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                            DatumLicitacije = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KorakCene = 15,
                            OgrnMaxPovrs = 13,
                            Rok = new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("01724de1-1281-4206-a9ee-a153ba559304"),
                            DatumLicitacije = new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KorakCene = 150,
                            OgrnMaxPovrs = 17,
                            Rok = new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeEntity", b =>
                {
                    b.HasOne("JavnoNadmetanjeService.Entities.LicitacijaEntity", "Licitacija")
                        .WithMany("JavnaNadmetanja")
                        .HasForeignKey("LicitacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Licitacija");
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.LicitacijaEntity", b =>
                {
                    b.Navigation("JavnaNadmetanja");
                });
#pragma warning restore 612, 618
        }
    }
}
