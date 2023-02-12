using UplataService.Entities;

namespace UplataService.Data
{
    public interface IUplataRepository
    {
        List<UplataEntity> GetUplate();

        UplataEntity GetUplataByID(Guid UplataID);

        UplataEntity CreateUplata(UplataEntity Uplata);

        void UpdateUplata(UplataEntity Uplata);

        void DeleteUplata(Guid UplataID);

        bool SaveChanges();
    }
}
