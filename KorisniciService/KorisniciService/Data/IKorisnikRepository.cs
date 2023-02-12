using UplataService.Entities;

namespace KorisniciService.Data
{
    public interface IKorisnikRepository
    {
        List<KorisnikEntity> GetKorisnikEntities();

        KorisnikEntity GetKorisnikByID(Guid korisnikID);

        KorisnikEntity CreateKorisnik(KorisnikEntity korisnik);

        void UpdateKorisnik(KorisnikEntity korisnik);

        void DeleteKorisnik(Guid korisnikID);
    }
}
