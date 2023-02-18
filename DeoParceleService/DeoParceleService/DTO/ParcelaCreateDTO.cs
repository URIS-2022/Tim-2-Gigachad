﻿using System.ComponentModel.DataAnnotations;
using static DeoParceleService.Entities.EntitiesEnums;

namespace DeoParceleService.DTO
{
	/// <summary>
	/// Model DTO-a za kreiranje entiteta parcela.
	/// </summary>
	public class ParcelaCreateDTO : IValidatableObject
	{
		/// <summary>
		/// ID kupca.
		/// </summary>
		[Required(ErrorMessage = "Parcele mora da ima kupca.")]
		public Guid KupacID { get; set; } = Guid.Empty!;

		/// <summary>
		/// Oznaka parcele.
		/// </summary>
		[Required(ErrorMessage = "Parcela mora da ima oznaku.")]
		[MinLength(10, ErrorMessage = "Oznaka parcele mora da ima 10 karaktera.")]
		[MaxLength(10, ErrorMessage = "Oznaka parcele mora da ima 10 karaktera.")]
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

		/// <summary>
		/// Validacija za model DTO-a za kreiranje entiteta parcela.
		/// </summary>
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			Oznaka = Oznaka.ToUpper();

			if (Enum.TryParse(KatastarskaOpstina.ToUpper(), out KatastarskaOpstinaParcele _KatastarskaOpstina))
				KatastarskaOpstina = _KatastarskaOpstina.ToString();
			else
				yield return new ValidationResult("Katastarska opština mora da bude: CANTAVIR, BACKI_VINOGRADI, BIKOVO, DJUDJIN, ZEDNIK, TAVANKUT, BAJMOK, DONJI_GRAD, STARI_GRAD, NOVI_GRAD, PALIC.", new[] { "ParcelaCreateDTO" });
		}
	}
}
