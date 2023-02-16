using System.ComponentModel.DataAnnotations;


namespace DokumentiService.Entities
{
    public class EksterniDokumentEntity
    {
        [Key]
        public Guid EksterniDokumentID{ get; set; }
        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta { get; set; }
    }
}
