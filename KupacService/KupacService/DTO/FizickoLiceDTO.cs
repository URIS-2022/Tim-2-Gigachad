namespace KupacService.DTO
{
    /// <summary>
    /// Model DTO-a za entitet fizičko lice.
    /// </summary>
    public class FizickoLiceDTO
    {
        /// <summary>
        /// ID fizičkog lica.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// JMBG fizičkog lica.
        /// </summary>
        public string JMBG { get; set; } = null!;

        /// <summary>
        /// Puno ime fizičkog lica.
        /// </summary>
        public string PunoIme { get; set; } = null!;
    }
}
