using System.ComponentModel.DataAnnotations;

namespace UplataService.Models
{
    /// <summary>
	/// Model DTO-a za ažuriranje uplate.
	/// </summary>
    public class UplataUpdateDTO : IValidatableObject
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima ID.")]
        public string UplataID { get; set; } = null!;

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima javno nadmetanje.")]
        public string JavnoNadmetanjeID { get; set; } = null!;

        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required(ErrorMessage = "Uplata mora da ima kupca.")]
        public string KupacID { get; set; } = null!;

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

        /// <summary>
		/// Validacija za model DTO-a za azuriranje uplate.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Compare(DatumUplate.Value, DateTime.Now) > 0)
                yield return new ValidationResult("Datum uplate ne moze biti noviji od danasnjeg datuma", new[] { "KorisnikUpdateDTO" });
        }
    }
}
