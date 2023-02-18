using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.Entities
{
    /// <summary>
    /// Model realnog entiteta ovlasceno lice.
    /// </summary>
    public class OvlascenoLiceEntity
    {
        /// <summary>
        /// ID ovlascenog lica.
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
        [Required(ErrorMessage = "Lice mora da ima fizičko lice.")]
        public FizickoLiceEntity FizickoLice { get; set; } = null!;

        /// <summary>
        /// ID adrese ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima adresu lica.")]
        public Guid AdresaID { get; set; }

        /// <summary>
        /// Prvi telefon ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima telefon jedan.")]
        [MinLength(9, ErrorMessage = "Prvi telefon lica mora da bude manji od 9 karaktera.")]
        [MaxLength(10, ErrorMessage = "Prvi telefon lica ne sme da bude preko 10 karaktera.")]
        public string Telefon1 { get; set; } = null!;

        /// <summary>
        /// Drugi telefon ovlascenog lica.
        /// </summary>
        [MinLength(9, ErrorMessage = "Drugi telefon lica mora da bude manji od 9 karaktera.")]
        [MaxLength(10, ErrorMessage = "Drugi telefon lica ne sme da bude preko 10 karaktera.")]
        public string? Telefon2 { get; set; }

        /// <summary>
        /// Email ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima email.")]
        [MaxLength(50, ErrorMessage = "Email lica ne sme da bude preko 50 karaktera.")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Broj računa ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima broj računa.")]
        [MaxLength(20, ErrorMessage = "Email lica ne sme da bude preko 20 karaktera.")]
        public string BrojRacuna { get; set; } = null!;
    }
}
