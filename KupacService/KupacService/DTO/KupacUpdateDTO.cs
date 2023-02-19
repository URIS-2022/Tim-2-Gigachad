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
        public string KupacID { get; set; } = null!;

        /// <summary>
        /// ID lica.
        /// </summary>
        [Required(ErrorMessage = "Lice mora da ima ID")]
        [MinLength(36, ErrorMessage = "Guid mora da ima minimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        [MaxLength(36, ErrorMessage = "Guid mora da ima maksimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        public string LiceID { get; set; } = null!;

        /// <summary>
        /// ID ovlascenjog lica.
        /// </summary>
        [Required(ErrorMessage = "Ovlasceno lice mora da ima ID")]
        [MinLength(36, ErrorMessage = "Guid mora da ima minimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        [MaxLength(36, ErrorMessage = "Guid mora da ima maksimalno 36 karaktera u formatu xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")]
        public string OvlascenoLiceID { get; set; } = null!;

        /// <summary>
        /// Prioritet kupca.
        /// </summary>

        [Required(ErrorMessage = "Kupac mora da ima validan prioritet")]
        [MaxLength(50, ErrorMessage = "Prioritet moze da ima maksimalno 100 karaktera")]
        public string Prioritet { get; set; } = null!;

        /// <summary>
        /// Lice ima/nema zabranu.
        /// </summary>
        [Required(ErrorMessage = "Mora da postoji informacija o zabrani za kupca")]
        public bool ImaZabranu { get; set; } 

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
        public int BrojKupovina { get; set; }

        /// <summary>
        /// Validacija za model DTO-a za kreiranje kupca.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BrojKupovina < 0)
                yield return new ValidationResult("Kupac ne može da ima manje od 0 kupovina.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane != null && DatumZavrsetkaZabrane != null && DateTime.Compare(DatumPocetkaZabrane.Value, DateTime.Now) > 0)
                yield return new ValidationResult("Korisnik ne može da ima noviji datum pocetka od trenutnog datuma.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane == null && DatumZavrsetkaZabrane != null)
                yield return new ValidationResult("Kupac ne može da ima datum pocetka zabrane a nema datum zavrsetka zabrane.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane != null && DatumZavrsetkaZabrane == null)
                yield return new ValidationResult("Kupac ne može da nema datum pocetka zabrane a ima datum zavrsetka zabrane.", new[] { "KupacCreateDTO" });

            if (DatumPocetkaZabrane != null && DatumZavrsetkaZabrane != null && DateTime.Compare(DatumPocetkaZabrane.Value, DatumZavrsetkaZabrane.Value) >= 0)
                yield return new ValidationResult("Korisnik ne može da ima isti ili noviji datum pocetka od datuma zavrsetka zabrane.", new[] { "KupacCreateDTO" });
            if (ImaZabranu == true && (DatumPocetkaZabrane == null || DatumZavrsetkaZabrane == null))
                yield return new ValidationResult("Ako kuapc ima zabranu mora da ima i datum pocetka i datum zavrsetka zabrane.");
            if (ImaZabranu == false && (DatumPocetkaZabrane != null || DatumZavrsetkaZabrane != null))
                yield return new ValidationResult("Ako kuapc nema zabranu ne sme da ima ni datum pocetka niti datum zavrsetka zabrane.");

            if (Enum.TryParse(Prioritet.ToUpper(), out Prioritet tempPrioritet))
                Prioritet = tempPrioritet.ToString();
            else
                yield return new ValidationResult("Tip korisnika mora da bude: VLASNIKSISTEMAZANAVODNJAVANJE, VLASNIKZEMLJISTAKOJESEGRANICISAZEMLJISTEMKOJESEDAJEUZAKUP, POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR, VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP.", new[] { "KupacCreateDTO" });
        }
    }
}