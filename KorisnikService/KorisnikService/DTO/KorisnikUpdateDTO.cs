using System.ComponentModel.DataAnnotations;
using static KorisnikService.Entities.EntitiesEnums;

namespace KorisnikService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje entiteta korisnik.
	/// </summary>
	public class KorisnikUpdateDTO : IValidatableObject
	{
		/// <summary>
		/// ID korisnika.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ID { get; set; } = null!;

		/// <summary>
		/// Korisnički naziv.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima naziv.")]
		[MaxLength(15, ErrorMessage = "Naziv korisnika ne sme da bude preko 15 karaktera.")]
		public string Naziv { get; set; } = null!;

		/// <summary>
		/// Lozinka korisnika.
		/// </summary>
		[Required(ErrorMessage = "Korisnik mora da ima lozinku.")]
		[MaxLength(25, ErrorMessage = "Lozinka korisnika ne sme da bude preko 25 karaktera.")]
		public string Lozinka { get; set; } = null!;

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
		[Required(ErrorMessage = "Korisnik mora da ima tip.")]
		[MaxLength(10, ErrorMessage = "Tip korisnika mora da bude: ADMIN, KOMISIJA, OPERATER, LICITANT.")]
		public string Tip { get; set; } = null!;

		/// <summary>
		/// Validacija za model DTO-a za ažuriranje entiteta korisnik.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Ime != null && Prezime != null && Ime.Equals(Prezime))
				yield return new ValidationResult("Korisnik ne može da ima isto ime i prezime.", new[] { "KorisnikUpdateDTO" });

			if (Enum.TryParse(Tip.ToUpper(), out TipKorisnika tempTip))
				Tip = tempTip.ToString();
			else
				yield return new ValidationResult("Tip korisnika mora da bude: ADMIN, KOMISIJA, OPERATER, LICITANT.", new[] { "KorisnikUpdateDTO" });
		}
	}
}
