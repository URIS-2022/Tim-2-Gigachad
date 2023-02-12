using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Entities
{
    public class LicitacijaEntity
    {
        /// <summary>
		/// ID licitacije.
		/// </summary>
		[Key]
        public Guid ID { get; set; }

        /// <summary>
		/// ID javnog nadmetanja.
		/// </summary>
		[ForeignKey("JavnoNadmetanjeEntity")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Datum licitacije.
        /// </summary>
        public string? DatumLicitacije { get; set; }

        /// <summary>
        /// Rok licitacije.
        /// </summary>
        public string? Rok { get; set; }

        /// <summary>
        /// OgrnMaxPovrs licitacije.
        /// </summary>
        public string? OgrnMaxPovrs { get; set; }

        /// <summary>
        /// Korak cene licitacije.
        /// </summary>
        public string? KorakCene { get; set; }
    }
}
