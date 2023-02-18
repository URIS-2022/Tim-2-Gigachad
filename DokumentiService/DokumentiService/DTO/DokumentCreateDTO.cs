using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.DTO
{
    public class DokumentCreateDTO
    {
        [Required(ErrorMessage = "Lice mora da ima ID eksternog Dokumenta .")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("EksterniDokumentDTO")]
        public string EksterniDokumentID { get; set; }

        [Required(ErrorMessage = "Lice mora da ima ID fizičkog lica.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [ForeignKey("InterniDokumentDTO")]
        public string InterniDokumentID { get; set; }
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        [Required]
        public string Sablon { get; set; }

        public int StatusDokumenta { get; set; }
    }
}
