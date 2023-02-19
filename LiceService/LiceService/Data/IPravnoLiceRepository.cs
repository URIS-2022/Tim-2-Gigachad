using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za entitet pravno lice.
	/// </summary>
	public interface IPravnoLiceRepository
	{
		/// <summary>
		/// Vraća listu pravnih lica.
		/// </summary>
		/// <returns>Vraća listu pravnih lica.</returns>
		List<PravnoLiceEntity> GetPravnaLica();

		/// <summary>
		/// Vraća jedno pravno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		/// <returns>Vraća specifirano pravno lice.</returns>
		PravnoLiceEntity? GetPravnoLiceByID(Guid pravnoLiceID);

		/// <summary>
		/// Dodaje novo pravno lice.
		/// </summary>
		/// <param name="pravnoLiceCreateDTO">DTO za kreiranje pravnog lica.</param>
		/// <returns>Vraća DTO kreiranog pravnog lica.</returns>
		PravnoLiceDTO CreatePravnoLice(PravnoLiceCreateDTO pravnoLiceCreateDTO);

		/// <summary>
		/// Briše pravno lice.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		void DeletePravnoLice(Guid pravnoLiceID);

		/// <summary>
		/// Sačuva sve promene.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
