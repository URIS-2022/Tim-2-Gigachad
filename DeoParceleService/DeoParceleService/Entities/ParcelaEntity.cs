using System.ComponentModel.DataAnnotations;

namespace DeoParceleService.Entities
{
	/// <summary>
	/// Model realnog entiteta parcela.
	/// </summary>
	public class ParcelaEntity
	{
		/// <summary>
		/// ID parcele.
		/// </summary>
		[Key]
		public Guid ID { get; set; } = Guid.Empty!;

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
	}
}
