using static UgovorOZakupuService.Entities.EntitesEnums;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuCreateDTO : IValidatableObject
    {
        [Required(ErrorMessage = "Mora da postoji deo parcele")]
        public Guid DeoParceleID { get; set; }

        [Required(ErrorMessage = "Mora da postoji kupac")]
        public Guid KupacID { get; set; }

        [Required(ErrorMessage = "Mora da postoji ovlasceno lice")]
        public Guid OvlascenoLiceID { get; set; }

        [Required(ErrorMessage = "Mora da postoji javno nadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }

        [Required(ErrorMessage = "Mora da postoji dokument")]
        public string DokumentID { get; set; } = null!;

        [Required(ErrorMessage = "Mora da postoji datum ugovora")]
        public DateTime DatumUgovora { get; set; }

        [Required(ErrorMessage = "Mora da postoji trajanje ugovora")]
        public int? TrajanjeUgovora { get; set; }

        [Required(ErrorMessage = "Mora da postoji tip garancije")]
        public string? TipGarancije { get; set; } = string.Empty!;

        /// <summary>
		/// Validacija za model DTO-a za kreiranje ugovora.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Enum.TryParse(TipGarancije.ToUpper(), out TipGarancije tempGarancija))
                TipGarancije = tempGarancija.ToString();
            else
                yield return new ValidationResult("Tip garancije mora da bude: JEMSTVO, BANKARSKAGARANCIJA, GARANCIJANEKRETNINOM, ZIRANTSKA, UPLATAGOTOVINOM.", new[] { "UgovorOZakupuCreateDTO" });
        }
    }
}
