namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet ovlašćeno lice.
	/// </summary>
	public class OvlascenoLiceDTO
	{
		/// <summary>
		/// ID ovlašćenog lica.
		/// </summary>
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Fizičko lice.
		/// </summary>
		public FizickoLiceDTO FizickoLice { get; set; } = null!;

		/// <summary>
		/// Adresa ovlašćenog lica.
		/// </summary>
		public AdresaDTO Adresa { get; set; } = null!;

		/// <summary>
		/// Prvi telefon ovlašćenog lica.
		/// </summary>
		public string Telefon1 { get; set; } = null!;

		/// <summary>
		/// Drugi telefon ovlašćenog lica.
		/// </summary>
		public string? Telefon2 { get; set; } = null;

		/// <summary>
		/// Email ovlašćenog lica.
		/// </summary>
		public string Email { get; set; } = null!;

		/// <summary>
		/// Broj računa ovlašćenog lica.
		/// </summary>
		public string BrojRacuna { get; set; } = null!;
	}
}
