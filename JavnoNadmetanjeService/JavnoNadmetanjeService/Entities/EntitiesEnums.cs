namespace JavnoNadmetanjeService.Entities
{
    /// <summary>
	/// Enumeratori za modele entiteta.
	/// </summary>
    public class EntitiesEnums
    {
        /// <summary>
		/// Enumerator za tip javnog nadmetanja.
		/// </summary>
		public enum TipNadmetanja
        {
            /// <summary>
            /// Nadmetanje za prodaju zemljišta.
            /// </summary>
            JAVNA_LICITACIJA,

            /// <summary>
            /// Javno otvaranje zatvorenih ponuda
            /// </summary>
            OTVARANJE_ZATVORENIH_PONUDA
        }

        /// <summary>
		/// Enumerator za opstinu javnog nadmetanja.
		/// </summary>
        public enum Opstina
        {
            /// <summary>
            /// Katastarska opstina Cantavir.
            /// </summary>
            CANTAVIR,

            /// <summary>
            /// Katastarska opstina Backi Vinogradi.
            /// </summary>
            BACKI_VINOGRADI,

            /// <summary>
            /// Katastarska opstina Bikovo.
            /// </summary>
            BIKOVO,

            /// <summary>
            /// Katastarska opstina Djudjin.
            /// </summary>
            DJUDJIN,

            /// <summary>
            /// Katastarska opstina Zednik.
            /// </summary>
            ZEDNIK,

            /// <summary>
            /// Katastarska opstina Tavankut.
            /// </summary>
            TAVANKUT,

            /// <summary>
            /// Katastarska opstina Bajmok.
            /// </summary>
            BAJMOK,

            /// <summary>
            /// Katastarska opstina Donji Grad.
            /// </summary>
            DONJI_GRAD,

            /// <summary>
            /// Katastarska opstina Stari Grad.
            /// </summary>
            STARI_GRAD,

            /// <summary>
            /// Katastarska opstina Novi Grad.
            /// </summary>
            NOVI_GRAD,

            /// <summary>
            /// Katastarska opstina Palic.
            /// </summary>
            PALIC
        }

        /// <summary>
		/// Enumerator za status javnog nadmetanja.
		/// </summary>
        public enum StatusNadmetanja
        {
            /// <summary>
            /// Prvi krug
            /// </summary>
            PRVI_KRUG,

            /// <summary>
            /// Drugi krug sa starim uslovima
            /// </summary>
            DRUGI_KRUG_STARI,

            /// <summary>
            /// Drugi krug sa novim uslovima
            /// </summary>
            DRUGI_KRUG_NOVI
        }
    }
}
