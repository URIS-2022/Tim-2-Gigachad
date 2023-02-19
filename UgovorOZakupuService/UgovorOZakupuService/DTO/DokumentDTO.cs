using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// DTO za dokument
    /// </summary>
    public class DokumentDTO
    {
        /// <summary>
        /// ID za dokument
        /// </summary>
        public Guid DokumentID { get; set; }
        /// <summary>
        /// ID za eksterni Dokument
        /// </summary>
        public EksterniDokumentDTO EksterniDokument { get; set; } = null!;
        /// <summary>
        /// ID za interni Dokument
        /// </summary>
        public InterniDokumentDTO InterniDokument { get; set; } = null!;
        /// <summary>
        /// Datum donosenja
        /// </summary>
        public DateTime? DatumDonosenja { get; set; }
        /// <summary>
        /// Sablon dokumenta
        /// </summary>
        public int? Sablon { get; set; }
        /// <summary>
        /// Status Dokumenta
        /// </summary>
        public int StatusDokumenta { get; set; }
    }
}
