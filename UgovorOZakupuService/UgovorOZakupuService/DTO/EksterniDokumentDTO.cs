namespace UgovorOZakupuService.DTO
{
    /// <summary>
    /// DTO za eksterni dokument
    /// </summary>
    public class EksterniDokumentDTO
    {
        /// <summary>
        /// Eksterni dokument ID
        /// </summary>
        public Guid EksterniDokumentID { get; set; } = Guid.Empty!;
        /// <summary>
        /// Putanj dokumenta
        /// </summary>
        public string PutanjaDokumenta { get; set; } = null!;
    }
}
