namespace LiceService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet pravno lice.
	/// </summary>
	public class PravnoLiceDTO
	{
		/// <summary>
		/// ID pravnog lica.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// ID kontakt osobe.
		/// </summary>
		public Guid KontaktOsobaID { get; set; }

		/// <summary>
		/// Naziv pravnog lica.
		/// </summary>
		public string Naziv { get; set; } = null!;

		/// <summary>
		/// Matični broj pravnog lica.
		/// </summary>
		public string MaticniBroj { get; set; } = null!;
	}
}
