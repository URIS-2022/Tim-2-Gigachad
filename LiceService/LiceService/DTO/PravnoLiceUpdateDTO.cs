using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje entiteta pravno lice.
	/// </summary>
	public class PravnoLiceUpdateDTO
	{
		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		[Required(ErrorMessage = "Pravno lice mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ID { get; set; } = null!;

		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[Required(ErrorMessage = "Pravno lice mora da ima ID kontakt osobe.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string KontaktOsobaID { get; set; } = null!;

		/// <summary>
		/// Naziv pravnog lica.
		/// </summary>
		[Required(ErrorMessage = "Pravno lice mora da ima naziv.")]
		[MaxLength(25, ErrorMessage = "Naziv pravnog lica ne sme da bude preko 25 karaktera.")]
		public string Naziv { get; set; } = null!;

		/// <summary>
		/// Matični broj pravnog lica.
		/// </summary>
		[Required(ErrorMessage = "Pravno lice mora da ima matični broj.")]
		[MinLength(8, ErrorMessage = "Matični broj pravnog lica mora da ima 8 karaktera.")]
		[MaxLength(8, ErrorMessage = "Matični broj pravnog lica mora da ima 8 karaktera.")]
		public string MaticniBroj { get; set; } = null!;
	}
}
