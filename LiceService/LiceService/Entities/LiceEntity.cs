using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta lice.
	/// </summary>
	public class LiceEntity
	{
		public LiceEntity() { }

		/// <summary>
		/// ID lica.
		/// </summary>
		[Key]
		public Guid LiceID { get; set; }

		/// <summary>
		/// ID fizičkog lica lica.
		/// </summary>
		[ForeignKey("FizickoLiceEntity")]
		public Guid FizickoLiceID { get; set; }

		/// <summary>
		/// ID pravnog lica lica.
		/// </summary>
		[ForeignKey("PravnoLiceEntity")]
		public Guid PravnoLiceID { get; set; }

		/// <summary>
		/// ID adrese lica.
		/// </summary>
		[ForeignKey("AdresaLicaDTO")]
		public Guid AdresaID { get; set; }

		/// <summary>
		/// Telefon 1 lica.
		/// </summary>
		public string? Tel1 { get; set; }

		/// <summary>
		/// Telefon 2 lica.
		/// </summary>
		public string? Tel2 { get; set; }

		/// <summary>
		/// Email lica.
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// Broj računa lica.
		/// </summary>
		public string? BrojRacuna { get; set; }

		/// <summary>
		/// Da li je lice ovlašćeno lice.
		/// </summary>
		public bool? OvlascenoLice { get; set; }
	}
}
