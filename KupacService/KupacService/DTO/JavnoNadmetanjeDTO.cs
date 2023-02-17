using System.ComponentModel.DataAnnotations;

namespace KupacService.DTO
{
    /// <summary>
	/// Model DTO-a za javno nadmetanje entitet.
	/// </summary>
    public class JavnoNadmetanjeDTO
    {
        /// <summary>
		/// ID javnog nadmetanja.
		/// </summary>
		public Guid ID { get; set; }

        /// <summary>
		/// Tip nadmetanja.
		/// </summary>
		public string? TipNadmetanja { get; set; }

        /// <summary>
        /// Opstina.
        /// </summary>
        public string? Opstina { get; set; }

        /// <summary>
        /// Datum javnog nadmetanja.
        /// </summary>
        public DateTime DatumNad { get; set; }

        /// <summary>
        /// Vreme pocetka javnog nadmetanja.
        /// </summary>
        public DateTime VremePoc { get; set; }

        /// <summary>
        /// Vreme zavrsetka javnog nadmetanja.
        /// </summary>
        public DateTime VremeKraj { get; set; }

        /// <summary>
        /// Period zakupa M javnog nadmetanja.
        /// </summary>
        public int PeriodZakupaM { get; set; }

        /// <summary>
        /// Pocetna cena javnog nadmetanja.
        /// </summary>
        public float PocetnaCena { get; set; }

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
        public string StatusNadmetanja { get; set; }

        /// <summary>
        /// Izuzeto.
        /// </summary>
        public bool Izuzeto { get; set; }
    }
}