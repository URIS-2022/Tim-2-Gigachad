namespace UplataService.Models
{
    /// <summary>
	/// DTO za javno nadmetanje.
	/// </summary>
    public class JavnoNadmetanjeDTO
    {
        /// <summary>
		/// ID adrese javnog nadmetanja.
		/// </summary>
		public Guid? AdresaNadID { get; set; }

        /// <summary>
		/// ID dela parcele.
		/// </summary>
		public Guid? DeoParceleID { get; set; }

        /// <summary>
        /// ID najboljeg kupca.
        /// </summary>
        public Guid? NajbKupacID { get; set; }

        /// <summary>
		/// Tip nadmetanja.
		/// </summary>
		public string? TipNad { get; set; }
        //Enumerator kako?

        /// <summary>
		/// Opstina.
		/// </summary>
		public string? Opstina { get; set; }
        //Enumerator kako

        /// <summary>
        /// Datum odrzavanja nadmetanja.
        /// </summary>
        public DateTime? DatumNad { get; set; }

        /// <summary>
		/// Vreme pocinjanja.
		/// </summary>
		public string? VremePoc { get; set; }
        //Format time?

        /// <summary>
		/// Vreme zavrsetka.
		/// </summary>
		public string? VremeKraj { get; set; }
        //Format time?

        /// <summary>
		/// Period zakupa u mesecima.
		/// </summary>
		public int? PeriodZakupaM { get; set; }

        /// <summary>
        /// Pocetna cena.
        /// </summary>
        public int? PocetnaCena { get; set; }

        /// <summary>
		/// Rast cene.
		/// </summary>
		public int? VisinaCene { get; set; }

        /// <summary>
		/// Krajnja cena.
		/// </summary>
		public int? IzlicitiranaCena { get; set; }

        /// <summary>
        /// Najbolja ponuda.
        /// </summary>
        public int? NajboljaPonuda { get; set; }

        /// <summary>
		/// Broj ucesnika.
		/// </summary>
		public int? BrojUcesnika { get; set; }

        /// <summary>
		/// Broj prijavljenih kupaca.
		/// </summary>
		public int? PrijavljeniKupci { get; set; }

        /// <summary>
        /// Broj licitanata.
        /// </summary>
        public int? Licitanti { get; set; }

        /// <summary>
		/// Krug licitacije.
		/// </summary>
		public int? Krug { get; set; }

        /// <summary>
		/// Status nadmetanja.
		/// </summary>
		public string? StatusNad { get; set; }
        //Enumeration kako?

        /// <summary>
        /// Da li je izuzeto.
        /// </summary>
        public bool? Izuzeto { get; set; }
    }
}
