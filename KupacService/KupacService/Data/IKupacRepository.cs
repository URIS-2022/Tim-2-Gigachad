using KupacService.Entities;

namespace KupacService.Data
{
    public interface IKupacRepository
    {
        List<KupacEntity> GetKupci();

        KupacEntity GetKupacByID(Guid kupacID);

        KupacEntity CreateKupac(KupacEntity kupac);

        void UpdateKupac(KupacEntity kupac);

        void DeleteKupac(Guid kupacID);

        bool SaveChanges();
    }
}
