using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Model DTO-a za kreiranje kupca.
    /// </summary>
    public class KupacUpdateDTO
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        [Key]
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID lica.
        /// </summary>
        [Required]
        [ForeignKey("LiceDTO")]
        public Guid LiceID { get; set; }

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        [Required]
        [ForeignKey("OvlascenoLiceDTO")]
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required]
        [ForeignKey("JavnoNadmetanjeDTO")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Prioritet kupca.
        /// </summary>

        [Required]
        [MaxLength(30)]
        public string? Prioritet { get; set; }

        /// <summary>
        /// Lice ima/nema zabranu.
        /// </summary>
        [Required]
        public bool? ImaZabranu { get; set; }

        /// <summary>
        /// Datum pocetka zabrane.
        /// </summary>
        [Required]
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum zavrsetka zabrane.
        /// </summary>
        [Required]
        public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
        /// Broj kupovina kupca.
        /// </summary>
        [Required]
        public int? BrojKupovina { get; set; }
    }
}