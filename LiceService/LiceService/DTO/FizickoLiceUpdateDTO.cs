using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za kreiranje fizičkog lica.
	/// </summary>
	public class FizickoLiceUpdateDTO
	{
		/// <summary>
		/// ID fizičkog lica.
		/// </summary>
		[Required]
		public Guid ID { get; set; }

		/// <summary>
		/// JMBG fizičkog lica.
		/// </summary>
		[Required]
		[MinLength(13)]
		[MaxLength(13)]
		public string? JMBG { get; set; }

		/// <summary>
		/// Ime fizičkog lica.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Ime { get; set; }

		/// <summary>
		/// Prezime fizičkog lica.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string? Prezime { get; set; }
	}
}
