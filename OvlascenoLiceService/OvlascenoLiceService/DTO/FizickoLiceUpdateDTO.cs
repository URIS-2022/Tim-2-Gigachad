using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.DTO
{
    /// <summary>
    /// Model DTO-a za ažuriranje entiteta fizičko lice.
    /// </summary>
    public class FizickoLiceUpdateDTO : IValidatableObject
    {
        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        [Required(ErrorMessage = "Fizičko lice mora da ima ID.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string ID { get; set; } = null!;

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
        /// Validacija za model DTO-a za ažuriranje entiteta fizičko lice.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ime.Equals(Prezime))
                yield return new ValidationResult("Fizičko lice ne može da ima isto ime i prezime.", new[] { "FizickoLiceUpdateDTO" });
        }
    }
}
