using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// Model za DTO ugovora o zakupu
    /// </summary>
    public class UgovorOZakupuDTO
    {

        /// <summary>
        /// Ugovor o zakup ID
        /// </summary>
        public Guid UgovorOZakupuID { get; set; }

        /// <summary>
        /// Deo parcele
        /// </summary>
        public DeoParceleDTO DeoParcele { get; set; } = null!;

        /// <summary>
        /// Kupac
        /// </summary>
        public KupacDTO Kupac { get; set; } = null!;
        /// <summary>
        /// Javno nadmetanje
        /// </summary>
        public JavnoNadmetanjeDTO JavnoNadmetanje { get; set; } = null!;

        /// <summary>
        /// Dokument
        /// </summary>
        public DokumentDTO Dokument { get; set; } = null!;

        /// <summary>
        /// Datum ugovora
        /// </summary>
        public DateTime? DatumUgovora { get; set; } = null!;
        /// <summary>
        /// Trajanje ugovora
        /// </summary>
        public int? TrajanjeUgovora { get; set; } = null!;
        /// <summary>
        /// Tip garancije
        /// </summary>
        public string TipGarancije { get; set; } = null!;
    }
}
