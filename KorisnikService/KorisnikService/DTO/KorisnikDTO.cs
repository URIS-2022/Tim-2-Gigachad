namespace KorisnikService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet korisnik.
	/// </summary>
	public class KorisnikDTO
	{
		/// <summary>
		/// ID korisnika.
		/// </summary>
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Korisnički naziv.
		/// </summary>
		public string Naziv { get; set; } = null!;

		/// <summary>
		/// Hašovana lozinka korisnika.
		/// </summary>
		public string Lozinka { get; set; } = null!;

		/// <summary>
		/// So korisnikove lozinke.
		/// </summary>
		public string So { get; set; } = null!;

		/// <summary>
		/// Puno ime korisnika.
		/// </summary>
		public string? PunoIme { get; set; } = null;

		/// <summary>
		/// Email korisnika.
		/// </summary>
		public string Email { get; set; } = null!;

		/// <summary>
		/// Tip korisnika.
		/// </summary>
		public string Tip { get; set; } = null!;
	}
}
