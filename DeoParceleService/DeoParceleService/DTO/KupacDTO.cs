namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za entitet kupca.
	/// </summary>
	public class KupacDTO
	{
		/// <summary>
		/// ID kupca.
		/// </summary>
		public Guid KupacID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Lice kupca.
		/// </summary>
		public LiceDTO Lice { get; set; } = null!;

		/// <summary>
		/// Ovlašćeno lice kupca.
		/// </summary>
		public OvlascenoLiceDTO OvlascenoLice { get; set; } = null!;

		/// <summary>
		/// Broj kupovina kupca.
		/// </summary>
		public int BrojKupovina { get; set; } = 0;

		/// <summary>
		/// Prioritet kupca.
		/// </summary>
		public string Prioritet { get; set; } = null!;

		/// <summary>
		/// Datum početka zabrane.
		/// </summary>
		public DateTime? DatumPocetkaZabrane { get; set; } = null!;

		/// <summary>
		/// Datum završetka zabrane.
		/// </summary>
		public DateTime? DatumZavrsetkaZabrane { get; set; } = null!;

		/// <summary>
		/// Kupac ima/nema zabranu.
		/// </summary>
		public bool ImaZabranu { get; set; } = false;
	}
}
