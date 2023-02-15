using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class DokumentDTO
    {

        [ForeignKey("EksterniDokumentDTO")]
        public Guid EksterniDokumentID { get; set; }

        [ForeignKey("InterniDokumentDTO")]
        public Guid InterniDokumentID { get; set; }

        public DateTime? DatumDonosenja { get; set; }

        public string SablonStatus { get; set; }
    }
}
