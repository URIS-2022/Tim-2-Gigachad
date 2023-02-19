using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    /// <summary>
    /// Model realnog entitea dokument
    /// </summary>
    public class DokumentEntity
    {
        /// <summary>
        /// ID dokumenta
        /// </summary>
        [Key]
        public Guid DokumentID { get; set; } = Guid.Empty!;
        /// <summary>
        /// ID eksternog dokumenta
        /// </summary>
        [ForeignKey("EksterniDokument")]
        public Guid EksterniDokumentID { get; set; } = Guid.Empty!;
        /// <summary>
        /// eksterni dokument entity
        /// </summary>

        [Required(ErrorMessage = "Dokument mora da bude eksterni")]
        public EksterniDokumentEntity EksterniDokument { get; set; } = null!;
        /// <summary>
        /// ID internog dokumenta
        /// </summary>
        [ForeignKey("InterniDokument")]
        public Guid InterniDokumentID { get; set; } = Guid.Empty!;
        /// <summary>
        /// Interni dokument entity
        /// </summary>

        [Required(ErrorMessage = "Dokument mora da bude interni")]
        public InterniDokumentEntity InterniDokument { get; set; } = null!;
        /// <summary>
        /// Datum donosenja dokumenta
        /// </summary>
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        /// <summary>
        /// Sablon
        /// </summary>
        [Required]
        public int? Sablon { get; set; }
        /// <summary>
        /// Status dokumenta
        /// </summary>
        [Required]
        public int StatusDokumenta { get; set; }


    }
}
