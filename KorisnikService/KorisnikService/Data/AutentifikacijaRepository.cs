using AutoMapper;
using KorisnikService.Entities;
using System.Security.Cryptography;
using static KorisnikService.Entities.EntitiesEnums;

namespace KorisnikService.Data
{
	/// <summary>
	/// Repozitorijum za entitet korisnik.
	/// </summary>
	public class AutentifikacijaRepository : IAutentifikacijaRepository
	{
		private readonly KorisnikContext context;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public AutentifikacijaRepository(KorisnikContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Proverava da li postoji korisnik sa prosleđenim kredencijalima.
		/// </summary>
		/// <param name="naziv">Korisničko naziv.</param>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <returns>Vraća boolean o potvrdi autentifikacije korisnika.</returns>
		public bool KorisnikWithCredentialsExists(string naziv, string lozinka)
		{
			KorisnikEntity? korisnik = context.Korisnici.FirstOrDefault(e => e.Naziv == naziv);
			if (korisnik == null)
				return false;
			if (korisnik.Lozinka != null && korisnik.So != null && VerifyPassword(lozinka, korisnik.Lozinka, korisnik.So))
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
			var rfc2898DeriveBytes = new Rfc2898DeriveBytes(lozinka, saltBytes, 1000);
			if (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == hash)
				return true;
			return false;
		}
	}
}
