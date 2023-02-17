using DeoParceleService.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje entiteta deo parcela.
	/// </summary>
	//: IValidatableObject
	public class DeoParceleUpdateDTO
	{
		/// <summary>
		/// ID dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ID { get; set; } = null!;

		/// <summary>
		/// ID parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ParcelaID { get; set; } = null!;

		/// <summary>
		/// Parcela.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima parcelu.")]
		public ParcelaEntity Parcela { get; set; } = null!;

		/// <summary>
		/// ID kupca.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima kupca.")]
		public Guid KupacID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Površina dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima površinu.")]
		public decimal Povrsina { get; set; } = 0!;

		/// <summary>
		/// Broj nekretnina dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima broj nekretnina.")]
		public int BrojNekretnina { get; set; } = 0;

		/// <summary>
		/// Obradivost dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Obradivost mora da bude: OBRADIVO, OSTALO.")]
		[MaxLength(8, ErrorMessage = "Obradivost mora da bude: OBRADIVO, OSTALO.")]
		public string Obradivost { get; set; } = null!;

		/// <summary>
		/// Obradivost dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Kultura mora da bude: NJIVE, VRTOVI, VOCNJACI, VINOGRADI, LIVADE, PASNJACI, SUME, MOCVARE.")]
		[MaxLength(10, ErrorMessage = "Kultura mora da bude: NJIVE, VRTOVI, VOCNJACI, VINOGRADI, LIVADE, PASNJACI, SUME, MOCVARE.")]
		public string Kultura { get; set; } = null!;

		/// <summary>
		/// Klasa dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Klasa mora da bude: I, II, III, IV, V, VI, VII, VIII.")]
		[MaxLength(4, ErrorMessage = "Klasa mora da bude: I, II, III, IV, V, VI, VII, VIII.")]
		public string Klasa { get; set; } = null!;

		/// <summary>
		/// Zaštićena zona dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Zaštićena zona mora da bude: I, II, III, IV.")]
		[MaxLength(3, ErrorMessage = "Zaštićena zona mora da bude: I, II, III, IV.")]
		public string ZasticenaZona { get; set; } = null!;

		/// <summary>
		/// Oblik svojine dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Klasa mora da bude: PRIVATNA_SVOJINA, DRZAVNA_SVOJINA, DRUSTVENA_SVOJINA, ZADRUZNA_SVOJINA, MESOVITA_SVOJINA, OSTALE_SVOJINE.")]
		[MaxLength(20, ErrorMessage = "Klasa mora da bude: PRIVATNA_SVOJINA, DRZAVNA_SVOJINA, DRUSTVENA_SVOJINA, ZADRUZNA_SVOJINA, MESOVITA_SVOJINA, OSTALE_SVOJINE.")]
		public string OblikSvojine { get; set; } = null!;

		/// <summary>
		/// Odvodnjavanje dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima odvodnjavanje.")]
		public bool Odvodnjavanje { get; set; } = false;

		/*/// <summary>
		/// Validacija za model DTO-a za ažuriranje entiteta deo parcela.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Enum.TryParse(Obradivost.ToUpper(), out ObradivostDelaParcele _Obradivost))
				Obradivost = _Obradivost.ToString();
			else
				yield return new ValidationResult("Obradivost mora da bude: OBRADIVO, OSTALO.", new[] { "DeoParceleUpdateDTO" });

			if (Enum.TryParse(Kultura.ToUpper(), out KulturaDelaParcele _Kultura))
				Kultura = _Kultura.ToString();
			else
				yield return new ValidationResult("Kultura mora da bude: NJIVE, VRTOVI, VOCNJACI, VINOGRADI, LIVADE, PASNJACI, SUME, MOCVARE.", new[] { "DeoParceleUpdateDTO" });
		}*/
	}
}
