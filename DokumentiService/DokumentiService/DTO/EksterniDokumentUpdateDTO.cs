using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    /// <summary>
    /// Model eksternog Dokumenta za update
    /// </summary>
    public class EksterniDokumentUpdateDTO
    {
        /// <summary>
        /// Eksterni Dokument ID
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID eksternog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string EksterniDokumentID { get; set; } = null!;
        /// <summary>
        /// Putanja dokumenta
        /// </summary>
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; } = null!;
    }
}
