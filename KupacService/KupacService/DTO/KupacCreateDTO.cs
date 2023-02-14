using System.ComponentModel.DataAnnotations;

namespace KupacService.DTO
{
    /// <summary>
    /// Model DTO-a za kreiranje fizičkog lica.
    /// </summary>
    public class KupacCreateDTO
    {
        /// <summary>
        /// ID lica.
        /// </summary>
        [Required]
        public Guid LiceID { get; set; }

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        [Required]
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required]
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
