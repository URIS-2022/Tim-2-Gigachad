using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UplataService.Entities
{
    /// <summary>
    /// Model realnog entiteta lice.
    /// </summary>
    public class UplataEntity
    {
        public UplataEntity() { }

        /// <summary>
        /// ID lica.
        /// </summary>
        [Key]
        public Guid UplataID { get; set; }

        /// <summary>
        /// ID fizičkog lica lica.
        /// </summary>
        public Guid JavnoNadnmetanjeID { get; set; }

        /// <summary>
        /// ID pravnog lica lica.
        /// </summary>
        [ForeignKey("JavnoNadmetanjeDTO")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID adrese lica.
        /// </summary>
        [ForeignKey("KupacEntity")]
        public Guid BrojRacuna { get; set; }

        /// <summary>
        /// Telefon 1 lica.
        /// </summary>
        public string? PozivNaBroj { get; set; }

        /// <summary>
        /// Telefon 2 lica.
        /// </summary>
        public string? Iznos { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>
        public string? Uplatilac { get; set; }

        /// <summary>
        /// Broj računa lica.
        /// </summary>
        public string? SvrhaUplate { get; set; }

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>
        public bool? DatumUplate { get; set; }
    }
}