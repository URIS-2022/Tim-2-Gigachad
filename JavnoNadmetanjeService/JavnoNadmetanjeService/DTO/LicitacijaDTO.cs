using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
	/// Model DTO-a za licitacija entitet.
	/// </summary>
    public class LicitacijaDTO
    {
        /// <summary>
		/// ID licitacije.
		/// </summary>
		public Guid ID { get; set; }

        /// <summary>
        /// Datum licitacije.
        /// </summary>
        public DateTime? DatumLicitacije { get; set; }

        /// <summary>
        /// Rok za dostavljanje prijava, datum i sat.
        /// </summary>
        public DateTime? Rok { get; set; } = null!;

        /// <summary>
        /// OgrnMaxPovrs licitacije.
        /// </summary>
        public string? OgrnMaxPovrs { get; set; }

        /// <summary>
        /// Korak cene licitacije.
        /// </summary>
        public int KorakCene { get; set; }
    }
}
