namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet adresa lica.
	/// </summary>
	public class AdresaDTO
	{
		/// <summary>
		/// ID adrese.
		/// </summary>
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Ulica i broj adrese.
		/// </summary>
		public string UlicaBroj { get; set; } = null!;

		/// <summary>
		/// Mesto adrese.
		/// </summary>
		public string Mesto { get; set; } = null!;

		/// <summary>
		/// Poštanski broj adrese.
		/// </summary>
		public int PostanskiBroj { get; set; } = 0!;

		/// <summary>
		/// Država adrese.
		/// </summary>
		public string Drzava { get; set; } = null!;
	}
}
