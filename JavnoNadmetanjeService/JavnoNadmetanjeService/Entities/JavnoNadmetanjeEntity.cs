using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanjeEntity
    {
        /// <summary>
		/// ID javnog nadmetanja.
		/// </summary>
		[Key]
        public Guid ID { get; set; }

        /// <summary>
		/// strani kljuc - ID adrese.
		/// </summary>
		[ForeignKey("AdresaEntity")]
        public Guid AdresaID { get; set; }

        /// <summary>
		/// strani kljuc - ID dela parcele.
		/// </summary>
		[ForeignKey("DeoParceleEntity")]
        public Guid DeoParceleID { get; set; }

        /// <summary>
		/// strani kljuc - ID najboljeg kupca.
		/// </summary>
		[ForeignKey("KupacEntity")]
        public Guid NajbKupacID { get; set; }

        /// <summary>
        /// Tip nadmetanja. Enumerator
        /// </summary>
        //public Enumerator? TipNadmetanja { get; set; }

        /// <summary>
        /// Opstina javnog nadmetanja. Enumerator
        /// </summary>
        //public Enumerator? Opstina { get; set; }

        /// <summary>
        /// Datum javnog nadmetanja.
        /// </summary>
        public DateTime? DatumNad { get; set; }

        /// <summary>
        /// Vreme pocetka javnog nadmetanja.
        /// </summary>
        public DateTime? VremePoc { get; set; }

        /// <summary>
        /// Vreme kraja javnog nadmetanja.
        /// </summary>
        public DateTime? VremeKraj { get; set; }

        //....

    }
}
