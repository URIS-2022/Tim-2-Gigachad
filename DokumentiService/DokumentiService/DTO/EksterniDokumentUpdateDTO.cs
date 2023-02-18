using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class EksterniDokumentUpdateDTO
    {
        [Required(ErrorMessage = "Lice mora da ima ID eksternog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string EksterniDokumentID { get; set; }
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }
    }
}
