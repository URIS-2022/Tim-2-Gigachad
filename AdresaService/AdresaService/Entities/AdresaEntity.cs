using System.ComponentModel.DataAnnotations;

namespace AdresaService.Entities
{
    public class AdresaEntity
    {
        /// <summary>
        /// ID adrese.
        /// </summary>
        //[Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Ulica.
        /// </summary>
        [MaxLength(100)]
        public string? Ulica { get; set; }

        /// <summary>
        /// Broj ulice.
        /// </summary>
        public int Broj { get; set; }

        /// <summary>
        /// Mesto.
        /// </summary>
        [MaxLength(100)]
        public string? Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese.
        /// </summary>
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// Država broj adrese.
        /// </summary>
        [MaxLength(100)]
        public string? Drzava { get; set; }
    }
}
