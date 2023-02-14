using LiceService.Entities;
using System.Security.Cryptography;

namespace LiceService.Data
{
	/// <summary>
	/// Repozitorijum za entitet korisnik.
	/// </summary>
	public class KorisnikRepository : IKorisnikRepository
	{
		/// <summary>
		/// Lista korisnika.
		/// </summary>
		public static List<KorisnikEntity> Korisnici { get; set; } = new List<KorisnikEntity>();
		private readonly static int iterations = 1000;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public KorisnikRepository()
		{
			FillData();
		}

		/// <summary>
		/// Metoda koja upisuje testne podatke.
		/// </summary>
		private void FillData()
		{
			var temp = HashPassword("it19-2019");

			Korisnici.AddRange(new List<KorisnikEntity>
			{
				new KorisnikEntity
				{
					ID = Guid.Parse("25c5d21e-8791-4431-8311-0b3825215865"),
					Naziv = "it19-2019",
					Lozinka = temp.Item1,
					So = temp.Item2,
					Ime = "IT19",
					Prezime = "2019",
					Email = "rakic.it19.2019@uns.ac.rs"
				}
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

			var derivedBytes = new Rfc2898DeriveBytes(lozinka, sBytes, iterations);

			return new Tuple<string, string>
			(
			    Convert.ToBase64String(derivedBytes.GetBytes(256)),
			    salt
			);
		}

		/// <summary>
		/// Proverava da li postoji korisnik sa prosleđenim kredencijalima.
		/// </summary>
		/// <param name="naziv">Korisničko ime/naziv.</param>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <returns>Vraća boolean o potvrdi autentifikacije korisnika.</returns>
		public bool KorisnikWithCredentialsExists(string naziv, string lozinka)
		{
			KorisnikEntity? korisnik = Korisnici.FirstOrDefault(e => e.Naziv == naziv);
			if (korisnik == null)
				return false;
			if (korisnik != null)
				if (VerifyPassword(lozinka, korisnik.Lozinka, korisnik.So))
					return true;
			return false;
		}

		/// <summary>
		/// Proverava validnost prosleđene lozinke sa prosleđenim hašom i soli.
		/// </summary>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <param name="hash">Sačuvan haš.</param>
		/// <param name="so">Sačuvana so.</param>
		/// <returns>Vraća boolean o potvrdi validnosti lozinke.</returns>
		public bool VerifyPassword(string lozinka, string hash, string so)
		{
			var saltBytes = Convert.FromBase64String(so);
			var rfc2898DeriveBytes = new Rfc2898DeriveBytes(lozinka, saltBytes, iterations);
			if (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == hash)
				return true;
			return false;
		}
	}
}
