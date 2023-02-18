using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Model realnog entiteta kupac.
    /// </summary>
    public class KupacEntity
    { 
        /// <summary>
        /// ID kupca.
        /// </summary>
        [Key]
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID lica.
        /// </summary>
        public Guid LiceID { get; set; }

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// Prioritet kupca.
        /// </summary>

        [Required(ErrorMessage = "Kupac mora da ima validan prioritet.")]
        [MaxLength(100, ErrorMessage = "Prioritet ne sme da bude preko 50 karaktera.")]
        public string Prioritet { get; set; } = null!; 

        /// <summary>
        /// Lice ima/nema zabranu.
        /// </summary>
        [Required(ErrorMessage = "Kupac mora da ima podatke podatke o zabrani.")]
        public bool ImaZabranu { get; set; } 

        /// <summary>
        /// Datum pocetka zabrane.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum zavrsetka zabrane.
        /// </summary>
        public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
        /// Broj kupovina kupca.
        /// </summary>
        [Required(ErrorMessage = "Kupac mora da ima podatke podatke o broju kupovina.")]
        public int BrojKupovina { get; set; } 
    }
}