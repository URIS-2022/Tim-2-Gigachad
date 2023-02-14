namespace LiceService.DTO
{
	/// <summary>
	/// DTO za autentifikaciju korisnika.
	/// </summary>
	public class KorisnikDTO
	{
		/// <summary>
		/// Korisničko ime/naziv.
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// Korisnička lozinka.
		/// </summary>
		public string Lozinka { get; set; }
	}
}
