namespace UgovorOZakupuService.Entities
{
    /// <summary>
    /// Model enumeratora koriscenih u ugovoru
    /// </summary>
    public class EntitesEnums
    {
        /// <summary>
        /// Enum za tip garancije
        /// </summary>
        public enum TipGarancije
        {
            /// <summary>
            /// Jemstvo
            /// </summary>
            JEMSTVO,

            /// <summary>
            /// Bankarska garancija.
            /// </summary>
            BANKARSKAGARANCIJA,

            /// <summary>
            /// Garancija nekretninom.
            /// </summary>
            GARANCIJANEKRETNINOM,

            /// <summary>
            /// Zirantska.
            /// </summary>
            ZIRANTSKA,

            /// <summary>
            /// Uplata gotovinom
            /// </summary>
            UPLATAGOTOVINOM
        }
    }
}
