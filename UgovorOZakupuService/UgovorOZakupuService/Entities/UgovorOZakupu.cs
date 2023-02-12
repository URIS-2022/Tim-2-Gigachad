using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.Entities
{
    public class UgovorOZakupu
    {
        public UgovorOZakupu() { }

        [Key]
        public Guid UgovorID { get; set; }

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

        public DateOnly DatumUgovora { get; set; }

        public int TrajanjeUgovora { get; set; }

        public int TipGarancije { get; set; }

    }
}
