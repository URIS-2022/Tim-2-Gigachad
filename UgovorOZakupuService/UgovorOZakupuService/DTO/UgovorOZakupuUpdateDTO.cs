using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static UgovorOZakupuService.Entities.EntitesEnums;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuUpdateDTO : IValidatableObject
    {
        [Required(ErrorMessage = "Mora da postoji ID")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string UgovorOZakupuID { get; set; }
        [Required(ErrorMessage = "Mora da postoji deo parcele")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string DeoParceleID { get; set; }

        [Required(ErrorMessage = "Mora da postoji kupac")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string KupacID { get; set; }

        [Required(ErrorMessage = "Mora da postoji ovlasceno lice")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string OvlascenoLiceID { get; set; }

        [Required(ErrorMessage = "Mora da postoji javno nadmetanje")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string JavnoNadmetanjeID { get; set; }

        [Required(ErrorMessage = "Mora da postoji dokument")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string DokumentID { get; set; }

        [Required(ErrorMessage = "Mora da postoji datum ugovora")]
        public DateTime? DatumUgovora { get; set; }
        [Required(ErrorMessage = "Mora da postoji trajanje ugovora")]
        public int? TrajanjeUgovora { get; set; }
        [Required(ErrorMessage = "Mora da postoji tip garancije")]
        public string TipGarancije { get; set; }
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
