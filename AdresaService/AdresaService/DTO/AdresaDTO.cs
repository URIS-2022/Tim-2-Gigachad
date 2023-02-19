using System.ComponentModel.DataAnnotations;

namespace AdresaService.DTO
{
    /// <summary>
	/// DTO model za adresu.
	/// </summary>
    public class AdresaDTO
    {
        /// <summary>
		/// ID adrese.
		/// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Ulica i broj adrese.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? UlicaBroj { get; set; }

        /// <summary>
        /// Mesto.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese.
        /// </summary>
        [Required]
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// Država(E).
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Drzava { get; set; }
    }
}
