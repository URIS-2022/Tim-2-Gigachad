using LiceService.Entities;

namespace LiceService.Data
{
	public interface ILiceRepository
	{
		List<LiceEntity> GetLica();

		LiceEntity GetLiceByID(Guid liceID);

		LiceEntity CreateLice(LiceEntity lice);

		void UpdateLice(LiceEntity lice);

		void DeleteLice(Guid liceID);

		//bool SaveChanges();
	}
}
