using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuDTO
    {

        
        public Guid UgovorOZakupuID { get; set; }


        public DeoParceleDTO DeoParcele { get; set; } = null!;


        public KupacDTO Kupac { get; set; } = null!;
       
        public JavnoNadmetanjeDTO JavnoNadmetanje { get; set; }


        public DokumentDTO Dokument { get; set; } = null!;

        
        public DateTime? DatumUgovora { get; set; }
        
        public int? TrajanjeUgovora { get; set; }
        
        public string TipGarancije { get; set; }
    }
}
