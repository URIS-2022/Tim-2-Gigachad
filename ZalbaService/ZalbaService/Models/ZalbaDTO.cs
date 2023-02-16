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
        public Guid ZalbaID { get; set; }

        /// <summary>
		/// ID kupca.
		/// </summary>
        public Guid KupacID { get; set; }

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        public string TipZalbe { get; set; }

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        public DateTime DatumPodnosenja { get; set; }

        /// <summary>
        /// Objašnjenje žalbe u vidu razloga i obrazloženja.
        /// </summary>
        public string Objasnjenje { get; set; }

        /// <summary>
		/// Status zalbe.
		/// </summary>
        public string StatusZalbe { get; set; }

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        public string RadnjaZalbe { get; set; }
    }
}
