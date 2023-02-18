using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuDTO
    {

        
        public Guid UgovorOZakupuID { get; set; }

        
        public Guid DeoParceleID { get; set; }

        
        public Guid KupacID { get; set; }

        
        public Guid OvlascenoLiceID { get; set; }

        
        public Guid JavnoNadmetanjeID { get; set; }


        public DokumentDTO Dokument { get; set; } = null!;

        
        public DateTime? DatumUgovora { get; set; }
        
        public int? TrajanjeUgovora { get; set; }
        
        public string TipGarancije { get; set; }
    }
}
