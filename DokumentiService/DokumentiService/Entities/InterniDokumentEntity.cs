using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class InterniDokumentEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string? PutanjaDokumenta  { get; set; }
    }
}
