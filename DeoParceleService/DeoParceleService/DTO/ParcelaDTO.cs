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
		/// ID kupca.
		/// </summary>
		public KupacDTO Kupac { get; set; } = null!;

		/// <summary>
		/// Oznaka parcele.
		/// </summary>
		public string Oznaka { get; set; } = null!;

		/// <summary>
		/// Ukupna površina parcele.
		/// </summary>
		public int UkupnaPovrsina { get; set; } = 0!;

		/// <summary>
		/// Katastarska opština parcele.
		/// </summary>
		public string KatastarskaOpstina { get; set; } = null!;
	}
}
