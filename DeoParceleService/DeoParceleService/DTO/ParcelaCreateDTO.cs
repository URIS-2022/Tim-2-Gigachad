﻿using System.ComponentModel.DataAnnotations;

namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za kreiranje entiteta parcela.
	/// </summary>
	//: IValidatableObject
	public class ParcelaCreateDTO
	{
		/// <summary>
		/// Ukupna površina parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima ukupnu površinu.")]
		public decimal UkupnaPovrsina { get; set; } = 0!;

		/// <summary>
		/// Katastarska opština parcele.
		/// </summary>
		[Required(ErrorMessage = "Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.")]
		[MaxLength(20, ErrorMessage = "Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.")]
		public string KatastarskaOpstina { get; set; } = null!;

		/*/// <summary>
		/// Validacija za model DTO-a za kreiranje entiteta parcela.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Enum.TryParse(KatastarskaOpstina.ToUpper(), out KatastarskaOpstinaParcele _KatastarskaOpstina))
				KatastarskaOpstina = _KatastarskaOpstina.ToString();
			else
				yield return new ValidationResult("Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.", new[] { "ParcelaCreateDTO" });
		}*/
	}
}
