using System.ComponentModel.DataAnnotations;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta kontakt osoba.
	/// </summary>
	public class KontaktOsobaEntity
	{
		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[Key]
		public Guid ID { get; set; }

		/// <summary>
		/// Ime kontakt osobe.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Ime { get; set; }

		/// <summary>
		/// Prezime kontakt osobe.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Prezime { get; set; }

		/// <summary>
		/// Funkcija kontakt osobe.
		/// </summary>
		[Required]
		[MaxLength(25)]
		public string? Funkcija { get; set; }

		/// <summary>
		/// Telefon kontakt osobe.
		/// </summary>
		[Required]
		[MaxLength(10)]
		public string? Telefon { get; set; }
	}
}
