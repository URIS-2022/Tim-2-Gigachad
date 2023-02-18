using System.ComponentModel.DataAnnotations;

namespace KorisnikService.Entities
{
	/// <summary>
	/// Model entiteta korisnik.
	/// </summary>
	public class KorisnikEntity
	{
		/// <summary>
		/// ID korisnika.
		/// </summary>
		[Key]
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Korisnički naziv.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima naziv.")]
		[MaxLength(15, ErrorMessage = "Naziv korisnika ne sme da bude preko 15 karaktera.")]
		public string Naziv { get; set; } = null!;

		/// <summary>
		/// Hašovana lozinka korisnika.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima lozinku.")]
		public string Lozinka { get; set; } = null!;

		/// <summary>
		/// So korisnikove lozinke.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima so korisničke lozinke.")]
		public string So { get; set; } = null!;

		/// <summary>
		/// Ime korisnika.
		/// </summary>
		[MaxLength(15, ErrorMessage = "Ime korisnika ne sme da bude preko 15 karaktera.")]
		public string? Ime { get; set; } = null;

		/// <summary>
		/// Prezime korisnika.
		/// </summary>
		[MaxLength(15, ErrorMessage = "Prezime korisnika ne sme da bude preko 15 karaktera.")]
		public string? Prezime { get; set; } = null;

		/// <summary>
		/// Email korisnika.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima email.")]
		[MaxLength(50, ErrorMessage = "Email korisnika ne sme da bude preko 50 karaktera.")]
		public string Email { get; set; } = null!;

		/// <summary>
		/// Tip korisnika.
		/// </summary>
		[Required(ErrorMessage = "Tip korisnika mora da bude: ADMIN, KOMISIJA, OPERATER, LICITANT.")]
		[MaxLength(10, ErrorMessage = "Tip korisnika mora da bude: ADMIN, KOMISIJA, OPERATER, LICITANT.")]
		public string Tip { get; set; } = null!;
	}
}
