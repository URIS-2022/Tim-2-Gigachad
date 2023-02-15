using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UplataService.Models
{
    /// <summary>
	/// Model DTO-a za kreiranje uplate.
	/// </summary>
    public class UplataCreateDTO
    {
        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Broj racuna.
        /// </summary>
        [Required]
		[MaxLength(50)]
        public string? BrojRacuna { get; set; }

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? PozivNaBroj { get; set; }

        /// <summary>
        /// Iznos.
        /// </summary>
        [Required]
        public int? Iznos { get; set; }

        /// <summary>
        /// Ime uplatioca.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Uplatilac { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string? SvrhaUplate { get; set; }

        /// <summary>
        /// Datum uplate.
        /// </summary>
        [Required]
        public DateTime? DatumUplate { get; set; }

        /// <summary>
        /// Kursna lista.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? KursnaLista { get; set; }
    }
}
