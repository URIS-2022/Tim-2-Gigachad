using System.ComponentModel.DataAnnotations;

namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za ažuriranje entiteta parcela.
	/// </summary>
	//: IValidatableObject
	public class ParcelaUpdateDTO 
	{
		/// <summary>
		/// ID parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima ID.")]
		[MinLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		[MaxLength(36, ErrorMessage = "GUID mora biti u ovom formatu (0x): xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.")]
		public string ID { get; set; } = null!;

		/// <summary>
		/// Oznaka parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima oznaku.")]
		[MaxLength(10, ErrorMessage = "Oznaka parcele ne sme da bude preko 10 karaktera.")]
		public string Oznaka { get; set; } = null!;

		/// <summary>
		/// Ukupna površina parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima ukupnu površinu.")]
		public int UkupnaPovrsina { get; set; } = 0!;

		/// <summary>
		/// Katastarska opština parcele.
		/// </summary>
		[Required(ErrorMessage = "Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.")]
		[MaxLength(20, ErrorMessage = "Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.")]
		public string KatastarskaOpstina { get; set; } = null!;

		/*/// <summary>
		/// Validacija za model DTO-a za ažuriranje entiteta parcela.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Enum.TryParse(KatastarskaOpstina.ToUpper(), out KatastarskaOpstinaParcele _KatastarskaOpstina))
				KatastarskaOpstina = _KatastarskaOpstina.ToString();
			else
				yield return new ValidationResult("Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.", new[] { "ParcelaUpdateDTO" });
		}*/
	}
}
