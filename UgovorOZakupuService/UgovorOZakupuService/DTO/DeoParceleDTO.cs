namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// DTO za deo parcele
    /// </summary>
    public class DeoParceleDTO
    {
        /// <summary>
		/// ID dela parcele.
		/// </summary>
		public Guid ID { get; set; } = Guid.Empty!;

        /// <summary>
        /// ID parcele.
        /// </summary>
        public ParcelaDTO Parcela { get; set; } = null!;

        /// <summary>
        /// ID kupca.
        /// </summary>
        public KupacDTO Kupac { get; set; } = null!;

        /// <summary>
        /// Redni broj dela parcele.
        /// </summary>
        public string RedniBroj { get; set; } = null!;

        /// <summary>
        /// Površina dela parcele.
        /// </summary>
        public int Povrsina { get; set; } = 0!;

        /// <summary>
        /// Broj nekretnina dela parcele.
        /// </summary>
        public int BrojNekretnina { get; set; } = 0;

        /// <summary>
        /// Obradivost dela parcele.
        /// </summary>
        public string Obradivost { get; set; } = null!;

        /// <summary>
        /// Obradivost dela parcele.
        /// </summary>
        public string Kultura { get; set; } = null!;

        /// <summary>
        /// Klasa dela parcele.
        /// </summary>
        public string Klasa { get; set; } = null!;

        /// <summary>
        /// Zaštićena zona dela parcele.
        /// </summary>
        public string ZasticenaZona { get; set; } = null!;

        /// <summary>
        /// Oblik svojine dela parcele.
        /// </summary>
        public string OblikSvojine { get; set; } = null!;

        /// <summary>
        /// Odvodnjavanje dela parcele.
        /// </summary>
        public bool Odvodnjavanje { get; set; } = false;
    }
}
