using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomisijaService.Entities
{
    /// <summary>
    /// Model realnog entiteta komisija.
    /// </summary>
    public class KomisijaEntity
    {
        /// <summary>
		/// ID komisije.
		/// </summary>
        [Key]
        public Guid KomisijaID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID 1. clana.
		/// </summary>
        [Required(ErrorMessage = "Mora imati prvog clana")]
        public Guid Clan1ID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        [Required(ErrorMessage = "Mora imati drugog clana")]
        public Guid Clan2ID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        [Required(ErrorMessage = "Mora imati treceg clana")]
        public Guid Clan3ID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID 4. clana.
		/// </summary>
        public Guid? Clan4ID { get; set; } = null;

        /// <summary>
		/// ID 5. clana.
		/// </summary>
        public Guid? Clan5ID { get; set; } = null;

        /// <summary>
		/// ID predsednika.
		/// </summary>
        [Required(ErrorMessage = "Mora imati predsednika")]
        public Guid PredsednikID { get; set; } = Guid.Empty!;

    }
}
