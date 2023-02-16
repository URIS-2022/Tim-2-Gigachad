namespace KorisnikService.DTO
{
	/// <summary>
	/// Model DTO-a za korisnik entitet.
	/// </summary>
	public class KorisnikDTO
	{
		/// <summary>
		/// ID korisnika.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Korisnički naziv.
		/// </summary>
		public string? Naziv { get; set; }

		/// <summary>
		/// Hašovana lozinka korisnika.
		/// </summary>
		public string? Lozinka { get; set; }

		/// <summary>
		/// So korisnikove lozinke.
		/// </summary>
		public string? So { get; set; }

		/// <summary>
		/// Puno ime korisnika.
		/// </summary>
		public string? PunoIme { get; set; }

		/// <summary>
		/// Email korisnika.
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// Tip korisnika.
		/// </summary>
		public string? Tip { get; set; }
	}
}
