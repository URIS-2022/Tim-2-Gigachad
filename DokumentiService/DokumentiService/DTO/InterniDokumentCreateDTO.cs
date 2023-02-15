using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class InterniDokumentCreateDTO
    {
        [Required]
        [MaxLength(25)]
        public string? PutanjaDokumenta { get; set; }
    }
}
