using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    public class DokumentEntity
    {
        [Key]
        public Guid DokumentID { get; set; } = Guid.Empty!;

        [ForeignKey("EksterniDokument")]
        public Guid EksterniDokumentID { get; set; } = Guid.Empty!;

        [Required(ErrorMessage = "Dokument mora da bude eksterni")]
        public EksterniDokumentEntity EksterniDokument { get; set; } = null!;

        [ForeignKey("InterniDokument")]
        public Guid InterniDokumentID { get; set; } = Guid.Empty!;

        [Required(ErrorMessage = "Dokument mora da bude interni")]
        public InterniDokumentEntity InterniDokument { get; set; } = null!;

        [Required]
        public DateTime? DatumDonosenja { get; set; }

        [Required]
        public int? Sablon { get; set; }

        [Required]
        public int StatusDokumenta { get; set; }


    }
}
