using System.ComponentModel.DataAnnotations;

namespace LiceService.Entities
{
	/// <summary>
	/// Model realnog entiteta fizičko lice.
	/// </summary>
	public class FizickoLiceEntity
	{
		/// <summary>
		/// ID fizičkog lica.
		/// </summary>
		//[Key]
		public Guid ID { get; set; }

		/// <summary>
		/// JMBG fizičkog lica.
		/// </summary>
		public string? JMBG { get; set; }

		/// <summary>
		/// Ime fizičkog lica.
		/// </summary>
		public string? Ime { get; set; }

		/// <summary>
		/// Prezime fizičkog lica.
		/// </summary>
		public string? Prezime { get; set; }
	}
}
