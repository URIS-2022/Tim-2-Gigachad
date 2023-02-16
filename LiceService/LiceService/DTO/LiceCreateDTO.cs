using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje lica.
	/// </summary>
	public class LiceCreateDTO : IValidatableObject
	{
		/// <summary>
		/// ID fizičkog lica.
		/// </summary>
		[Required(ErrorMessage = "Lice mora da ima ID fizičkog lica.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string FizickoLiceID { get; set; } = null!;

		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		//[ForeignKey("PravnoLiceEntity")]
		//public Guid? PravnoLiceID { get; set; }

		/// <summary>
		/// ID adrese lica.
		/// </summary>
		[Required(ErrorMessage = "Lice mora da ima ID adrese lica.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string AdresaLicaID { get; set; } = null!;

		/// <summary>
		/// Telefon 1 lica.
		/// </summary>
		[Required(ErrorMessage = "Lice mora da ima telefon jedan.")]
		[MinLength(9, ErrorMessage = "Telefon 1 lica mora da bude preko 9 karaktera.")]
		[MaxLength(10, ErrorMessage = "Telefon 1 lica ne sme da bude preko 10 karaktera.")]
		public string Telefon1 { get; set; } = null!;

		/// <summary>
		/// Telefon 2 lica.
		/// </summary>
		[MinLength(9, ErrorMessage = "Telefon 2 lica mora da bude preko 9 karaktera.")]
		[MaxLength(10, ErrorMessage = "Telefon 2 lica ne sme da bude preko 10 karaktera.")]
		public string? Telefon2 { get; set; }

		/// <summary>
		/// Email lica.
		/// </summary>
		[Required(ErrorMessage = "Lice mora da ima email.")]
		[MaxLength(50, ErrorMessage = "Email lica ne sme da bude preko 50 karaktera.")]
		public string Email { get; set; } = null!;

		/// <summary>
		/// Broj računa lica.
		/// </summary>
		[Required(ErrorMessage = "Lice mora da ima broj računa.")]
		[MaxLength(20, ErrorMessage = "Email lica ne sme da bude preko 20 karaktera.")]
		public string BrojRacuna { get; set; } = null!;

		/// <summary>
		/// Da li je lice ovlašćeno lice.
		/// </summary>
		[Required(ErrorMessage = "Da li je lice ovlašćeno lice mora biti definisano.")]
		public bool OvlascenoLice { get; set; }

		/// <summary>
		/// Validacija za model DTO-a za ažuriranje entiteta fizičko lice.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Telefon2 != null && Telefon1.Equals(Telefon2))
				yield return new ValidationResult("Lice ne može da ima isti telefon jedan i telefon dva.", new[] { "LiceCreateDTO" });
		}
	}
}
