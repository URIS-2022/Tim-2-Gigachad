using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static KorisnikService.Entities.EntitiesEnums;

namespace KorisnikService.Entities
{
	/// <summary>
	/// DbContext za LiceService mikroservis.
	/// </summary>
	public class KorisnikContext : DbContext
	{	
		/// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public KorisnikContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// DbSet za entitet korisnik.
		/// </summary>
		public DbSet<KorisnikEntity> Korisnici { get; set; }

		/// <summary>
		/// Popunjava bazu sa inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			Tuple<string, string> hashLozinka = HashPassword("it19-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("25c5d21e-8791-4431-8311-0b3825215865"),
				Naziv = "it19-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Petar",
				Prezime = "Rakic",
				Email = "rakic.it19.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});

			hashLozinka = HashPassword("it20-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("12ac5ef6-a637-4e6b-9c5d-e2907933f60b"),
				Naziv = "it20-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Luka",
				Prezime = "Marinkovic",
				Email = "marinkovic.it20.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});

			hashLozinka = HashPassword("it23-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("ddcf1629-633e-46a9-a37f-40ace3f4a04a"),
				Naziv = "it23-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Vasilije",
				Prezime = "Mucibabic",
				Email = "mucibabic.it23.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});

			hashLozinka = HashPassword("it30-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("a0f34818-02ca-45fd-ad61-7978aebadd20"),
				Naziv = "it30-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Aleksandar",
				Prezime = "Peric",
				Email = "peric.it30.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});

			hashLozinka = HashPassword("it42-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("3ef835af-df00-49ff-b8f3-9a0e0a21af2d"),
				Naziv = "it42-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Elena",
				Prezime = "Dejanovic",
				Email = "dejanovic.it42.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});

			hashLozinka = HashPassword("it75-2019");

			builder.Entity<KorisnikEntity>().HasData(new
			{
				ID = Guid.Parse("24a02c12-485b-43ef-9ce2-4dd90ab26385"),
				Naziv = "it75-2019",
				Lozinka = hashLozinka.Item1,
				So = hashLozinka.Item2,
				Ime = "Milan",
				Prezime = "Maglov",
				Email = "maglov.it75.2019@uns.ac.rs",
				Tip = TipKorisnika.ADMIN.ToString()
			});
		}

		/// <summary>
		/// Vrši hašovanje lozinke.
		/// </summary>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <returns>Vraća generisani haš i so.</returns>
		private static Tuple<string, string> HashPassword(string lozinka)
		{
			var sBytes = new byte[lozinka.Length];
			RandomNumberGenerator.Create().GetNonZeroBytes(sBytes);
			var salt = Convert.ToBase64String(sBytes);

			var derivedBytes = new Rfc2898DeriveBytes(lozinka, sBytes, 1000);

			return new Tuple<string, string>
			(
			    Convert.ToBase64String(derivedBytes.GetBytes(256)),
			    salt
			);
		}
	}
}
