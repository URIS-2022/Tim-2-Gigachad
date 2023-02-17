using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.DTO
{
    public class UgovorOZakupuUpdateDTO
    {
        [Required(ErrorMessage = "Mora da postoji ID")]
        public Guid UgovorOZakupuID { get; set; }
        [Required(ErrorMessage = "Mora da postoji deo parcele")]
        public Guid DeoParceleID { get; set; }

        [Required(ErrorMessage = "Mora da postoji kupac")]
        public Guid KupacID { get; set; }

        [Required(ErrorMessage = "Mora da postoji ovlasceno lice")]
        public Guid OvlascenoLiceID { get; set; }

        [Required(ErrorMessage = "Mora da postoji javno nadmetanje")]
        public Guid JavnoNadmetanjeID { get; set; }

        [Required(ErrorMessage = "Mora da postoji dokument")]
        public Guid DokumentID { get; set; }

        [Required(ErrorMessage = "Mora da postoji datum ugovora")]
        public DateTime? DatumUgovora { get; set; }
        [Required(ErrorMessage = "Mora da postoji trajanje ugovora")]
        public int? TrajanjeUgovora { get; set; }
        [Required(ErrorMessage = "Mora da postoji tip garancije")]
        public string TipGarancije { get; set; }
    }
}
