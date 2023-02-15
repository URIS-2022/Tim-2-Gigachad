using System.ComponentModel.DataAnnotations;

namespace KomisijaService.Models
{
    public class KomisijaCreateDTO
    {
        /// <summary>
		/// ID 1. clana.
		/// </summary>
        [Required]
        public Guid Clan1ID { get; set; }

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        [Required]
        public Guid Clan2ID { get; set; }

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        [Required]
        public Guid Clan3ID { get; set; }

        /// <summary>
		/// ID 4. clana.
		/// </summary>
        public Guid Clan4ID { get; set; }

        /// <summary>
		/// ID 5. clana.
		/// </summary>
        public Guid Clan5ID { get; set; }

        /// <summary>
		/// ID predsednika.
		/// </summary>
        [Required]
        public Guid PredsednikID { get; set; }
    }
}
