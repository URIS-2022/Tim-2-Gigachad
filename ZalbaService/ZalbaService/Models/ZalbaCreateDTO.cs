using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    public class ZalbaCreateDTO
    {
        /// <summary>
		/// ID kupca.
		/// </summary>
        [Required]
        public Guid KupacID { get; set; }

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

        /// <summary>
		/// Razlog zalbe.
		/// </summary>
        [Required]
        [MaxLength(50)]
        public string? Razlog { get; set; }

        /// <summary>
		/// Obrazlozenje zalbe.
		/// </summary>
        [Required]
        [MaxLength(200)]
        public string? Obrazlozenje { get; set; }

        /// <summary>
		/// Status zalbe.
		/// </summary>
        [Required]
        [MaxLength(10)]
        public string? StatusZalbe { get; set; }

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        [Required]
        [MaxLength(50)]
        public string? RadnjaZalbe { get; set; }
    }
}
