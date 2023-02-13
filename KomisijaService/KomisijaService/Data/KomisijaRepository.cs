using AutoMapper;
using KomisijaService.Entities;

namespace KomisijaService.Data
{
    public class KomisijaRepository : IKomisijaRepository
    { 
        private readonly KomisijaContext context;
        private readonly IMapper mapper;

        public KomisijaRepository(KomisijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<KomisijaEntity> GetKomisije() {
            return context.Komisije.ToList();
        }
        public KomisijaEntity CreateKomisija(KomisijaEntity komisija)
        {
            return null;
        }

        public void DeleteKomisija(Guid komisijaID)
        {
            
        }

        public KomisijaEntity GetKomisijaByID(Guid komisijaID)
        {
            return null;
        }

        public void UpdateKomisija(KomisijaEntity komisija)
        {
            
        }

        public bool saveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
