using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.DTO
{
    public class DokumentDTO
    {
        /// <summary>
        /// ID za dokument
        /// </summary>
        public Guid DokumentID { get; set; }
        /// <summary>
        /// ID za eksterni Dokument
        /// </summary>
        [ForeignKey("EksterniDokument")]
        public Guid EksterniDokumentID { get; set; }
        /// <summary>
        /// ID za interni Dokument
        /// </summary>
        [ForeignKey("InterniDokument")]
        public Guid InterniDokumentID { get; set; }
        /// <summary>
        /// Datum donosenja
        /// </summary>
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        /// <summary>
        /// Sablon dokumenta
        /// </summary>
        [Required]
        public int? Sablon { get; set; }
        /// <summary>
        /// Status Dokumenta
        /// </summary>
        [Required]
        public int StatusDokumenta { get; set; }
    }
}
