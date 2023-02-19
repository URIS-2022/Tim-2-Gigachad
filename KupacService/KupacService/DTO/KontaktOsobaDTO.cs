namespace KupacService.DTO
{
    /// <summary>
    /// Model DTO-a za entitet kontakt osoba.
    /// </summary>
    public class KontaktOsobaDTO
    {
        /// <summary>
        /// ID kontakt osobe.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Puno ime kontakt osobe.
        /// </summary>
        public string PunoIme { get; set; } = null!;

        /// <summary>
        /// Telefon kontakt osobe.
        /// </summary>
        public string Telefon { get; set; } = null!;

        /// <summary>
        /// Funkcija kontakt osobe.
        /// </summary>
        public string Funkcija { get; set; } = null!;
    }
}
