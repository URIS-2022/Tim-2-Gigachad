using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class EksterniDokumentCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta { get; set; }
    }
}
