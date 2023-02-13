using KorisniciService.Entities;

namespace KorisniciService.Data
{
    public interface IKorisnikRepository
    {
        List<KorisnikEntity> GetKorisnici();

        KorisnikEntity GetKorisnikByID(Guid KorisnikID);

        KorisnikEntity CreateKorisnik(KorisnikEntity Korisnik);

        void UpdateKorisnik(KorisnikEntity Korisnik);

        void DeleteKorisnik(Guid KorisnikID);

        bool SaveChanges();
    }
}
