using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class DokumentUpdateDTO
    {
        public Guid DokumentID { get; set; }

        [ForeignKey("EksterniDokumentDTO")]
        public Guid EksterniDokumentID { get; set; }

        [ForeignKey("InterniDokumentDTO")]
        public Guid InterniDokumentID { get; set; }
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        [Required]
        public int? Sablon { get; set; }
        [Required]
        public int StatusDokumenta { get; set; }
    }
}
