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

        /// <summary>
		/// Period zakupa M javnog nadmetanja.
		/// </summary>
		public int PeriodZakupaM { get; set; }

        /// <summary>
		/// Pocetna cena javnog nadmetanja.
		/// </summary>
		public float PocetnaCena { get; set; } //ovo mozda nije float

        /// <summary>
		/// Visina cene javnog nadmetanja.
		/// </summary>
		public int VisinaCene { get; set; }

        /// <summary>
		/// Izlicitirana cena javnog nadmetanja.
		/// </summary>
		public float IzlicitiranaCena { get; set; }

        /// <summary>
		/// Najbolja ponuda javnog nadmetanja.
		/// </summary>
		public float NajboljaPonuda { get; set; }

        /// <summary>
		/// Broj ucesnika javnog nadmetanja.
		/// </summary>
		public int BrojUcesnika { get; set; }

        /// <summary>
		/// Prijavljeni kupci javnog nadmetanja.
		/// </summary>
		public int PrijavljeniKupci { get; set; }

        /// <summary>
		/// Licitanti javnog nadmetanja.
		/// </summary>
		public int Licitanti { get; set; }

        /// <summary>
		/// Krug koji je po redu javnog nadmetanja.
		/// </summary>
		public int Krug { get; set; }

        /// <summary>
        /// Status javnog nadmetanja. Enumerator
        /// </summary>
        //public Enumerator? StatusNadmetanja { get; set; }

        /// <summary>
		/// Izuzeto.
		/// </summary>
		public bool? Izuzeto { get; set; }
    }
}
