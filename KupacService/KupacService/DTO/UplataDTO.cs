using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.DTO
{
    /// <summary>
	/// Model DTO-a za uplatu.
	/// </summary>
	public class UplataDTO
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        /// [Required]
        public Guid UplataID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// ID kupca.
        /// </summary>
        public Guid KupacID { get; set; }

        /// <summary>
        /// Broj racuna.
        /// </summary>
        public string? BrojRacuna { get; set; }

        /// <summary>
        /// Poziv na broj.
        /// </summary>

        public string? PozivNaBroj { get; set; }

        /// <summary>
        /// Iznos.
        /// </summary>

        public int? Iznos { get; set; }

        /// <summary>
        /// Ime uplatioca.
        /// </summary>

        public string? Uplatilac { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>

        public string? SvrhaUplate { get; set; }

        /// <summary>
        /// Datum uplate.
        /// </summary>

        public DateTime? DatumUplate { get; set; }

        /// <summary>
        /// Kursna lista.
        /// </summary>

        public string? KursnaLista { get; set; }
    }
}