using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    /// <summary>
    /// InterniDokument Update DTO
    /// </summary>
    public class InterniDokumentUpdateDTO
    {
        /// <summary>
        /// Interni Dokument ID
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID internog dokumenta")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string InterniDokumentID { get; set; }
        /// <summary>
        /// Putanja dokumenta 
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }
    }
}
