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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID adrese lica.
        /// </summary>
        [Required]
        //[ForeignKey("LiceDTO")]
        public Guid LiceID { get; set; }

        /// <summary>
        /// Telefon 1 lica.
        /// </summary>
        [Required]
        //[ForeignKey("OvlascenoLiceDTO")]
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// ID fizičkog lica lica.
        /// </summary>
        [Required]
        //[ForeignKey("JavnoNadmetanjeDTO")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// ID pravnog lica lica.
        /// </summary>

        [Required]
        [MaxLength(30)]
        public string? Prioritet { get; set; }

        /// <summary>
        /// Telefon 2 lica.
        /// </summary>
        [Required]
        public bool? ImaZabranu { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>
        [Required]
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Broj računa lica.
        /// </summary>
        [Required]
        public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>\
        [Required]
        public int? BrojKupovina { get; set; }
    }
}