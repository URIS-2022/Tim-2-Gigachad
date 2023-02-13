using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Data
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly AdresaContext context;
        private readonly IMapper mapper;

        public AdresaRepository(AdresaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<AdresaEntity> GetAdrese()
        {
            return context.Adresa.ToList();
        }

        public AdresaEntity CreateAdresa(AdresaEntity adresa)
        {
            return null;
        }

        public void DeleteAdresa(Guid ID)
        {
            throw new NotImplementedException();
        }
        public AdresaEntity GetAdresaByID(Guid ID)
        {
            return null;
        }

        public void UpdateAdresa(AdresaEntity adresa)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
