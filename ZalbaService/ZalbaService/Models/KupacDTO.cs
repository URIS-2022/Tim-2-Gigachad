using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    /// <summary>
    /// DTO za kupca koji je podneo zalbu.
    /// </summary>
    public class KupacDTO
    {
        /// <summary>
		/// ID lice.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid LiceID { get; set; }

        /// <summary>
		/// ID ovlasceno lice.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
		/// ID javno nadmetanje.
		/// </summary>
        [ForeignKey("JavnoNadmetanjeDTO")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
		/// Prioritet javnog nadmetanja.
		/// </summary>
        public string? Prioritet { get; set; }

        /// <summary>
		/// Zabrana javnog nadmetanja.
		/// </summary>
        public Boolean? ImaZabranu { get; set; }

        /// <summary>
		/// Datum pocetka zabrane javnog nadmetanja.
		/// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
		/// Datum kraja zabrane javnog nadmetanja.
		/// </summary>
        public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
		/// Broj kupovina na javnom nadmetanju.
		/// </summary>
        public int? BrojKupovina { get; set; }
    }
}
