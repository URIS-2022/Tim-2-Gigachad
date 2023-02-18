using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class DokumentUpdateDTO
    {

        public Guid DokumentID { get; set; }
        [Required(ErrorMessage = "Lice mora da ima ID eksternog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("EksterniDokument")]
        public string EksterniDokumentID { get; set; }

        [ForeignKey("InterniDokument")]
        [Required(ErrorMessage = "Lice mora da ima ID internog dokumenta.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string InterniDokumentID { get; set; }
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        [Required]
        public int? Sablon { get; set; }
        [Required]
        public int StatusDokumenta { get; set; }
    }
}
