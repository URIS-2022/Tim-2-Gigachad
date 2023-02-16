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
		/// Vraća listu lica iz konteksta.
		/// </summary>
		/// <returns>Vraća listu lica.</returns>
		List<LiceEntity> GetLica();

		/// <summary>
		/// Vraća jedno lice iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <returns>Vraća specifirano lice.</returns>
		LiceEntity? GetLiceByID(Guid liceID);

		/// <summary>
		/// Dodaje novo lice u kontekst.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <returns>Vraća DTO kreiranog lica.</returns>
		LiceDTO CreateLice(LiceCreateDTO liceCreateDTO);

		/// <summary>
		/// Briše lice iz konteksta.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		void DeleteLice(Guid liceID);

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
