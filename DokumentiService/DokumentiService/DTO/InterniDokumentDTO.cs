namespace DokumentiService.DTO
{
    /// <summary>
    /// Interni dokument DTO
    /// </summary>
    public class InterniDokumentDTO
    {
        /// <summary>
        /// Interni dokument ID
        /// </summary>
        public Guid InterniDokumentID { get; set; } = Guid.Empty!;
        /// <summary>
        /// Putanja Dokumenta
        /// </summary>
        public string PutanjaDokumenta { get; set; } = null!;
    }
}
