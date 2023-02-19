using System.ComponentModel.DataAnnotations;

namespace KomisijaService.Models
{
    public class KomisijaUpdateDTO
    {
        /// <summary>
		/// ID komisije.
		/// </summary>
        [Required]
        public string KomisijaID { get; set; }

        /// <summary>
		/// ID 1. clana.
		/// </summary>
        [Required]
        public string Clan1ID { get; set; }

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        [Required]
        public string Clan2ID { get; set; }

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        [Required]
        public string Clan3ID { get; set; }

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
        public string PredsednikID { get; set; }
    }
}
