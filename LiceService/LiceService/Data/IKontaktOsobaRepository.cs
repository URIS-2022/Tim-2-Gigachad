using LiceService.Entities;

namespace LiceService.Data
{
	public interface IKontaktOsobaRepository
	{
		List<KontaktOsobaEntity> GetKontaktOsobe();

		KontaktOsobaEntity GetKontaktOsobaByID(Guid kontaktOsobaID);

		KontaktOsobaEntity CreateKontaktOsoba(KontaktOsobaEntity kontaktOsoba);

		void UpdateKontaktOsoba(KontaktOsobaEntity kontaktOsoba);

		void DeleteKontaktOsoba(Guid kontaktOsobaID);

		//bool SaveChanges();
	}
}
