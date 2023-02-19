using System.ComponentModel.DataAnnotations;

namespace KomisijaService.Models
{
    /// <summary>
    /// DTO za prikaz entiteta komisija
    /// </summary>
    public class KomisijaDTO
    {
        /// <summary>
		/// ID komisije.
		/// </summary>
        public Guid KomisijaID { get; set; } = Guid.Empty!;

        /// <summary>
		/// ID 1. clana.
		/// </summary>
        public LiceDTO Clan1 { get; set; } = null!;

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        public LiceDTO Clan2 { get; set; } = null!;

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        public LiceDTO Clan3 { get; set; } = null!;

        /// <summary>
		/// ID 4. clana.
		/// </summary>
        public LiceDTO? Clan4 { get; set; } = null;

        /// <summary>
		/// ID 5. clana.
		/// </summary>
        public LiceDTO? Clan5 { get; set; } = null;

        /// <summary>
		/// ID predsednika.
		/// </summary>
        public LiceDTO Predsednik { get; set; } = null!;
    }
}
