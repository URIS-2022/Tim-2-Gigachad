using System.ComponentModel.DataAnnotations;
using static JavnoNadmetanjeService.Entities.EntitiesEnums;

namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
	/// Model DTO-a za kreiranje javno nadmetanje entiteta.
	/// </summary>
    public class JavnoNadmetanjeCreateDTO : IValidatableObject
    {
        /// <summary>
        /// ID licitacije.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima ID licitacije.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string LicitacijaID { get; set; } = null!;

        /// <summary>
        /// ID adrese javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima ID adrese javnog nadmetanja.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string AdresaID { get; set; } = null!;

        /// <summary>
		/// ID dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima ID dela parcele.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string DeoParceleID { get; set; } = null!;

        /// <summary>
		/// ID kupca.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima ID kupca.")]
        [MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        [MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
        public string KupacID { get; set; } = null!;

        /// <summary>
        /// Tip javnog nadmetanja. Enumerator.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima tip.")]
        [MaxLength(30, ErrorMessage = "Tip javno nadmetanje ne sme da bude preko 30 karaktera.")]
        public string TipNadmetanja { get; set; } = null!;

        /// <summary>
        /// Opstina javnog nadmetanja. Enumerator.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima opstinu.")]
        [MaxLength(30, ErrorMessage = "Opstina ne sme da bude preko 30 karaktera.")]
        public string Opstina { get; set; } = null!;

        /// <summary>
        /// Datum javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima datum.")]
        public DateTime DatumNad { get; set; }

        /// <summary>
        /// Vreme pocetka javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima vreme pocetka.")]
        public DateTime VremePoc { get; set; }

        /// <summary>
        /// Vreme zavrsetka javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima vreme kraja.")]
        public DateTime VremeKraj { get; set; }

        /// <summary>
        /// Period zakupa M javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima period zakupa meseci.")]
        public int PeriodZakupa { get; set; }

        /// <summary>
        /// Pocetna cena javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima pocetnu cenu.")]
        public int PocetnaCena { get; set; }

        /// <summary>
        /// Visina cene javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima visinu cene zemljista.")]
        public int VisinaCene { get; set; }

        /// <summary>
		/// Izlicitirana cena javnog nadmetanja.
		/// </summary>
        public int IzlicitiranaCena { get; set; }

        /// <summary>
		/// Broj ucesnika javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima broj ucesnika.")]
        public int BrojUcesnika { get; set; }

        /// <summary>
		/// Prijavljeni kupci javnog nadmetanja.
		/// </summary>
		[Required(ErrorMessage = "Javno nadmetanje mora da ima prijavljene kupce.")]
        public int PrijavljeniKupci { get; set; }

        /// <summary>
		/// Licitanti javnog nadmetanja.
		/// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima broj licitanata.")]
        public int Licitanti { get; set; }

        /// <summary>
		/// Krug koji je po redu javnog nadmetanja.
		/// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima krug.")]
        public int Krug { get; set; }

        /// <summary>
        /// Status javnog nadmetanja. Enumerator
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima definisan status.")]
        [MaxLength(17, ErrorMessage = "Status javnog nadmetanja mora da bude: PRVI_KRUG, DRUGI_KRUG_STARI i DRUGI_KRUG_NOVI.")]
        public string StatusNadmetanja { get; set; } = null!;

        /// <summary>
        /// Izuzeto.
        /// </summary>
        public bool Izuzeto { get; set; }

        /// <summary>
        /// Validacija za model DTO-a za kreiranje javnog nadmetanja.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (VremePoc >= VremeKraj)
                yield return new ValidationResult("Vreme kraja nadmetanja ne sme da bude pre vremena pocetka.", new[] { "JavnoNadmetanjeCreateDTO" });

            if (PocetnaCena > VisinaCene)
                yield return new ValidationResult("Pocetna cena je uvek manja od najvise cene.", new[] { "JavnoNadmetanjeCreateDTO" });

            if (IzlicitiranaCena >= VisinaCene)
                yield return new ValidationResult("Izlicitirana cena ne sme da predje definisanu visinu cene zemljista", new[] { "JavnoNadmetanjeCreateDTO" });

            if (IzlicitiranaCena <= PocetnaCena)
                yield return new ValidationResult("Izlicitirana cena moze biti jednaka ili veca od pocetne cene", new[] { "JavnoNadmetanjeCreateDTO" });

            if (Enum.TryParse(TipNadmetanja.ToUpper(), out TipNadmetanja tempTip))
                TipNadmetanja = tempTip.ToString();
            else
                yield return new ValidationResult("Tip javnog nadmetanja mora da bude: JAVNA_LICITACIJA ili OTVARANJE_ZATVORENIH_PONUDA.", new[] { "JavnoNadmetanjeCreateDTO" });

            if (Enum.TryParse(Opstina.ToUpper(), out Opstina tempOpstina))
                Opstina = tempOpstina.ToString();
            else
                yield return new ValidationResult("Opstina mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD i PALIC.", new[] { "JavnoNadmetanjeCreateDTO" });

            if (Enum.TryParse(StatusNadmetanja.ToUpper(), out StatusNadmetanja tempStatus))
                StatusNadmetanja = tempStatus.ToString();
            else
                yield return new ValidationResult("Status javnog nadmetanja mora da bude: PRVI_KRUG, DRUGI_KRUG_STARI i DRUGI_KRUG_NOVI.", new[] { "JavnoNadmetanjeCreateDTO" });
        }
    }
}
