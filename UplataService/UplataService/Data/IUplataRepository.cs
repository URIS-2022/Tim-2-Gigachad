using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    public interface IUplataRepository
    {
        List<UplataEntity> GetUplate();

        UplataEntity GetUplataByID(Guid UplataID);

        UplataDTO CreateUplata(UplataCreateDTO UplataCreateDTO);

        void UpdateUplata(UplataEntity Uplata);

        void DeleteUplata(Guid UplataID);

        bool SaveChanges();
    }
}
