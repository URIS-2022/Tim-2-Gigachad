using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.DTO
{
    /// <summary>
    /// Repozitorijum za Dokument create
    /// </summary>
    public class DokumentCreateDTO
    {
        /// <summary>
        /// ID eksternog dokumenta
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID eksternog Dokumenta .")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("EksterniDokumentDTO")]
        public string EksterniDokumentID { get; set; } = null!;
        /// <summary>
        /// ID internog dokumenta
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID fizičkog lica.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("InterniDokumentDTO")]
        public string InterniDokumentID { get; set; } = null!;
        /// <summary>
        /// Datum donosenja
        /// </summary>
        [Required]
        public DateTime? DatumDonosenja { get; set; } = null;
        /// <summary>
        /// Sablon
        /// </summary>
        [Required]
        public string Sablon { get; set; } = null!;

        /// <summary>
        /// status dokumenta
        /// </summary>

        public int StatusDokumenta { get; set; }
    }
}
