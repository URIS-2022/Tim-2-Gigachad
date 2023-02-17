using System.ComponentModel.DataAnnotations;

namespace DeoParceleService.Entities
{
	/// <summary>
	/// Model realnog entiteta parcela.
	/// </summary>
	public class ParcelaEntity
	{
		/// <summary>
		/// ID parcele.
		/// </summary>
		[Key]
		public Guid ID { get; set; }

		/// <summary>
		/// Ukupna površina parcele.
		/// </summary>
		[Required]
		public decimal UkupnaPovrsina { get; set; } = 0!;

		/// <summary>
		/// Katastarska opština parcele.
		/// </summary>
		[Required]
		[MaxLength(15, ErrorMessage = "Parcela mora da ima katastarsku opštinu.")]
		public string KatastarskaOpstina { get; set; } = null!;
	}
}
