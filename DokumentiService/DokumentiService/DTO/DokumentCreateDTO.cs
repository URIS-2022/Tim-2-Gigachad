using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.DTO
{
    public class DokumentCreateDTO
    {
        [ForeignKey("EksterniDokumentDTO")]
        public Guid EksterniDokumentID { get; set; }

        [ForeignKey("InterniDokumentDTO")]
        public Guid InterniDokumentID { get; set; }
        [Required]
        public DateTime? DatumDonosenja { get; set; }
        [Required]
        public string Sablon { get; set; }

        public int StatusDokumenta { get; set; }
    }
}
