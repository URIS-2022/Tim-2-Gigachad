using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje lica.
	/// </summary>
	public class LiceUpdateDTO
	{
		/// <summary>
		/// ID lica.
		/// </summary>
		[Required]
		public Guid ID { get; set; }

		/// <summary>
		/// ID fizičkog lica.
		/// </summary>
		[Required]
		public Guid FizickoLiceID { get; set; }

		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		//[ForeignKey("PravnoLiceEntity")]
		//public Guid? PravnoLiceID { get; set; }

		/// <summary>
		/// ID adrese lica.
		/// </summary>
		//[Required]
		//public Guid AdresaID { get; set; }

		/// <summary>
		/// Telefon 1 lica.
		/// </summary>
		[Required]
		[MinLength(9)]
		[MaxLength(10)]
		public string? Tel1 { get; set; }

		/// <summary>
		/// Telefon 2 lica.
		/// </summary>
		[MinLength(9)]
		[MaxLength(10)]
		public string? Tel2 { get; set; }

		/// <summary>
		/// Email lica.
		/// </summary>
		[Required]
		[MaxLength(50)]
		public string? Email { get; set; }

		/// <summary>
		/// Broj računa lica.
		/// </summary>
		[Required]
		[MaxLength(20)]
		public string? BrojRacuna { get; set; }

		/// <summary>
		/// Da li je lice ovlašćeno lice.
		/// </summary>
		[Required]
		public bool OvlascenoLice { get; set; }
	}
}
