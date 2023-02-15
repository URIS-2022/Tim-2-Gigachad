namespace KupacService.Entities
{
    /// <summary>
    /// Enumeratori za modele entiteta.
    /// </summary>
    public static class EntitiesEnums
    {
        /// <summary>
        /// Enumerator za tipa korisnika.
        /// </summary>
        public enum Prioritet
        {
            /// <summary>
            /// Administrator.
            /// </summary>
            VLASNIKSISTEMAZANAVODNJAVANJE,

            /// <summary>
            /// Komisija.
            /// </summary>
            VLASNIKZEMLJISTAKOJESEGRANICISAZEMLJISTEMKOJESEDAJEUZAKUP,

            /// <summary>
            /// Operater.
            /// </summary>
            POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR,

            /// <summary>
            /// Licitant.
            /// </summary>
            VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP
        }
    }
}

