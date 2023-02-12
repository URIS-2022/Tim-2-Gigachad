using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta pravno lice.
	/// </summary>
	public class PravnoLiceEntity
	{
		public PravnoLiceEntity() { }

		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		[Key]
		public Guid ID { get; set; }

		/// <summary>
		/// ID kontakt osobe pravnog lica.
		/// </summary>
		[ForeignKey("KontaktOsobaEntity")]
		public Guid KontaktOsobaID { get; set; }

		/// <summary>
		/// Naziv pravnog lica.
		/// </summary>
		public string? Naziv { get; set; }

		/// <summary>
		/// Matični broj pravnog lica.
		/// </summary>
		public string? MaticniBroj { get; set; }
	}
}
