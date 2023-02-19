namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
    /// Model DTO-a za entitet lice.
    /// </summary>
    public class LiceDTO
    {
        /// <summary>
        /// ID lica.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        public FizickoLiceDTO FizickoLice { get; set; } = null!;

        /// <summary>
        /// ID pravnog lica.
        /// </summary>
        public PravnoLiceDTO? PravnoLice { get; set; }

        /// <summary>
        /// Adresa lica.
        /// </summary>
        public AdresaDTO Adresa { get; set; } = null!;

        /// <summary>
        /// Prvi telefon lica.
        /// </summary>
        public string Telefon1 { get; set; } = null!;

        /// <summary>
        /// Drugi telefon lica.
        /// </summary>
        public string? Telefon2 { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Broj računa lica.
        /// </summary>
        public string BrojRacuna { get; set; } = null!;

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>
        public bool OvlascenoLice { get; set; }
    }
}
