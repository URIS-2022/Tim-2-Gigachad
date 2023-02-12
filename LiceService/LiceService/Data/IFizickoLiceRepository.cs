using LiceService.Entities;

namespace LiceService.Data
{
	public interface IFizickoLiceRepository
	{
		List<FizickoLiceEntity> GetFizickaLica();

		FizickoLiceEntity GetFizickoLiceByID(Guid fizickoLiceID);

		FizickoLiceEntity CreateFizickoLice(FizickoLiceEntity fizickoLice);

		void UpdateFizickoLice(FizickoLiceEntity fizickoLice);

		void DeleteFizickoLice(Guid fizickoLiceID);

		bool SaveChanges();
	}
}
