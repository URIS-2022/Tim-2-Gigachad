using System.ComponentModel.DataAnnotations;

namespace KomisijaService.Models
{
    /// <summary>
    /// DTO za kreiranje komisije.
    /// </summary>
    public class KomisijaCreateDTO
    {
        /// <summary>
		/// ID 1. clana.
		/// </summary>
        [Required]
        public string Clan1ID { get; set; } = null!;

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        [Required]
        public string Clan2ID { get; set; } = null!;

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        [Required]
        public string Clan3ID { get; set; } = null!;

        /// <summary>
		/// ID 4. clana.
		/// </summary>
        public string? Clan4ID { get; set; }

        /// <summary>
		/// ID 5. clana.
		/// </summary>
        public string? Clan5ID { get; set; }

        /// <summary>
		/// ID predsednika.
		/// </summary>
        [Required]
        public string PredsednikID { get; set; } = null!;
    }
}
