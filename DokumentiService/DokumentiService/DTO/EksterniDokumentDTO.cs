namespace DokumentiService.DTO
{
    /// <summary>
    /// Model Eksternog dokumenta DTO
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
