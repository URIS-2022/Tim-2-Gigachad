using LiceService.Entities;

namespace LiceService.Data
{
	public class PravnoLiceRepository : IPravnoLiceRepository
	{
		public static List<PravnoLiceEntity> PravnaLica { get; set; } = new List<PravnoLiceEntity>();

		public PravnoLiceRepository()
		{
			FillData();
		}

		private static void FillData()
		{

		}

		public PravnoLiceEntity CreatePravnoLice(PravnoLiceEntity pravnoLice)
		{
			throw new NotImplementedException();
		}

		public void DeletePravnoLice(Guid pravnoLiceID)
		{
			throw new NotImplementedException();
		}

		public List<PravnoLiceEntity> GetPravnaLica()
		{
			throw new NotImplementedException();
		}

		public PravnoLiceEntity GetPravnoLiceByID(Guid pravnoLiceID)
		{
			throw new NotImplementedException();
		}

		public void UpdatePravnoLice(PravnoLiceEntity pravnoLice)
		{
			throw new NotImplementedException();
		}
	}
}
