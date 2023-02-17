using OvlascenoLiceService.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OvlascenoLice.Entities
{
    /// <summary>
    /// Model realnog entiteta lice.
    /// </summary>
    public class LiceEntity
    {
        /// <summary>
        /// ID lica.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        [ForeignKey("FizickoLice")]
        public Guid FizickoLiceID { get; set; }

        /// <summary>
        /// Fizičko lice.
        /// </summary>
        public FizickoLiceDTO? FizickoLice { get; set; }

        /// <summary>
        /// ID adrese lica.
        /// </summary>
        [Required]
        public Guid AdresaID { get; set; }

        /// <summary>
        /// Adresa.
        /// </summary>
        public AdresaDTO? Adresa { get; set; }

        /// <summary>
        /// Telefon 1 lica.
        /// </summary>
        [Required]
        [MinLength(9)]
        [MaxLength(10)]
        public string? Tel1 { get; set; }

        /// <summary>
        /// Telefon 2 lica.
        /// </summary>
        [MinLength(9)]
        [MaxLength(10)]
        public string? Tel2 { get; set; }

        /// <summary>
        /// Email lica.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        /// <summary>
        /// Broj računa lica.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? BrojRacuna { get; set; }

        /// <summary>
        /// Da li je lice ovlašćeno lice.
        /// </summary>
        [Required]
        public bool OvlascenoLice { get; set; }
    }
}
