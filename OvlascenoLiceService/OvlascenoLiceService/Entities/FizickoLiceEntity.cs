using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.Entities
{
    /// <summary>
    /// Model realnog entiteta fizičko lice.
    /// </summary>
    public class FizickoLiceEntity
    {
        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// JMBG fizičkog lica.
        /// </summary>
        [Required(ErrorMessage = "Fizičko lice mora da ima JMBG.")]
        [MinLength(13, ErrorMessage = "JMBG fizičkog lica mora da ima 13 karaktera.")]
        [MaxLength(13, ErrorMessage = "JMBG fizičkog lica mora da ima 13 karaktera.")]
        public string JMBG { get; set; } = null!;

        /// <summary>
        /// Ime fizičkog lica.
        /// </summary>
        [Required(ErrorMessage = "Fizičko lice mora da ima ime.")]
        [MaxLength(15, ErrorMessage = "Ime fizičkog lica ne sme da bude preko 15 karaktera.")]
        public string Ime { get; set; } = null!;

        /// <summary>
        /// Prezime fizičkog lica.
        /// </summary>
        [Required(ErrorMessage = "Fizičko lice mora da ima prezime.")]
        [MaxLength(15, ErrorMessage = "Prezime fizičkog lica ne sme da bude preko 15 karaktera.")]
        public string Prezime { get; set; } = null!;

        /// <summary>
        /// Lica fizičkih lica.
        /// </summary>
        public List<OvlascenoLiceEntity>? Lica { get; set; }
    }
}