using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    /// <summary>
    /// Model dto za Create eksternog dokumenta
    /// </summary>
    public class EksterniDokumentCreateDTO
    {
        /// <summary>
        /// Putanja dokumenta
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta { get; set; }
    }
}
