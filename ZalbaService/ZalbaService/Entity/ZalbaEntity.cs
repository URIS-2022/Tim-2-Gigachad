using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZalbaService.Entity
{
    public class ZalbaEntity
    {
        public ZalbaEntity() { }

        /// <summary>
		/// ID zalbe.
		/// </summary>
        [Key]
        public Guid ZalbaID { get; set; }

        /// <summary>
		/// ID kupca.
		/// </summary>
        [ForeignKey("KupacEntity")]
        public Guid KupacID { get; set; }

        /// <summary>
		/// Tip zalbe.
		/// </summary>
        public string? TipZalbe { get; set;}

        /// <summary>
		/// Datum podnosenja zalbe.
		/// </summary>
        public DateTime? DatumPodnosenja { get; set; }

        /// <summary>
		/// Razlog zalbe.
		/// </summary>
        public string Razlog { get; set; }

        /// <summary>
		/// Obrazlozenje zalbe.
		/// </summary>
        public string Obrazlozenje { get; set; }

        /// <summary>
		/// Status zalbe.
		/// </summary>
        public string StatusZalbe { get; set; }

        /// <summary>
		/// Radnja zalbe.
		/// </summary>
        public string RadnjaZalbe { get; set; }
    }
}
