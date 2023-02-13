using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class EksterniDokumentEntity
    {
        [Key]
        public Guid EksterniDokumentId { get; set; }

        public string? PutanjaDokumenta { get; set; }
    }
}
