namespace OvlascenoLiceService.DTO
{
    /// <summary>
    /// Model DTO-a za entitet ovlasceno lice.
    /// </summary>
    public class OvlascenoLiceDTO
    {
        /// <summary>
        /// ID ovlascenog lica.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        public FizickoLiceDTO FizickoLice { get; set; } = null!;

        /// <summary>
        /// Adresa ovlascenog lica.
        /// </summary>
        public AdresaDTO Adresa { get; set; } = null!;

        /// <summary>
        /// Prvi telefon ovlascenog lica.
        /// </summary>
        public string Telefon1 { get; set; } = null!;

        /// <summary>
        /// Drugi telefon ovlascenog lica.
        /// </summary>
        public string? Telefon2 { get; set; }

        /// <summary>
        /// Email ovlascenog lica.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Broj računa ovlascenog lica.
        /// </summary>
        public string BrojRacuna { get; set; } = null!;
    }
}
