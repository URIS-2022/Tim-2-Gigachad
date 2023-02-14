using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	public interface IFizickoLiceRepository
	{
		List<FizickoLiceEntity> GetFizickaLica();

		FizickoLiceEntity? GetFizickoLiceByID(Guid fizickoLiceID);

		FizickoLiceDTO CreateFizickoLice(FizickoLiceCreateDTO fizickoLiceCreateDTO);

		void UpdateFizickoLice(FizickoLiceEntity fizickoLice);

		void DeleteFizickoLice(Guid fizickoLiceID);

		bool SaveChanges();
	}
}
