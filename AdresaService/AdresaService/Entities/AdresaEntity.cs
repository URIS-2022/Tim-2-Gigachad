using System.ComponentModel.DataAnnotations;

namespace AdresaService.Entities
{
    /// <summary>
	/// Model realnog entiteta fizičko lice.
	/// </summary>
    public class AdresaEntity
    {
        /// <summary>
        /// ID adrese.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

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
        /// Država broj adrese.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Drzava { get; set; }
    }
}
