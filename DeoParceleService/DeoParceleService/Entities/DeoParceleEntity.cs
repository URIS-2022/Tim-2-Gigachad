using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeoParceleService.Entities
{
	/// <summary>
	/// Model realnog entiteta deo parcele.
	/// </summary>
	public class DeoParceleEntity
	{
		/// <summary>
		/// ID dela parcele.
		/// </summary>
		[Key]
		public Guid ID { get; set; } = Guid.Empty!;

		/// <summary>
		/// ID parcele.
		/// </summary>
		[ForeignKey("Parcela")]		
		public Guid ParcelaID { get; set; } = Guid.Empty!;

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
		/// Redni broj dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima redni broj.")]
		[MinLength(5, ErrorMessage = "Redni broj dela parcele mora da ima 5 karaktera.")]
		[MaxLength(5, ErrorMessage = "Redni broj dela parcele mora da ima 5 karaktera.")]
		public string RedniBroj { get; set; } = null!;

		/// <summary>
		/// Površina dela parcele.
		/// </summary>
		[Required(ErrorMessage = "Deo parcele mora da ima površinu.")]
		public int Povrsina { get; set; } = 0!;

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
	}
}
