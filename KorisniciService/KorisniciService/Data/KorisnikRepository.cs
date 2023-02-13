using AutoMapper;
using KorisniciService.Entities;

namespace KorisniciService.Data
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly KorisnikContext context;
        private readonly IMapper mapper;

        public KorisnikRepository(KorisnikContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<KorisnikEntity> GetKorisnici()
        {
            return context.Korisnici.ToList();
        }

        public KorisnikEntity CreateKorisnik(KorisnikEntity Korisnik)
        {
            return null;
        }

        public void DeleteKorisnik(Guid KorisnikID)
        {
        }

        public KorisnikEntity GetKorisnikByID(Guid KorisnikID)
        {
            return null;
        }

        public void UpdateKorisnik(KorisnikEntity Korisnik)
        {
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
