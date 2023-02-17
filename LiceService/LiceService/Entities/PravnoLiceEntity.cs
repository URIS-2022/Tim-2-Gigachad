using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta pravno lice.
	/// </summary>
	public class PravnoLiceEntity
	{
		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		[Key]
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[ForeignKey("KontaktOsoba")]
		public Guid KontaktOsobaID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Kontakt osoba.
		/// </summary>
		[Required(ErrorMessage = "Pravno lice mora da ima kontakt osobu.")]
		public KontaktOsobaEntity KontaktOsoba { get; set; } = null!;

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
