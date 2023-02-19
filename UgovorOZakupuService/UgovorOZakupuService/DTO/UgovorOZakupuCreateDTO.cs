using static UgovorOZakupuService.Entities.EntitesEnums;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// Model dto za kreiranje ugovora o zakupu
    /// </summary>
    public class UgovorOZakupuCreateDTO : IValidatableObject
    {
        /// <summary>
        /// Deo parcele ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji deo parcele")]
        public Guid DeoParceleID { get; set; }
        /// <summary>
        /// Kupac ID
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji kupac")]
        public string KupacID { get; set; } = null!;
        /// <summary>
        /// Javno nadmetanje ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji javno nadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        /// Dokument ID
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji dokument")]
        public string DokumentID { get; set; } = null!;
        /// <summary>
        /// Datum ugovora 
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji datum ugovora")]
        public DateTime DatumUgovora { get; set; }
        /// <summary>
        /// Trajanje ugovora
        /// </summary>

        [Required(ErrorMessage = "Mora da postoji trajanje ugovora")]
        public int? TrajanjeUgovora { get; set; }
        /// <summary>
        /// Tip garancije
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji tip garancije")]
        public string TipGarancije { get; set; } = string.Empty!;

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
