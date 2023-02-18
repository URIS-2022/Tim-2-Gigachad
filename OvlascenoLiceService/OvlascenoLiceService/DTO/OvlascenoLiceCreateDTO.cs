﻿using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.DTO
{
    /// <summary>
    /// Model DTO-a za kreiranje entiteta ovlasceno lice.
    /// </summary>
    public class OvlascenoLiceCreateDTO : IValidatableObject
    {
        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID fizičkog lica.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string FizickoLiceID { get; set; } = null!;

        /// <summary>
        /// ID adrese ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID adrese lica.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string AdresaID { get; set; } = null!;

        /// <summary>
        /// Prvi telefon ovlascenog lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima prvi telefon.")]
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

        /// <summary>
        /// Validacija za model DTO-a za kreiranje entiteta ovlasceno lice.
        /// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Telefon2 != null && Telefon1.Equals(Telefon2))
                yield return new ValidationResult("Lice ne može da ima isti prvi i drugi telefon.", new[] { "LiceUpdateDTO" });
        }
    }
}
