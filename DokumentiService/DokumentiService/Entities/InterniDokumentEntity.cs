using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class InterniDokumentEntity
    {
        [Key]
        public Guid InterniDokumentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta  { get; set; }

        public List<DokumentEntity>? Dokument { get; set; }
    }
}
