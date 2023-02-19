using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.Entities
{
    /// <summary>
    /// Model realnog entiteta ugovora o zakupu
    /// </summary>
    public class UgovorOZakupuEntity
    {
        /// <summary>
        /// ID ugovora
        /// </summary>
        [Key]
        public Guid UgovorOZakupuID { get; set; }
        /// <summary>
        /// ID dela parcele
        /// </summary>
        [ForeignKey("DeoParceleDTO")]
        [Required(ErrorMessage = "Mora imati deo parcele")]
        public Guid DeoParceleID { get; set; }
        /// <summary>
        /// ID kupca
        /// </summary>

        [ForeignKey("KupacDTO")]
        [Required(ErrorMessage = "Mora imati kupca")]
        public Guid KupacID { get; set; }
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>

        [ForeignKey("JavnoNadmetanjeDTO")]
        [Required(ErrorMessage = "Mora imati javno nadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }
        /// <summary>
        /// ID Dokumenta
        /// </summary>
        [ForeignKey("DokumentDTO")]
        [Required(ErrorMessage = "Mora imati dokument")]
        public Guid DokumentID { get; set; }

        /// <summary>
        /// Datum ugovora
        /// </summary>
        [Required(ErrorMessage = "Mora imati datum")]
        public DateTime DatumUgovora { get; set; }
        /// <summary>
        /// Trajanje ugovora
        /// </summary>
        [Required(ErrorMessage = "Mora imati trajanje")]
        public int TrajanjeUgovora { get; set; }
        /// <summary>
        /// Tip garancije
        /// </summary>
        [Required(ErrorMessage = "Mora imati tip garancije")]
        public string? TipGarancije { get; set; }

    }
}
