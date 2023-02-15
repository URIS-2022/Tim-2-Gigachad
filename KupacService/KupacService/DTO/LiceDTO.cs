using System.ComponentModel.DataAnnotations;

namespace KupacService.DTO
{
    /// <summary>
    /// Model DTO-a za lice.
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

        public Guid FizickoLiceID { get; set; }

        /// <summary>
        /// ID pravnog lica.
        /// </summary>
        //[ForeignKey("PravnoLiceEntity")]
        //public Guid? PravnoLiceID { get; set; }

        /// <summary>
        /// ID adrese lica.
        /// </summary>
        //[Required]
        //public Guid AdresaID { get; set; }

        /// <summary>
        /// Telefon 1 lica.
        /// </summary>

        [MaxLength(10)]
        public string? Tel1 { get; set; }

        /// <summary>
        /// Telefon 2 lica.
        /// </summary>

        public string? Tel2 { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>

        public string? Email { get; set; }

        /// <summary>
        /// Broj računa lica.
        /// </summary>

        public string? BrojRacuna { get; set; }

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>

        public bool OvlascenoLice { get; set; }
    }
}