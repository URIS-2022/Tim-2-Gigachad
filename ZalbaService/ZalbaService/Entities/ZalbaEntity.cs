using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZalbaService.Entities
{
    public class ZalbaEntity
    {
        public ZalbaEntity() { }

        /// <summary>
		/// ID zalbe.
		/// </summary>
        [Key]
        public Guid ZalbaID { get; set; }

        /// <summary>
		/// ID kupca.
		/// </summary>
        [Required]
        public Guid KupacID { get; set; }

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        [Required(ErrorMessage = "Tip zalbe mora biti validan.")]
        [MaxLength(50, ErrorMessage = "Tip zalbe ne sme imati preko 50 karaktera.")]
        public string? TipZalbe { get; set;}

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
        [Required(ErrorMessage = "Zalba mora imati status.")]
        [MaxLength(10, ErrorMessage = "Status ne sme imati preko 10 karaktera.")]
        public string? StatusZalbe { get; set; }

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        [Required(ErrorMessage = "Radnja mora biti validna.")]
        [MaxLength(50, ErrorMessage = "Radnja ne sme imati preko 50 karaktera.")]
        public string? RadnjaZalbe { get; set; }
    }
}
