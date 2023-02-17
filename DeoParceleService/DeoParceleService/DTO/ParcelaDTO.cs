namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet fizičko lice.
	/// </summary>
	public class ParcelaDTO
	{
		/// <summary>
		/// ID parcele.
		/// </summary>
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Ukupna površina parcele.
		/// </summary>
		public decimal UkupnaPovrsina { get; set; } = 0!;

		/// <summary>
		/// Katastarska opština parcele.
		/// </summary>
		public string KatastarskaOpstina { get; set; } = null!;
	}
}
