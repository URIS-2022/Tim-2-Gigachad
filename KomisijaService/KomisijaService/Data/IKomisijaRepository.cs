using KomisijaService.Entities;
using KomisijaService.Models;

namespace KomisijaService.Data
{
    public interface IKomisijaRepository
    {
        List<KomisijaEntity> GetKomisije();

        KomisijaEntity? GetKomisijaByID(Guid komisijaID);

        KomisijaDTO CreateKomisija(KomisijaCreateDTO komisija);

        void DeleteKomisija(Guid komisijaID);

        bool SaveChanges();
    }
}
