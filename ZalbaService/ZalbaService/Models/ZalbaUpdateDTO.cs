﻿using System.ComponentModel.DataAnnotations;
using static ZalbaService.Entities.EntitiesEnums;

namespace ZalbaService.Models
{
    public class ZalbaUpdateDTO : IValidatableObject
    {
        /// <summary>
		/// ID zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima svoj ID.")]
        public string ZalbaID { get; set; }

        /// <summary>
		/// ID kupca.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima kupca koji je podneo.")]
        public string KupacID { get; set; }

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima tip žalbe.")]
        [MaxLength(50)]
        public string TipZalbe { get; set; }

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima datum podnošenja.")]
        public DateTime? DatumPodnosenja { get; set; }

        /// <summary>
		/// Razlog zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima razlog.")]
        [MaxLength(50)]
        public string Razlog { get; set; }

        /// <summary>
		/// Obrazlozenje zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima obrazloženje.")]
        [MaxLength(200)]
        public string Obrazlozenje { get; set; }

        /// <summary>
		/// Status zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima status.")]
        [MaxLength(10)]
        public string StatusZalbe { get; set; }

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        [Required(ErrorMessage = "Žalba mora da ima radnju.")]
        [MaxLength(50)]
        public string RadnjaZalbe { get; set; }

        /// <summary>
        /// Validacija za model DTO-a za ažuriranje entiteta žalba.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Compare(DatumPodnosenja.Value, DateTime.Now) > 0)
                yield return new ValidationResult("Zalba ne može da ima noviji datum podnosenja od trenutnog datuma.", new[] { "ZalbaUpdateDTO" });

            if (Enum.TryParse(StatusZalbe.ToUpper(), out StatusZalbe tempStatus))
                StatusZalbe = tempStatus.ToString();
            else
                yield return new ValidationResult("Status zalbe mora da bude: OTVORENA, USVOJENA ili ODBIJENA.", new[] { "ZalbaUpdateDTO" });

            if (Enum.TryParse(RadnjaZalbe.ToUpper(), out RadnjaZalbe tempRadnja))
                RadnjaZalbe = tempRadnja.ToString();
            else
                yield return new ValidationResult("Radnja zalbe mora da bude: JN_IDE_U_DRUGI_KRUG_SA_NOVIM_USLOVIMA, JN_IDE_U_DRUGI_KRUG_SA_STARIM_USLOVIMA ili JN_NE_IDE_U_DRUGI_KRUG.", new[] { "ZalbaUpdateDTO" });

            if (Enum.TryParse(TipZalbe.ToUpper(), out TipZalbe tempTip))
                TipZalbe = tempTip.ToString();
            else
                yield return new ValidationResult("Tip zalbe mora da bude: ZALBA_NA_ODLUKU_O_DAVANJU_NA_KORISCENJE, ZALBA_NA_ODLUKU_O_DAVANJU_U_ZAKUP ili ZALBA_NA_TOK_JAVNOG_NADMETANJA.", new[] { "ZalbaUpdateDTO" });
        }
    }
}
