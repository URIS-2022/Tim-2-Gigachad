using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KupacService.DTO
{
    /// <summary>
    /// DTO za kupca.
    /// </summary>
    public class KupacDTO
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        public Guid KupacID { get; set; }

        /// <summary>
        /// ID lica kupca.
        /// </summary>
        public LiceDTO Lice { get; set; } = null!;

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        public OvlascenoLiceDTO OvlascenoLice { get; set; } = null!;

        /// <summary>
        /// Prioritet kupca.
        /// </summary>
        public string? Prioritet { get; set; } = null!;

        /// <summary>
        /// Kupac ima/nema zabranu.
        /// </summary>
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
        public int BrojKupovina { get; set; }
    }
}
