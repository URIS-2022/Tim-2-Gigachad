using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static UgovorOZakupuService.Entities.EntitesEnums;

namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// Model DTO za ugovor o zakupu
    /// </summary>
    public class UgovorOZakupuUpdateDTO : IValidatableObject
    {
        /// <summary>
        /// Ugovor o zakupu ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji ID")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string UgovorOZakupuID { get; set; } = null!;

        /// <summary>
        /// Deo parcele ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji deo parcele")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string DeoParceleID { get; set; } = null!;
        /// <summary>
        /// Kupac ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji kupac")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string KupacID { get; set; } = null!;
        /// <summary>
        /// Javno nadmetanje ID
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji ovlasceno lice")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string JavnoNadmetanjeID { get; set; } = null!;
        /// <summary>
        /// Dokument ID
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji dokument")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string DokumentID { get; set; } = null!;
        /// <summary>
        /// Datum ugovora
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji datum ugovora")]
        public DateTime? DatumUgovora { get; set; } = null!;
        /// <summary>
        /// Trajanje ugovora
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji trajanje ugovora")]
        public int? TrajanjeUgovora { get; set; } = 0!;
        /// <summary>
        /// Tip garancije
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji tip garancije")]
        public string TipGarancije { get; set; } = null!;
        /// <summary>
        /// za update
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Enum.TryParse(TipGarancije.ToUpper(), out TipGarancije tempGarancija))
                TipGarancije = tempGarancija.ToString();
            else
                yield return new ValidationResult("Tip garancije mora da bude: JEMSTVO, BANKARSKAGARANCIJA, GARANCIJANEKRETNINOM, ZIRANTSKA, UPLATAGOTOVINOM.", new[] { "UgovorOZakupuCreateDTO" });
        }
    }
}
