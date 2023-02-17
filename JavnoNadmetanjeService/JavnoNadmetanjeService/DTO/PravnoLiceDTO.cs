namespace JavnoNadmetanjeService.DTO
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
        public KontaktOsobaDTO KontaktOsoba { get; set; } = null!;

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
