namespace ZalbaService.Entities
{
    /// <summary>
    /// Enumeratori za modele entiteta.
    /// </summary>
    public static class EntitiesEnums
    {
        /// <summary>
        /// Enumerator za status žalbe.
        /// </summary>
        public enum StatusZalbe
        {
            /// <summary>
            /// Otvorena.
            /// </summary>
            OTVORENA,

            /// <summary>
            /// Usvojena.
            /// </summary>
            USVOJENA,

            /// <summary>
            /// Odbijena.
            /// </summary>
            ODBIJENA
        }

        /// <summary>
        /// Enumerator za tip žalbe.
        /// </summary>
        public enum TipZalbe
        {
            /// <summary>
            /// Žalba na odluku o davanju na korišćenje.
            /// </summary>
            ZALBA_NA_ODLUKU_O_DAVANJU_NA_KORISCENJE,

            /// <summary>
            /// Žalba na odluku o davanju u zakup.
            /// </summary>
            ZALBA_NA_ODLUKU_O_DAVANJU_U_ZAKUP,

            /// <summary>
            /// Žalba na tok javnog nadmetanja.
            /// </summary>
            ZALBA_NA_TOK_JAVNOG_NADMETANJA

        }

        /// <summary>
        /// Enumerator za radnju žalbe.
        /// </summary>
        public enum RadnjaZalbe
        {
            /// <summary>
            /// Javno nadmetanje ide u drugi krug sa novim uslovima.
            /// </summary>
            JN_IDE_U_DRUGI_KRUG_SA_NOVIM_USLOVIMA,

            /// <summary>
            /// Javno nadmetanje ide u drugi krug sa starim uslovima.
            /// </summary>
            JN_IDE_U_DRUGI_KRUG_SA_STARIM_USLOVIMA,

            /// <summary>
            /// Javno nadmetanje ne ide u drugi krug.
            /// </summary>
            JN_NE_IDE_U_DRUGI_KRUG
        }
    }
}
