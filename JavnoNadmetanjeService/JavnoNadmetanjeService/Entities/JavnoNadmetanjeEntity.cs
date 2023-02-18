using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.Entities
{
    /// <summary>
	/// Model entiteta javnog nadmetanja.
	/// </summary>
    public class JavnoNadmetanjeEntity
    {
        /// <summary>
		/// ID javnog nadmetanja.
		/// </summary>
		[Key]
        public Guid ID { get; set; }

        /// <summary>
		/// strani kljuc - ID licitacije.
		/// </summary>
		[ForeignKey("Licitacija")]
        public Guid LicitacijaID { get; set; }

        /// <summary>
		/// Licitacija.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima licitaciju.")]
        public LicitacijaEntity Licitacija { get; set; } = null!;

        /// <summary>
		/// strani kljuc - ID adrese nadmetanja.
		/// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima adresu javnog nadmetanja.")]
        public Guid AdresaID { get; set; }

        /// <summary>
		/// strani kljuc - ID dela parcele.
		/// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima deo parcele.")]
        public Guid DeoParceleID { get; set; }

        /// <summary>
		/// strani kljuc - ID najboljeg kupca.
		/// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima najboljeg kupca.")]
        public Guid KupacID { get; set; }

        /// <summary>
        /// Tip javnog nadmetanja. Enumerator.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima definisan tip.")]
        [MaxLength(30, ErrorMessage = "Tip javnog nadmetanja mora da bude: JAVNA_LICITACIJA ili OTVARANJE_ZATVORENIH_PONUDA.")]
        public string TipNadmetanja { get; set; } = null!;

        /// <summary>
        /// Opstina javnog nadmetanja. Enumerator.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima definisanu opstinu.")]
        [MaxLength(30, ErrorMessage = "Opstina mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD i PALIC.")]
        public string Opstina { get; set; } = null!;

        /// <summary>
        /// Datum javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima datum.")]
        public DateTime? DatumNad { get; set; } = null!;

        /// <summary>
        /// Vreme pocetka javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima vreme pocetka.")]
        public DateTime? VremePoc { get; set; } = null!;

        /// <summary>
        /// Vreme kraja javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima vreme kraja.")]
        public DateTime? VremeKraj { get; set; } = null!;

        /// <summary>
		/// Period zakupa M javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima period zakupa meseci.")]
        public int PeriodZakupa { get; set; } = 0!;

        /// <summary>
		/// Pocetna cena javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima pocetnu cenu.")]
        public int PocetnaCena { get; set; } = 0!;

        /// <summary>
		/// Visina cene javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima visinu cene.")]
        public int VisinaCene { get; set; } = 0!;

        /// <summary>
		/// Izlicitirana cena javnog nadmetanja.
		/// </summary>
        public int IzlicitiranaCena { get; set; }

        /// <summary>
		/// Broj ucesnika javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima broj ucesnika.")]
        public int BrojUcesnika { get; set; } = 0!;

        /// <summary>
		/// Prijavljeni kupci javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima prijavljene kupce.")]
        public int PrijavljeniKupci { get; set; } = 0!;

        /// <summary>
		/// Licitanti javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima broj licitanata.")]
        public int Licitanti { get; set; } = 0!;

        /// <summary>
		/// Krug koji je po redu javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima krug.")]
        public int Krug { get; set; } = 0!;

        /// <summary>
        /// Status javnog nadmetanja. Enumerator
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima definisan status.")]
        [MaxLength(30, ErrorMessage = "Status javnog nadmetanja mora da bude: PRVI_KRUG, DRUGI_KRUG_STARI i DRUGI_KRUG_NOVI.")]
        public string StatusNadmetanja { get; set; } = null!;

        /// <summary>
        /// Izuzeto.
        /// </summary>
        public bool Izuzeto { get; set; }
    }
}
