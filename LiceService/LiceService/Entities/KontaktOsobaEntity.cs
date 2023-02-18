using System.ComponentModel.DataAnnotations;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta fizičko lice.
	/// </summary>
	public class KontaktOsobaEntity
	{
		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[Key]
		public Guid ID { get; set; } = Guid.Empty!;

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
		/// Lica fizičkih lica.
		/// </summary>
		public List<PravnoLiceEntity>? PravnaLica { get; set; } = null;
	}
}
