using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    /// <summary>
    /// Model DTO-a za entitet žalba.
    /// </summary>
    public class ZalbaDTO
    {
        /// <summary>
		/// ID zalbe.
		/// </summary>
        public Guid ZalbaID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID kupca.
		/// </summary>
        public KupacDTO Kupac { get; set; } = null!;

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        public string TipZalbe { get; set; } = null!;

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        public DateTime DatumPodnosenja { get; set; }

        /// <summary>
        /// Objašnjenje žalbe u vidu razloga i obrazloženja.
        /// </summary>
        public string Objasnjenje { get; set; } = null!;

        /// <summary>
		/// Status zalbe.
		/// </summary>
        public string StatusZalbe { get; set; } = null!;

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        public string RadnjaZalbe { get; set; } = null!;
    }
}
