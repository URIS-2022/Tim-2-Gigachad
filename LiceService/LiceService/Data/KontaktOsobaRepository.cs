using LiceService.Entities;

namespace LiceService.Data
{
	public class KontaktOsobaRepository : IKontaktOsobaRepository
	{
		public static List<KontaktOsobaEntity> KontaktOsobe { get; set; } = new List<KontaktOsobaEntity>();

		public KontaktOsobaRepository()
		{
			FillData();
		}

		private static void FillData()
		{

		}

		public KontaktOsobaEntity CreateKontaktOsoba(KontaktOsobaEntity kontaktOsoba)
		{
			throw new NotImplementedException();
		}

		public void DeleteKontaktOsoba(Guid kontaktOsobaID)
		{
			throw new NotImplementedException();
		}

		public KontaktOsobaEntity GetKontaktOsobaByID(Guid kontaktOsobaID)
		{
			throw new NotImplementedException();
		}

		public List<KontaktOsobaEntity> GetKontaktOsobe()
		{
			throw new NotImplementedException();
		}

		public void UpdateKontaktOsoba(KontaktOsobaEntity kontaktOsoba)
		{
			throw new NotImplementedException();
		}
	}
}
