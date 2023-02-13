using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class DokumentEntity
    {
        [Key]
        public Guid DokumentID { get; set; }

        [ForeignKey("EksterniDokumentDTO")]
        public Guid EksterniDokumentID { get; set; }

        [ForeignKey("InterniDokumentDTO")]
        public Guid InterniDokumentID { get; set; }

        public DateTime? DatumDonosenja { get; set; }

        public int? Sablon { get; set; }

        [Required]
        public int StatusDokumenta { get; set; }

        


    }
}
