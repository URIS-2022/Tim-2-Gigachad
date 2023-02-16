using Microsoft.EntityFrameworkCore;

namespace LiceService.Entities
{
	/// <summary>
	/// DbContext za LiceService mikroservis.
	/// </summary>
	public class LiceContext : DbContext
	{
		/// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public LiceContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// DbSet za entitet kontakt osoba.
		/// </summary>
		//public DbSet<KontaktOsobaEntity> KontaktOsobe { get; set; }

		/// <summary>
		/// DbSet za entitet pravno lice.
		/// </summary>
		//public DbSet<PravnoLiceEntity> PravnaLica { get; set; }

		/// <summary>
		/// DbSet za entitet fizičko lice.
		/// </summary>
		public DbSet<FizickoLiceEntity> FizickaLica { get; set; }

		/// <summary>
		/// DbSet za entitet lice.
		/// </summary>
		public DbSet<LiceEntity> Lica { get; set; }

		/// <summary>
		/// Popunjava bazu sa inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
				JMBG = "4058851174218",
				Ime = "Slavomir",
				Prezime = "Slavic"
			});
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
				JMBG = "0786741214886",
				Ime = "Radomir",
				Prezime = "Radic"
			});
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("ef4cf6d4-48f9-4508-a91f-330261325403"),
				JMBG = "0925639560129",
				Ime = "Miladin",
				Prezime = "Milic"
			});
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("08c019fa-a583-4ae2-bcd0-c1b56600b22c"),
				JMBG = "9195579483423",
				Ime = "Milasin",
				Prezime = "Misic"
			});
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("56ea3569-1897-4349-b79e-fccb5568231a"),
				JMBG = "6675836696997",
				Ime = "Radasin",
				Prezime = "Rakic"
			});

			builder.Entity<LiceEntity>().HasData(new
			{
				ID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
				FizickoLiceID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
				AdresaLicaID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
				Telefon1 = "4211218533",
				Telefon2 = "399461094",
				Email = "email1@net.org",
				BrojRacuna = "343658891760636",
				OvlascenoLice = false
			});
			builder.Entity<LiceEntity>().HasData(new
			{
				ID = Guid.Parse("92e0d8e9-b221-42a6-9bb8-a80974aee937"),
				FizickoLiceID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
				AdresaLicaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
				Telefon1 = "377172253",
				Telefon2 = "8048668952",
				Email = "email2@net.org",
				BrojRacuna = "788066876873835",
				OvlascenoLice = false
			});
			builder.Entity<LiceEntity>().HasData(new
			{
				ID = Guid.Parse("f127642e-4d73-42f1-979d-6a506aea9bdc"),
				FizickoLiceID = Guid.Parse("ef4cf6d4-48f9-4508-a91f-330261325403"),
				AdresaLicaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
				Telefon1 = "4461663339",
				Telefon2 = "4815540720",
				Email = "email3@net.org",
				BrojRacuna = "801272932440773",
				OvlascenoLice = false
			});
			builder.Entity<LiceEntity>().HasData(new
			{
				ID = Guid.Parse("16e85d49-9cdd-41a6-85bc-180932f68999"),
				FizickoLiceID = Guid.Parse("08c019fa-a583-4ae2-bcd0-c1b56600b22c"),
				AdresaLicaID = Guid.Parse("878100df-6973-4292-acb1-0c25b7ac2260"),
				Telefon1 = "2481909941",
				Telefon2 = "",
				Email = "email4@net.org",
				BrojRacuna = "854823918379735",
				OvlascenoLice = false
			});
			builder.Entity<LiceEntity>().HasData(new
			{
				ID = Guid.Parse("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
				FizickoLiceID = Guid.Parse("56ea3569-1897-4349-b79e-fccb5568231a"),
				AdresaLicaID = Guid.Parse("acba6d99-36a6-4688-af14-6b2bba85dcf1"),
				Telefon1 = "5528150968",
				Telefon2 = "",
				Email = "email5@net.org",
				BrojRacuna = "252614852215342",
				OvlascenoLice = false
			});
		}
	}
}
