namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
    /// Model DTO-a za entitet fizicko lice.
    /// </summary>
    public class FizickoLiceDTO
    {
        /// <summary>
        /// ID fizickog lica.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// JMBG fizickog lica.
        /// </summary>
        public string JMBG { get; set; } = null!;

        /// <summary>
        /// Puno ime fizickog lica.
        /// </summary>
        public string PunoIme { get; set; } = null!;
    }
}
