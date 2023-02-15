using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KupacService.Entities.EntitiesEnums;

namespace KupacService.Entities
{
    /// <summary>
    /// Model DTO-a za kreiranje kupca.
    /// </summary>
    public class KupacUpdateDTO: IValidatableObject
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required (ErrorMessage = "Kupac mora da ima ID.")]
        [MinLength(36, ErrorMessage = "Guid mora da ima minimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        [MaxLength(36, ErrorMessage = "Guid mora da ima maksimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        public string KupacID { get; set; } = string.Empty!;

        /// <summary>
        /// ID lica.
        /// </summary>
        [Required (ErrorMessage = "Lice mora da ima ID")]
        public Guid LiceID { get; set; }

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        [Required(ErrorMessage = "Ovlasceno lice mora da ima ID")]
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// ID javnog nadmetanja.
        /// </summary>
        [Required(ErrorMessage = "Javno nadmetanje mora da ima ID")]
        public Guid JavnoNadmetanjeID { get; set; }

        /// <summary>
        /// Prioritet kupca.
        /// </summary>

        [Required(ErrorMessage = "Kupac mora da ima validan prioritet")]
        [MaxLength(50, ErrorMessage = "Prioritet moze da ima maksimalno 50 karaktera")]
        public string Prioritet { get; set; } = string.Empty!;

        /// <summary>
        /// Lice ima/nema zabranu.
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji informacija o zabrani za kupca")]
        public bool ImaZabranu { get; set; } = false!;

        /// <summary>
        /// Datum pocetka zabrane.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum zavrsetka zabrane.
        /// </summary>
        public DateTime? DatumZavrsetkaZabrane { get; set; }

        /// <summary>
        /// Broj kupovina kupca.
        /// </summary>
        [Required(ErrorMessage = "Kupac mora da ima podatke o broju kupovina")]
        public int BrojKupovina { get; set; } = 0!;

        /// <summary>
        /// Validacija za model DTO-a za kreiranje kupca.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BrojKupovina < 0)
                yield return new ValidationResult("Kupac ne može da ima manje od 0 kupovina.", new[] { "KupacCreateDTO" });

            if (DateTime.Compare(DatumPocetkaZabrane.Value, DateTime.Now) > 0)
                yield return new ValidationResult("Korisnik ne može da ima noviji datum pocetka od trenutnog datuma.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane == null && DatumZavrsetkaZabrane != null)
                yield return new ValidationResult("Kupac ne može da ima datum pocetka zabrane a nema datum zavrsetka zabrane.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane != null && DatumZavrsetkaZabrane == null)
                yield return new ValidationResult("Kupac ne može da nema datum pocetka zabrane a ima datum zavrsetka zabrane.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane != null && DatumZavrsetkaZabrane != null)
                if (DateTime.Compare(DatumPocetkaZabrane.Value, DatumZavrsetkaZabrane.Value) >= 0)
                    yield return new ValidationResult("Korisnik ne može da ima isti ili noviji datum pocetka od datuma zavrsetka zabrane.", new[] { "KupacCreateDTO" });

            if (Enum.TryParse(Prioritet.ToUpper(), out Prioritet tempPrioritet))
                Prioritet = tempPrioritet.ToString();
            else
                yield return new ValidationResult("Tip korisnika mora da bude: VLASNIKSISTEMAZANAVODNJAVANJE, VLASNIKZEMLJISTAKOJESEGRANICISAZEMLJISTEMKOJESEDAJEUZAKUP, POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR, VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP.", new[] { "KupacCreateDTO" });
        }
    }
}