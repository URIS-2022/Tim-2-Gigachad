using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Data
{
    /// <summary>
	/// Interfejs od repozitorijuma za entitet javno-nadmetanje.
	/// </summary>
    public interface IJavnoNadmetanjeRepository
    {
        /// <summary>
		/// Vraća listu javnih nadmetanja.
		/// </summary>
		/// <returns>Vraća listu korisnika.</returns>
        List<JavnoNadmetanjeEntity> GetJavnaNadmetanja();

        /// <summary>
		/// Vraća jedno javno nadmetanje na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <returns>Vraća specifiranog javno nadmetanje.</returns>
        JavnoNadmetanjeEntity? GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID);

        /// <summary>
		/// Dodaje novo javno nadmetanje.
		/// </summary>
		/// <param name="javnoNadmetanjeCreateDTO">DTO za kreiranje javnog nadmetanja.</param>
		/// <returns>Vraća DTO kreiranog javnog nadmetanja.</returns>
        JavnoNadmetanjeDTO CreateJavnoNadmetanje(JavnoNadmetanjeCreateDTO javnoNadmetanjeCreateDTO);

        /// <summary>
        /// Brise javno nadmetanje.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
        void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID);

        /// <summary>
		/// Sacuva sve promene.
		/// </summary>
		/// <returns>Vraca boolean o potvrdi sacuvanih promena.</returns>
        bool SaveChanges();
    }
}
