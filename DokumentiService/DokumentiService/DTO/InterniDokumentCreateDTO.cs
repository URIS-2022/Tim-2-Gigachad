using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    /// <summary>
    /// DTO za model InterniDokumentCreate
    /// </summary>
    public class InterniDokumentCreateDTO
    {
        /// <summary>
        /// Putanja dokumenta
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string? PutanjaDokumenta { get; set; }
    }
}
