using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet kontakt osoba.
	/// </summary>
	public class KontaktOsobaUpdateDTO : IValidatableObject
	{
		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Kontakt osoba mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ID { get; set; } = null!;

		/// <summary>
		/// Ime kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Kontakt osoba mora da ima ime.")]
		[MaxLength(15, ErrorMessage = "Ime kontakt osobe ne sme da bude preko 15 karaktera.")]
		public string Ime { get; set; } = null!;

		/// <summary>
		/// Prezime kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Kontakt osoba mora da ima prezime.")]
		[MaxLength(15, ErrorMessage = "Prezime kontakt osobe ne sme da bude preko 15 karaktera.")]
		public string Prezime { get; set; } = null!;

		/// <summary>
		/// Telefon kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Kontakt osoba mora da ima telefon.")]
		[MinLength(9, ErrorMessage = "Telefon kontakt osobe mora da bude manji od 9 karaktera.")]
		[MaxLength(10, ErrorMessage = "Telefon kontakt osobe ne sme da bude preko 10 karaktera.")]
		public string Telefon { get; set; } = null!;

		/// <summary>
		/// Funkcija kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Kontakt osoba mora da ima funkciju.")]
		[MaxLength(25, ErrorMessage = "Funkcija kontakt osobe ne sme da bude preko 25 karaktera.")]
		public string Funkcija { get; set; } = null!;

		/// <summary>
		/// Validacija za model DTO-a za ažuriranje entiteta kontakt osoba.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Ime.Equals(Prezime))
				yield return new ValidationResult("Kontakt osoba ne može da ima isto ime i prezime.", new[] { "KontaktOsobaUpdateDTO" });
		}
	}
}
