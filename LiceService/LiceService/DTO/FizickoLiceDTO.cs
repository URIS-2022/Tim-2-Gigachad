using System.ComponentModel.DataAnnotations;

namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za fizičko lice.
	/// </summary>
	public class FizickoLiceDTO
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
		/// Puno ime fizičkog lica.
		/// </summary>
		[Required]
		[MaxLength(30)]
		public string? PunoIme { get; set; }
	}
}
