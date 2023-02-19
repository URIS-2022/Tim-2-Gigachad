using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
	/// Model DTO-a za azuriranje licitacija entiteta.
	/// </summary>
    public class LicitacijaUpdateDTO : IValidatableObject
    {
        /// <summary>
		/// ID licitacije.
		/// </summary>
		[Required(ErrorMessage = "Licitacija mora da ima ID.")]
        public Guid ID { get; set; }

        /// <summary>
        /// Datum licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima datum pocetka licitacije.")]
        public DateTime? DatumLicitacije { get; set; } = null!;

        /// <summary>
        /// Rok za dostavljanje prijava, datum i sat.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima rok kad se licitacija zavrsava.")]
        public DateTime? Rok { get; set; } = null!;

        /// <summary>
        /// OgrnMaxPovrs licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima ogranicenje max povrsina.")]
        public int OgrnMaxPovrs { get; set; }

        /// <summary>
        /// Korak cene licitacije.
        /// </summary>
        [Required(ErrorMessage = "Licitacija mora da ima korak cene.")]
        public int KorakCene { get; set; }

        /// <summary>
        /// Validacija za model DTO-a za azuriranje licitacije.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DatumLicitacije == null && Rok != null)
                yield return new ValidationResult("Licitacija ne može da ima datum pocetka licitacije, a da nema datum roka licitacije.", new[] { "LicitacijaCreateDTO" });

            if (DatumLicitacije != null && Rok == null)
                yield return new ValidationResult("Licitacija ne može da nema datum pocetka licitacije, a da ima datum roka zabrane.", new[] { "LicitacijaCreateDTO" });

            if (DatumLicitacije != null && Rok != null && DateTime.Compare(DatumLicitacije.Value, Rok.Value) >= 0)
                yield return new ValidationResult("Licitacija ne može da ima isti datum ili datum pre datuma pocetka licitacije.", new[] { "LicitacijaCreateDTO" });
        }
    }
}
