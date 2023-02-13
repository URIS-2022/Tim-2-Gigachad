using System.ComponentModel.DataAnnotations;

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
		[Key]
		public Guid ID { get; set; }

		/// <summary>
		/// Korisničko ime/naziv.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Naziv { get; set; }

		/// <summary>
		/// Hašovana lozinka korisnika.
		/// </summary>
		[Required]
		[MaxLength(25)]
		public string? Lozinka { get; set; }

		/// <summary>
		/// Salt = So korisnikove lozinke.
		/// </summary>
		[Required]
		public string? So { get; set; }

		/// <summary>
		/// Ime korisnika.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Ime { get; set; }

		/// <summary>
		/// Prezime korisnika.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Prezime { get; set; }

		/// <summary>
		/// Email korisnika.
		/// </summary>
		[Required]
		[MaxLength(50)]
		public string? Email { get; set; }
	}
}
