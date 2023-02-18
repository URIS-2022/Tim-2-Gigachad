using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za entitet fizičko lice.
	/// </summary>
	public interface IFizickoLiceRepository
	{
		/// <summary>
		/// Vraća listu fizičkih lica.
		/// </summary>
		/// <returns>Vraća listu fizičkih lica.</returns>
		List<FizickoLiceEntity> GetFizickaLica();

		/// <summary>
		/// Vraća jedno fizičko lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		/// <returns>Vraća specifirano fizičko lice.</returns>
		FizickoLiceEntity? GetFizickoLiceByID(Guid fizickoLiceID);

		/// <summary>
		/// Dodaje novo fizičko lice.
		/// </summary>
		/// <param name="fizickoLiceCreateDTO">DTO za kreiranje fizičkog lica.</param>
		/// <returns>Vraća DTO kreiranog fizičkog lica.</returns>
		FizickoLiceDTO CreateFizickoLice(FizickoLiceCreateDTO fizickoLiceCreateDTO);

		/// <summary>
		/// Briše fizičko lice.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		void DeleteFizickoLice(Guid fizickoLiceID);

		/// <summary>
		/// Sačuva sve promene.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
