using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ID { get; set; }

		/// <summary>
		/// JMBG fizičkog lica.
		/// </summary>
		[Required]
		[MinLength(13)]
		[MaxLength(13)]
		public string JMBG { get; set; }

		/// <summary>
		/// Ime fizičkog lica.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string Ime { get; set; }

		/// <summary>
		/// Prezime fizičkog lica.
		/// </summary>
		[Required]
		[MaxLength(15)]
		public string Prezime { get; set; }
	}
}
