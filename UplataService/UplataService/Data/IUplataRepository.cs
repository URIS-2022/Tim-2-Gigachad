using UplataService.Entities;

namespace UplataService.Data
{
    public interface IUplataRepository
    {
        List<UplataEntity> GetUplataEntities();

        UplataEntity GetUplataByID(Guid uplataID);

        UplataEntity CreateUplata(UplataEntity uplata);

        void UpdateUplata(UplataEntity uplata);

        void DeleteUplata(Guid uplataID);
    }
}
