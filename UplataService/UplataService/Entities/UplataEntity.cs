using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UplataService.Entities
{
    /// <summary>
    /// Model realnog entiteta uplata.
    /// </summary>
    public class UplataEntity
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        [Key]
        public Guid UplataID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima javno nadmetanje.")]
        public Guid JavnoNadmetanjeID { get; set; } = Guid.Empty!;

        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima kupca.")]
        public Guid KupacID { get; set; } = Guid.Empty!;

        /// <summary>
        /// Broj racuna.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima broj racuna.")]
        [MaxLength(30, ErrorMessage = "Broj racuna ne sme da bude preko 30 karaktera.")]
        public string BrojRacuna { get; set; } = null!;

        /// <summary>
        /// Poziv na broj.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima poziv na broj.")]
        [MaxLength(10, ErrorMessage = "Poziv na broj ne sme da bude preko 10 karaktera.")]
        public string PozivNaBroj { get; set; } = null!;

        /// <summary>
        /// Iznos.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima iznos.")]
        [MaxLength(30, ErrorMessage = "Iznos ne sme da bude preko 30 karaktera.")]
        public int Iznos { get; set; } = 0!;

        /// <summary>
        /// Ime uplatioca.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima uplatioca.")]
        [MaxLength(50, ErrorMessage = "Ime uplatioca ne sme da bude preko 50 karaktera.")]
        public string Uplatilac { get; set; } = null!;

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima svrhu uplate.")]
        [MaxLength(200, ErrorMessage = "Svrha uplate ne sme da bude preko 200 karaktera.")]
        public string SvrhaUplate { get; set; } = null!;

        /// <summary>
        /// Datum uplate.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima datum.")]
        public DateTime? DatumUplate { get; set; }
    }
}
