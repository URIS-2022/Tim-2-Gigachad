using System.ComponentModel.DataAnnotations;


namespace DokumentiService.Entities
{
    /// <summary>
    /// Eksterni Dokument entity realni entitet
    /// </summary>
    public class EksterniDokumentEntity
    {
        /// <summary>
        /// EksterniDokument ID
        /// </summary>
        [Key]
        public Guid EksterniDokumentID{ get; set; }

        /// <summary>
        /// Putanja Eksternog dokumenta
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta { get; set; }
        /// <summary>
        /// Lista dokumenta zbog stranog kljuca
        /// </summary>
        public List<DokumentEntity>? Dokument { get; set; }
    }
}
