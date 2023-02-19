using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.Entities
{
    /// <summary>
	/// Model entiteta licitacija.
	/// </summary>
    public class LicitacijaEntity
    {
        /// <summary>
		/// ID licitacije.
		/// </summary>
		[Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Datum licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima datum.")]
        public DateTime? DatumLicitacije { get; set; } = null!;

        /// <summary>
        /// Rok za dostavljanje prijava, datum i sat.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima rok.")]
        public DateTime? Rok { get; set; } = null!;

        /// <summary>
        /// OgrnMaxPovrs licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima OgrnMaxPovrs.")]
        public int OgrnMaxPovrs { get; set; }

        /// <summary>
        /// Korak cene licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima korak cene.")]
        public int KorakCene { get; set; }

        /// <summary>
		/// Javna nadmetanja licitacije.
		/// </summary>
		public List<JavnoNadmetanjeEntity>? JavnaNadmetanja { get; set; }
    }
}
