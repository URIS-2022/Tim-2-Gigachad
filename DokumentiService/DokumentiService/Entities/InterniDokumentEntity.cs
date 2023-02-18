using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentiService.Entities
{
    /// <summary>
    /// Model entita internog dokumenta
    /// </summary>
    public class InterniDokumentEntity
    {
        /// <summary>
        /// ID internog dokumenta
        /// </summary>
        [Key]
        public Guid InterniDokumentID { get; set; }

        /// <summary>
        /// Putanja internog dokumenta
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? PutanjaDokumenta  { get; set; }

        /// <summary>
        /// lista internih dokumenata zbog stranog kljuca
        /// </summary>
        public List<DokumentEntity>? Dokument { get; set; }
    }
}
