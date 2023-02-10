using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Model realnog entiteta lice.
    /// </summary>
    public class KupacEntity
    {
        public KupacEntity() { }

        /// <summary>
        /// ID lica.
        /// </summary>
        [Key]
        public Guid OvalscenoLiceID { get; set; }

        /// <summary>
        /// ID fizičkog lica lica.
        /// </summary>
        [ForeignKey("OvlascenoLiceDTO")]
        public Guid JavnoNadnmetanjeID { get; set; }

        /// <summary>
        /// ID pravnog lica lica.
        /// </summary>
        [ForeignKey("JavnoNadmetanjeDTO")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID adrese lica.
        /// </summary>
        public Guid LiceID { get; set; }

        /// <summary>
        /// Telefon 1 lica.
        /// </summary>
        [ForeignKey("AdresaLicaDTO")]
        public string? Prioritet { get; set; }

        /// <summary>
        /// Telefon 2 lica.
        /// </summary>
        public string? ImaZabranu { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>
        public string? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Broj računa lica.
        /// </summary>
        public string? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>
        public bool? BrojKupovina { get; set; }
    }
}