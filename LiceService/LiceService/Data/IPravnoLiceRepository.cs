using LiceService.Entities;

namespace LiceService.Data
{
	public interface IPravnoLiceRepository
	{
		List<PravnoLiceEntity> GetPravnaLica();

		PravnoLiceEntity GetPravnoLiceByID(Guid pravnoLiceID);

		PravnoLiceEntity CreatePravnoLice(PravnoLiceEntity pravnoLice);

		void UpdatePravnoLice(PravnoLiceEntity pravnoLice);

		void DeletePravnoLice(Guid pravnoLiceID);

		//bool SaveChanges();
	}
}
