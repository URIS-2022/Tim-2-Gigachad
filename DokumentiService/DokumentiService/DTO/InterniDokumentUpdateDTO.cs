using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class InterniDokumentUpdateDTO
    {
        [Required(ErrorMessage = "Lice mora da ima ID internog dokumenta")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string InterniDokumentID { get; set; }
        [Required]
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }
    }
}
