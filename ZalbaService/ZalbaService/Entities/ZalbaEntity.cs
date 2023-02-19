using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZalbaService.Entities
{
    /// <summary>
    /// Model realnog entiteta žalba.
    /// </summary>
    public class ZalbaEntity
    {
        /// <summary>
		/// ID zalbe.
		/// </summary>
        [Key]
        public Guid ZalbaID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID kupca.
		/// </summary>
        [Required]
        public Guid KupacID { get; set; } = Guid.Empty!;

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        [Required(ErrorMessage = "Tip zalbe mora biti validan.")]
        [MaxLength(50, ErrorMessage = "Tip zalbe ne sme imati preko 50 karaktera.")]
        public string? TipZalbe { get; set; } = null!;

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        [Required]
        public DateTime? DatumPodnosenja { get; set; } = null!;

        /// <summary>
		/// Razlog zalbe.
		/// </summary>
        [Required]
        [MaxLength(50)]
        public string? Razlog { get; set; } = null!;

        /// <summary>
		/// Obrazlozenje zalbe.
		/// </summary>
        [Required]
        [MaxLength(200)]
        public string? Obrazlozenje { get; set; } = null!;

        /// <summary>
		/// Status zalbe.
		/// </summary>
        [Required(ErrorMessage = "Zalba mora imati status.")]
        [MaxLength(10, ErrorMessage = "Status ne sme imati preko 10 karaktera.")]
        public string? StatusZalbe { get; set; } = null!;

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        [Required(ErrorMessage = "Radnja mora biti validna.")]
        [MaxLength(50, ErrorMessage = "Radnja ne sme imati preko 50 karaktera.")]
        public string? RadnjaZalbe { get; set; } = null!;
    }
}
