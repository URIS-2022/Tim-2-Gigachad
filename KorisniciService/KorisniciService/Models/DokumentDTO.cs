namespace KorisniciService.Models
{
    /// <summary>
	/// DTO za dokument.
	/// </summary>
    public class DokumentDTO
    {
        /// <summary>
		/// ID internog dokumenta.
		/// </summary>
		public Guid? InterniDokumentID { get; set; }

        /// <summary>
        /// ID eksternog dokumenta.
        /// </summary>
        public Guid? EksterniDokumentID { get; set; }

        /// <summary>
		/// Datum donosenja dokumenta.
		/// </summary>
		public DateTime? DatumDonosenja { get; set; }

        /// <summary>
		/// Status dokumenta.
		/// </summary>
		public string? StatusDokumenta { get; set; }
        //Enumerator kako?

        /// <summary>
		/// Sablon.
		/// </summary>
		public string? Sablon { get; set; }
        //Enumerator kako?

    }
}
