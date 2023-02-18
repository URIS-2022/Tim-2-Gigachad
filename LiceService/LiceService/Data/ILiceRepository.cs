using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za entitet lice.
	/// </summary>
	public interface ILiceRepository
	{
		/// <summary>
		/// Vraća listu lica.
		/// </summary>
		/// <returns>Vraća listu lica.</returns>
		List<LiceEntity> GetLica();

		/// <summary>
		/// Vraća jedno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <returns>Vraća specifirano lice.</returns>
		LiceEntity? GetLiceByID(Guid liceID);

		/// <summary>
		/// Dodaje novo lice.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <returns>Vraća DTO kreiranog lica.</returns>
		LiceDTO CreateLice(LiceCreateDTO liceCreateDTO);

		/// <summary>
		/// Briše lice.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		void DeleteLice(Guid liceID);

		/// <summary>
		/// Sačuva sve promene.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
