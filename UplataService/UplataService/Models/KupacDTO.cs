namespace UplataService.Models
{
    /// <summary>
	/// DTO za kupca.
	/// </summary>
    public class KupacDTO
    {
        /// <summary>
		/// ID lica.
		/// </summary>
		public Guid? LiceID { get; set; }

        /// <summary>
		/// ID ovlascenog lica.
		/// </summary>
		public Guid? OvlascenoLiceID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        public Guid? JavnoNadmetanjeID { get; set; }

        /// <summary>
		/// Prioritet.
		/// </summary>
		public string? Prioritet { get; set; }
        //Enumerator kako?

        /// <summary>
		/// Da li ima zabranu.
		/// </summary>
		public bool? ImaZabranu { get; set; }

        /// <summary>
        /// Datum pocetka zabrane.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
		/// Datum zavrsetka zabrane.
		/// </summary>
		public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
		/// Broj kupovina.
		/// </summary>
		public int? BrojKupovina { get; set; }
    }
}
