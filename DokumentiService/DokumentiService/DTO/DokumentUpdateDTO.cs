using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    /// <summary>
    /// Dokument update model DTO
    /// </summary>
    public class DokumentUpdateDTO
    {
        /// <summary>
        /// Dokument ID
        /// </summary>
        public Guid DokumentID { get; set; }

        /// <summary>
        /// EksterniDokument ID
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID eksternog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("EksterniDokument")]
        public string EksterniDokumentID { get; set; } = null!;

        /// <summary>
        /// Interni Dokument ID
        /// </summary>
        [ForeignKey("InterniDokument")]
        [Required(ErrorMessage = "Lice mora da ima ID internog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string InterniDokumentID { get; set; } = null!;
        /// <summary>
        /// Datum donosenja dokumenta
        /// </summary>
        [Required]
        public DateTime? DatumDonosenja { get; set; } = null!;
        /// <summary>
        /// Sablon 
        /// </summary>
        [Required]
        public int? Sablon { get; set; } = 0!;
        /// <summary>
        /// Status dokumenta
        /// </summary>
        [Required]
        public int StatusDokumenta { get; set; } = 0!;
    }
}
