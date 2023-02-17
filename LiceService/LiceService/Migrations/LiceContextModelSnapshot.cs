﻿// <auto-generated />
using System;
using LiceService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiceService.Migrations
{
    [DbContext(typeof(LiceContext))]
    partial class LiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiceService.Entities.FizickoLiceEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.ToTable("FizickaLica");

                    b.HasData(
                        new
                        {
                            ID = new Guid("32b7d397-b9d1-472d-bb40-542c68305098"),
                            Ime = "Slavomir",
                            JMBG = "4058851174218",
                            Prezime = "Slavic"
                        },
                        new
                        {
                            ID = new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"),
                            Ime = "Radomir",
                            JMBG = "0786741214886",
                            Prezime = "Radic"
                        },
                        new
                        {
                            ID = new Guid("ef4cf6d4-48f9-4508-a91f-330261325403"),
                            Ime = "Miladin",
                            JMBG = "0925639560129",
                            Prezime = "Milic"
                        },
                        new
                        {
                            ID = new Guid("08c019fa-a583-4ae2-bcd0-c1b56600b22c"),
                            Ime = "Milasin",
                            JMBG = "9195579483423",
                            Prezime = "Misic"
                        },
                        new
                        {
                            ID = new Guid("56ea3569-1897-4349-b79e-fccb5568231a"),
                            Ime = "Radasin",
                            JMBG = "6675836696997",
                            Prezime = "Rakic"
                        });
                });

            modelBuilder.Entity("LiceService.Entities.KontaktOsobaEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("KontaktOsobe");

                    b.HasData(
                        new
                        {
                            ID = new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"),
                            Funkcija = "Tehnicka Podrska",
                            Ime = "Svetlana",
                            Prezime = "Svetic",
                            Telefon = "9954225285"
                        },
                        new
                        {
                            ID = new Guid("5a2f51f9-3f5d-420f-9e98-510a3a5296a1"),
                            Funkcija = "Advokat",
                            Ime = "Dusanka",
                            Prezime = "Dusic",
                            Telefon = "0023309832"
                        });
                });

            modelBuilder.Entity("LiceService.Entities.LiceEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("FizickoLiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PravnoLiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefon1")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Telefon2")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("FizickoLiceID");

                    b.ToTable("Lica");

                    b.HasData(
                        new
                        {
                            ID = new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                            AdresaID = new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                            BrojRacuna = "343658891760636",
                            Email = "email1@net.org",
                            FizickoLiceID = new Guid("32b7d397-b9d1-472d-bb40-542c68305098"),
                            PravnoLiceID = new Guid("00000000-0000-0000-0000-000000000000"),
                            Telefon1 = "4211218533",
                            Telefon2 = "399461094"
                        },
                        new
                        {
                            ID = new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"),
                            AdresaID = new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                            BrojRacuna = "788066876873835",
                            Email = "email2@net.org",
                            FizickoLiceID = new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"),
                            PravnoLiceID = new Guid("00000000-0000-0000-0000-000000000000"),
                            Telefon1 = "377172253",
                            Telefon2 = "8048668952"
                        },
                        new
                        {
                            ID = new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"),
                            AdresaID = new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                            BrojRacuna = "801272932440773",
                            Email = "email3@net.org",
                            FizickoLiceID = new Guid("ef4cf6d4-48f9-4508-a91f-330261325403"),
                            PravnoLiceID = new Guid("006d992e-2109-4334-beff-3f5229129d14"),
                            Telefon1 = "4461663339",
                            Telefon2 = "4815540720"
                        },
                        new
                        {
                            ID = new Guid("16e85d49-9cdd-41a6-85bc-180932f68999"),
                            AdresaID = new Guid("878100df-6973-4292-acb1-0c25b7ac2260"),
                            BrojRacuna = "854823918379735",
                            Email = "email4@net.org",
                            FizickoLiceID = new Guid("08c019fa-a583-4ae2-bcd0-c1b56600b22c"),
                            PravnoLiceID = new Guid("9c236b62-afcf-4902-aba8-c159536883fb"),
                            Telefon1 = "2481909941",
                            Telefon2 = ""
                        },
                        new
                        {
                            ID = new Guid("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
                            AdresaID = new Guid("acba6d99-36a6-4688-af14-6b2bba85dcf1"),
                            BrojRacuna = "252614852215342",
                            Email = "email5@net.org",
                            FizickoLiceID = new Guid("56ea3569-1897-4349-b79e-fccb5568231a"),
                            PravnoLiceID = new Guid("5b4c99ef-49ae-4843-821b-488e968ca945"),
                            Telefon1 = "5528150968",
                            Telefon2 = ""
                        });
                });

            modelBuilder.Entity("LiceService.Entities.PravnoLiceEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KontaktOsobaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaticniBroj")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.HasIndex("KontaktOsobaID");

                    b.ToTable("PravnaLica");

                    b.HasData(
                        new
                        {
                            ID = new Guid("006d992e-2109-4334-beff-3f5229129d14"),
                            KontaktOsobaID = new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"),
                            MaticniBroj = "17818420",
                            Naziv = "ZLO DOO"
                        },
                        new
                        {
                            ID = new Guid("9c236b62-afcf-4902-aba8-c159536883fb"),
                            KontaktOsobaID = new Guid("1c188a84-dd2d-4ee2-beb9-b7d7fbc6a812"),
                            MaticniBroj = "52581514",
                            Naziv = "RAJ DOO"
                        },
                        new
                        {
                            ID = new Guid("5b4c99ef-49ae-4843-821b-488e968ca945"),
                            KontaktOsobaID = new Guid("5a2f51f9-3f5d-420f-9e98-510a3a5296a1"),
                            MaticniBroj = "88703765",
                            Naziv = "ZEMLJA DOO"
                        });
                });

            modelBuilder.Entity("LiceService.Entities.LiceEntity", b =>
                {
                    b.HasOne("LiceService.Entities.FizickoLiceEntity", "FizickoLice")
                        .WithMany("Lica")
                        .HasForeignKey("FizickoLiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FizickoLice");
                });

            modelBuilder.Entity("LiceService.Entities.PravnoLiceEntity", b =>
                {
                    b.HasOne("LiceService.Entities.KontaktOsobaEntity", "KontaktOsoba")
                        .WithMany("PravnaLica")
                        .HasForeignKey("KontaktOsobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KontaktOsoba");
                });

            modelBuilder.Entity("LiceService.Entities.FizickoLiceEntity", b =>
                {
                    b.Navigation("Lica");
                });

            modelBuilder.Entity("LiceService.Entities.KontaktOsobaEntity", b =>
                {
                    b.Navigation("PravnaLica");
                });
#pragma warning restore 612, 618
        }
    }
}
