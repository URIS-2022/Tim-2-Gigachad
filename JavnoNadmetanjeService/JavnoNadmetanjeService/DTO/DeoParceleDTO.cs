namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
	/// Model DTO-a za entitet deo parcele.
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
        public Guid ParcelaID { get; set; } = Guid.Empty!;

        /// <summary>
        /// ID kupca.
        /// </summary>
        public Guid KupacID { get; set; } = Guid.Empty!;

        /// <summary>
        /// Površina dela parcele.
        /// </summary>
        public decimal Povrsina { get; set; } = 0!;

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
