using UplataService.Entities;

namespace KorisniciService.Data
{
    public class KorisnikRepository : IKorisnikRepository
    {
        public static List<KorisnikEntity> Korisnici { get; set; } = new List<KorisnikEntity>();

        public KorisnikRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Korisnici.AddRange(new List<KorisnikEntity>
            {
                new KorisnikEntity
                {
                    KorisnikID = Guid.Parse("Dodaj Guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodaj Guid"),
                    TipKorisnika = "Tehnicki sekretar",
                    Naziv = "Wynn Lagadu",
                    Sifra = "EjfkRqXrltLI"
                },
                new KorisnikEntity
                {
                    KorisnikID = Guid.Parse("Dodaj Guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodaj Guid"),
                    TipKorisnika = "Operater Nadmetanja",
                    Naziv = "Manuel Andriessen",
                    Sifra = "n4xxvQyQm"
                }
            }); ; ;
        }

        public KorisnikEntity CreateKorisnik(KorisnikEntity korisnik)
        {
            throw new NotImplementedException();
        }

        public void DeleteKorisnik(Guid korisnikID)
        {
            throw new NotImplementedException();
        }

        public KorisnikEntity GetKorisnikByID(Guid korisnikID)
        {
            throw new NotImplementedException();
        }

        public List<KorisnikEntity> GetKorisnikEntities()
        {
            throw new NotImplementedException();
        }

        public void UpdateKorisnik(KorisnikEntity korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
