
using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class EksterniDokumentDTO
    {
        public Guid EksterniDokumentID { get; set; }
        [Required]
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }

    }
}
