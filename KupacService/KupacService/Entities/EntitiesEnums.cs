namespace KupacService.Entities
{
    /// <summary>
    /// Enumeratori za modele entiteta.
    /// </summary>
    public static class EntitiesEnums
    {
        /// <summary>
        /// Enumerator za tip prioriteta kupca.
        /// </summary>
        public enum Prioritet
        {
            /// <summary>
            /// VLASNIK SISTEMA ZA NAVODNJAVANJE.
            /// </summary>
            VLASNIKSISTEMAZANAVODNJAVANJE,

            /// <summary>
            /// VLASNIK ZEMLJISTA KOJE SE GRANICI SA ZEMLJISTEM KOJE SE DAJE U ZAKUP
            /// </summary>
            VLASNIKZEMLJISTAKOJESEGRANICISAZEMLJISTEMKOJESEDAJEUZAKUP,

            /// <summary>
            /// POLJOPRIVREDNIK KOJI JE UPISAN U REGISTAR
            /// </summary>
            POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR,

            /// <summary>
            /// VLASNIK ZEMLJISTA KOJE JE NAJBLIZE ZEMLJISTU KOJE SE DAJE U ZAKUP
            /// </summary>
            VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP
        }
    }
}

