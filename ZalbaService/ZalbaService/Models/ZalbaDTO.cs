using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    public class ZalbaDTO
    {
        /// <summary>
		/// ID zalbe.
		/// </summary>
        [Required]
        public Guid ZalbaID { get; set; }

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        [Required]
        [MaxLength(50)]
        public string? TipZalbe { get; set; }

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        [Required]
        public DateTime? DatumPodnosenja { get; set; }

        [Required]
        public string? Objasnjenje { get; set; }
    }
}
