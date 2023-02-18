namespace KorisnikService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za autentifikaciju.
	/// </summary>
	public interface IAutentifikacijaRepository
	{
		/// <summary>
		/// Proverava da li postoji korisnik sa prosleđenim kredencijalima.
		/// </summary>
		/// <param name="naziv">Korisničko ime/naziv.</param>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <returns>Vraća boolean o potvrdi autentifikacije korisnika.</returns>
		public bool KorisnikWithCredentialsExists(string naziv, string lozinka);
	}
}
