using System.ComponentModel.DataAnnotations;

namespace AdresaService.DTO
{
    /// <summary>
	/// DTO model za adresu.
	/// </summary>
    public class AdresaCreateDTO
    {
        /// <summary>
        /// Ulica.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Ulica { get; set; }

        /// <summary>
        /// Broj ulice.
        /// </summary>
        [Required]
        public int Broj { get; set; }

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
