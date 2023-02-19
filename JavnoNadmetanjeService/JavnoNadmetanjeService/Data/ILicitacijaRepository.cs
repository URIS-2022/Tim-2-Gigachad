using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace LicitacijaService.Data
{
    /// <summary>
	/// Interfejs od repozitorijuma za entitet licitacija.
	/// </summary>
    public interface ILicitacijaRepository
    {
        /// <summary>
		/// Vraća listu licitacija.
		/// </summary>
		/// <returns>Vraća listu licitacija.</returns>
        List<LicitacijaEntity> GetLicitacije();

        /// <summary>
		/// Vraća jedno licitaciju na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="licitacijaID">ID licitacije.</param>
		/// <returns>Vraća specifiranu licitaciju.</returns>
        LicitacijaEntity? GetLicitacijaByID(Guid licitacijaID);

        /// <summary>
		/// Dodaje novu licitaciju.
		/// </summary>
		/// <param name="licitacijaCreateDTO">DTO za kreiranje licitacije.</param>
		/// <returns>Vraća DTO kreirane licitacije.</returns>
        LicitacijaDTO CreateLicitacija(LicitacijaCreateDTO licitacijaCreateDTO);

        /// <summary>
        /// Brise licitaciju.
        /// </summary>
        /// <param name="licitacijaID">ID licitacije.</param>
		void DeleteLicitacija(Guid licitacijaID);

        /// <summary>
		/// Sacuva sve promene.
		/// </summary>
		/// <returns>Vraca boolean o potvrdi sacuvanih promena.</returns>
        bool SaveChanges();
    }
}
