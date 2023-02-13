namespace LiceService.Entities
{
	/// <summary>
	/// Predstavlja model korisnika za autentifikaciju.
	/// </summary>
	public class KorisnikEntity
	{
		/// <summary>
		/// ID korisnika.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Korisničko ime/naziv.
		/// </summary>
		public string Naziv { get; set; }

		/// <summary>
		/// Hašovana lozinka korisnika.
		/// </summary>
		public string Lozinka { get; set; }

		/// <summary>
		/// Salt = So korisnikove lozinke.
		/// </summary>
		public string So { get; set; }

		/// <summary>
		/// Ime korisnika.
		/// </summary>
		public string Ime { get; set; }

		/// <summary>
		/// Prezime korisnika.
		/// </summary>
		public string Prezime { get; set; }

		/// <summary>
		/// Email korisnika.
		/// </summary>
		public string Email { get; set; }
	}
}
