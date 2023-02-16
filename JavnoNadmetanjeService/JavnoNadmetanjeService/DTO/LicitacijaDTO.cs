using System.ComponentModel.DataAnnotations.Schema;

namespace JavnoNadmetanjeService.DTO
{
    /// <summary>
	/// Model DTO-a za licitacija entitet.
	/// </summary>
    public class LicitacijaDTO
    {
        /// <summary>
		/// ID licitacije.
		/// </summary>
		public Guid ID { get; set; }

        /// <summary>
		/// starni kljuc - ID javnog nadmetanja.
		/// </summary>
		[ForeignKey("JavnoNadmetanjeEntity")]
        public Guid JavnoNadmetanjeID { get; set; }
    }
}
