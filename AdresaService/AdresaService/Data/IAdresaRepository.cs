using AdresaService.Entities;

namespace AdresaService.Data
{
    public interface IAdresaRepository
    {
        List<AdresaEntity> GetAdrese();

        AdresaEntity GetAdresaByID(Guid ID);

        AdresaEntity CreateAdresa(AdresaEntity adresa);

        void UpdateAdresa(AdresaEntity adresa);

        void DeleteAdresa(Guid adresaID);

        bool SaveChanges();
    }
}
