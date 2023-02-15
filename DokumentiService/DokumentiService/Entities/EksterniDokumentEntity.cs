using System.ComponentModel.DataAnnotations;


namespace DokumentiService.Entities
{
    public class EksterniDokumentEntity
    {
        [Key]
        public Guid EksterniDokumentID{ get; set; }
        [Required]
        public string? PutanjaDokumenta { get; set; }
    }
}
