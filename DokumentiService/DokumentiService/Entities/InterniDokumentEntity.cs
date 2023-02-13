using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class InterniDokumentEntity
    {
        [Key]
        public Guid InterniDokumentId { get; set; }

        public string? PutanjaDokumenta  { get; set; }
    }
}
