using System.ComponentModel.DataAnnotations;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta kontakt osoba.
	/// </summary>
	public class KontaktOsobaEntity
	{
		public KontaktOsobaEntity() { }

		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		[Key]
		public Guid KontaktOsobaID { get; set; }

		/// <summary>
		/// Ime kontakt osobe.
		/// </summary>
		public string? Ime { get; set; }

		/// <summary>
		/// Prezime kontakt osobe.
		/// </summary>
		public string? Prezime { get; set; }

		/// <summary>
		/// Funkcija kontakt osobe.
		/// </summary>
		public string? Funkcija { get; set; }

		/// <summary>
		/// Telefon kontakt osobe.
		/// </summary>
		public string? Telefon { get; set; }
	}
}
