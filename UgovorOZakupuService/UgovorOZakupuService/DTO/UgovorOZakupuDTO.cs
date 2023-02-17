using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuDTO
    {
        
        public Guid UgovorOZakupuID { get; set; }

        [ForeignKey("DeoParceleDTO")]
        public Guid DeoParceleID { get; set; }

        [ForeignKey("KupacDTO")]
        public Guid KupacID { get; set; }

        [ForeignKey("OvlascenoLiceDTO")]
        public Guid OvlascenoLiceID { get; set; }

        [ForeignKey("JavnoNadmetanjeDTO")]
        public Guid JavnoNadmetanjeID { get; set; }

        [ForeignKey("DokumentDTO")]
        public Guid DokumentID { get; set; }

        [Required]
        public DateTime? DatumUgovora { get; set; }
        [Required]
        public int? TrajanjeUgovora { get; set; }
        public enum TipGarancije { }
    }
}
