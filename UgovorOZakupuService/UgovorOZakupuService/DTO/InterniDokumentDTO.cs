namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// DTO za interni dokument
    /// </summary>
    public class InterniDokumentDTO
    {
        /// <summary>
        /// Interni dokument ID
        /// </summary>
        public Guid InterniDokumentID { get; set; }
        /// <summary>
        /// Putanja Dokumenta
        /// </summary>
        public string PutanjaDokumenta { get; set; }
    }
}
