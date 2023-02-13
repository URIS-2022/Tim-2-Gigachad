using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KorisniciService.Entities
{
    /// <summary>
    /// Model realnog entiteta korisnici.
    /// </summary>
    public class KorisnikEntity
    {
        /// <summary>
        /// ID korisnika.
        /// </summary>
        [Key]
        public Guid KorisnikID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [ForeignKey("JavnoNadmetanjeEntity")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Tip korisnika.
        /// </summary>
        public string? TipKorisnika { get; set; }

        /// <summary>
        /// Ime i prezime korisnika.
        /// </summary>
        public string? Naziv { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string? Sifra { get; set; }
    }
}
