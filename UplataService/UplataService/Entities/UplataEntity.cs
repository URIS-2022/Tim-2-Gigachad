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
        [ForeignKey("JavnoNadmetanjeEntity")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// ID kupca.
        /// </summary>
        [ForeignKey("KupacEntity")]
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
