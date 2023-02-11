using LiceService.Entities;

namespace LiceService.Data
{
	public class LiceRepository : ILiceRepository
	{
		public static List<LiceEntity> Lica { get; set; } = new List<LiceEntity>();

		public LiceRepository()
		{
			FillData();
		}

		private static void FillData()
		{

		}

		public LiceEntity CreateLice(LiceEntity lice)
		{
			throw new NotImplementedException();
		}

		public void DeleteLice(Guid liceID)
		{
			throw new NotImplementedException();
		}

		public List<LiceEntity> GetLica()
		{
			throw new NotImplementedException();
		}

		public LiceEntity GetLiceByID(Guid liceID)
		{
			throw new NotImplementedException();
		}

		public void UpdateLice(LiceEntity lice)
		{
			throw new NotImplementedException();
		}
	}
}
