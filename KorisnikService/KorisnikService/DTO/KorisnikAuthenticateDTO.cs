using System.ComponentModel.DataAnnotations;

namespace KorisnikService.DTO
{
	/// <summary>
	/// Model DTO-a za autentifikaciju korisnika.
	/// </summary>
	public class KorisnikAuthenticateDTO
	{
		/// <summary>
		/// Korisnički naziv.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima naziv.")]
		[MaxLength(15, ErrorMessage = "Naziv korisnika ne sme da bude preko 15 karaktera.")]
		public string? Naziv { get; set; } = null!;

		/// <summary>
		/// Korisnička lozinka.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima lozinku.")]
		[MaxLength(25, ErrorMessage = "Lozinka korisnika ne sme da bude preko 25 karaktera.")]
		public string? Lozinka { get; set; } = null!;
	}
}
