using KomisijaService.Entities;

namespace KomisijaService.Data
{
    public class KomisijaRepository : IKomisijaRepository
    {

        List<KomisijaEntity> komisija { get; set; } = new List<KomisijaEntity>();

        public KomisijaRepository() {
            FillData();
        }

        private void FillData()
        {
            throw new NotImplementedException();
        }

        public KomisijaEntity CreateKomisija(KomisijaEntity komisija)
        {
            throw new NotImplementedException();
        }

        public void DeleteKomisija(Guid komisijaID)
        {
            throw new NotImplementedException();
        }

        public KomisijaEntity GetKomisijaByID(Guid komisijaID)
        {
            throw new NotImplementedException();
        }

        public List<KomisijaEntity> GetKomisije()
        {
            throw new NotImplementedException();
        }

        public void UpdateKomisija(KomisijaEntity komisija)
        {
            throw new NotImplementedException();
        }
    }
}
