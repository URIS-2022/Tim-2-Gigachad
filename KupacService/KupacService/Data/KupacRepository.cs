using AutoMapper;
using KupacService.Entities;

namespace KupacService.Data
{
    public class KupacRepository : IKupacRepository
    {
        private readonly KupacContext context;
        private readonly IMapper mapper;

        public KupacRepository(KupacContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<KupacEntity> GetKupci()
        {
            return context.Kupci.ToList();
        }

        public KupacEntity CreateKupac(KupacEntity fizickoLice)
        {
            return null;
        }

        public void DeleteKupac(Guid kupacID)
        {
        }

        public KupacEntity GetKupacByID(Guid kupacID)
        {
            return null;
        }

        public void UpdateKupac(KupacEntity kupac)
        {
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
