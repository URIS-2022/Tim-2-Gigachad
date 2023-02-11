using KomisijaService.Entities;

namespace KomisijaService.Data
{
    public interface IKomisijaRepository
    {
        List<KomisijaEntity> GetKomisije();

        KomisijaEntity GetKomisijaByID(Guid komisijaID);

        KomisijaEntity CreateKomisija(KomisijaEntity komisija);

        void UpdateKomisija(KomisijaEntity komisija);

        void DeleteKomisija(Guid komisijaID);

        //bool saveChanges();
    }
}
