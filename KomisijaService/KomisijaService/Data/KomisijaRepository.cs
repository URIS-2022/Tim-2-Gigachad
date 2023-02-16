using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.Models;

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
        public KomisijaDTO CreateKomisija(KomisijaCreateDTO komisijaCreateDTO)
        {
            KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaCreateDTO);
            komisija.KomisijaID = Guid.NewGuid();
            context.Add(komisija);
            return mapper.Map<KomisijaDTO>(komisija);
        }

        public void DeleteKomisija(Guid komisijaID)
        {
            KomisijaEntity? komisija = GetKomisijaByID(komisijaID);
            if (komisija != null)
                context.Remove(komisija);
        }

        public KomisijaEntity? GetKomisijaByID(Guid komisijaID)
        {
            return context.Komisije.FirstOrDefault(e => e.KomisijaID == komisijaID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
