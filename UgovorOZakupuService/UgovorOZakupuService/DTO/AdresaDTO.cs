namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// DTO za adrese
    /// </summary>
    public class AdresaDTO
    {
        /// <summary>
		/// ID adrese.
		/// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Ulica i broj adrese.
        /// </summary>

        public string? UlicaBroj { get; set; }

        /// <summary>
        /// Mesto.
        /// </summary>

        public string? Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese.
        /// </summary>

        public int PostanskiBroj { get; set; }

        /// <summary>
        /// Država(E).
        /// </summary>

        public string? Drzava { get; set; }
    }
}
