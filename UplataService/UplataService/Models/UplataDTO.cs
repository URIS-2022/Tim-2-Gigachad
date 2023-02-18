using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UplataService.Models
{
    /// <summary>
	/// Model DTO-a za uplatu.
	/// </summary>
	public class UplataDTO
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        /// [RequirVoice command windows ed]
        public Guid UplataID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        public JavnoNadmetanjeDTO JavnoNadmetanje { get; set; } 

        /// <summary>
        /// ID kupca.
        /// </summary>
        public KupacDTO Kupac { get; set; } = null!;

        /// <summary>
        /// Broj racuna.
        /// </summary>
        public string BrojRacuna { get; set; } = null!;

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        public string PozivNaBroj { get; set; } = null!;

        /// <summary>
        /// Iznos.
        /// </summary>
        public int Iznos { get; set; } = 0!;

        /// <summary>
        /// Ime uplatioca.
        /// </summary>
        public string Uplatilac { get; set; } = null!;

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        public string SvrhaUplate { get; set; } = null!;

        /// <summary>
        /// Datum uplate.
        /// </summary>
        public DateTime? DatumUplate { get; set; }
    }
}
